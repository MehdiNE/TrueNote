using Microsoft.AspNetCore.Mvc;
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
    }
}
