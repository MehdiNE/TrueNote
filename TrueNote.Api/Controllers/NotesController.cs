using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using TrueNote.Api.Mapping;
using TrueNote.Application.Models;
using TrueNote.Application.Repositories;
using TrueNote.Contracts.Requests;

namespace TrueNote.Api.Controllers
{
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpPost(ApiEndpoints.Notes.Create)]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequest request)
        {
            var note = request.MapToNote();
            await _noteRepository.CreateAsync(note);
            return Ok(note);
        }

        [HttpGet(ApiEndpoints.Notes.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var note = await _noteRepository.GetByIdAsync(id);
            if (note is null)
            {
                return NotFound();
            }

            var response = note.MapToResponse();

            return Ok(response);
        }

        [HttpGet(ApiEndpoints.Notes.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _noteRepository.GetAllAsync();

            var notesResponse = notes.MapToResponse();

            return Ok(notesResponse);
        }
    }
}
