namespace TrueNote.Contracts.Requests;

public class UpdateNoteRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}
