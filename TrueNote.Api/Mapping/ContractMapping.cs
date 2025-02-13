using TrueNote.Application.Models;
using TrueNote.Contracts.Requests;

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
}
