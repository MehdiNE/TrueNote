namespace TrueNote.Contracts.Requests;

public class CreateNoteRequest
{
    public required string Title { get; init; }
    public required string Description { get; init; }
}
