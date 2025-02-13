using TrueNote.Application.Models;
using TrueNote.Contracts.Requests;
using TrueNote.Contracts.Responses;

namespace TrueNote.Api.Mapping;

public static class ContractMapping
{
    public static Note MapToNote(this CreateNoteRequest request)
    {
        return new Note
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description
        };
    }
    public static Note MapToNote(this UpdateNoteRequest request, Guid id)
    {
        return new Note
        {
            Id = id,
            Title = request.Title,
            Description = request.Description
        };
    }

    public static NoteResponse MapToResponse(this Note note)
    {
        return new NoteResponse
        {
            Id = Guid.NewGuid(),
            Title = note.Title,
            Description = note.Description
        };
    }

    public static NotesResponse MapToResponse(this IEnumerable<Note> notes)
    {
        return new NotesResponse
        {
            Items = notes.Select(MapToResponse)
        };
    }
}
