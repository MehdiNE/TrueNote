using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TrueNote.Api.Auth;
using TrueNote.Api.Mapping;
using TrueNote.Application.Services;
using TrueNote.Contracts.Requests;

namespace TrueNote.Api.Controllers
{
    [Authorize]
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
            var userId = HttpContext.GetUserId()!.Value;

            var note = request.MapToNote(userId);
            await _noteService.CreateAsync(note, token);
            return CreatedAtAction(nameof(Get), new { id = note.Id }, note);
        }

        [HttpGet(ApiEndpoints.Notes.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken token)
        {
            var userId = HttpContext.GetUserId()!.Value;

            var note = await _noteService.GetByIdAsync(id, userId, token);
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
            var userId = HttpContext.GetUserId()!.Value;

            var notes = await _noteService.GetAllAsync(userId, token);

            var notesResponse = notes.MapToResponse();

            return Ok(notesResponse);
        }

        [HttpPut(ApiEndpoints.Notes.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody]
        UpdateNoteRequest request, CancellationToken token)
        {
            var userId = HttpContext.GetUserId()!.Value;

            var note = request.MapToNote(id, userId);
            var updatedNote = await _noteService.UpdateAsync(note, userId, token);
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
            var userId = HttpContext.GetUserId()!.Value;

            var deleted = await _noteService.DeleteByIdAsync(id, userId, token);
            if (!deleted)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
