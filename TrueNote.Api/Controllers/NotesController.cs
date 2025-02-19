﻿using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TrueNote.Api.Mapping;
using TrueNote.Application.Models;
using TrueNote.Application.Repositories;
using TrueNote.Application.Services;
using TrueNote.Contracts.Requests;

namespace TrueNote.Api.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteService _noteService;

        public NotesController(INoteService noteService)
        {
            _noteService = noteService;
        }

        [HttpPost(ApiEndpoints.Notes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest request, CancellationToken token)
        {
            var note = request.MapToNote();
            await _noteService.CreateAsync(note, token);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        [HttpGet(ApiEndpoints.Notes.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var note = await _noteService.GetByIdAsync(id, token);
            if (note is null)
            {
                return NotFound();
            }

            var response = note.MapToResponse();

            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Notes.GetAll)]
        public async Task<IActionResult> GetAll(CancellationToken token)
        {
            var notes = await _noteService.GetAllAsync(token);

            var notesResponse = notes.MapToResponse();

            return Ok(notesResponse);
        }

        [HttpPut(ApiEndpoints.Notes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]
        UpdateNoteRequest request, CancellationToken token)
        {
            var note = request.MapToNote(id);
            var updatedNote = await _noteService.UpdateAsync(note, token);
            if (updatedNote is null)
            {
                return NotFound();
            }
            var response = note.MapToResponse();
            return Ok(response);
        }

        [HttpDelete(ApiEndpoints.Notes.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken token)
        {
            var deleted = await _noteService.DeleteByIdAsync(id, token);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
