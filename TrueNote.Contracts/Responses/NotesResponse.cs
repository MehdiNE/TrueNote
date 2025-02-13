namespace TrueNote.Contracts.Responses;

public class NotesResponse
{
    public required IEnumerable<NoteResponse> Items { get; init; } = [];
}
