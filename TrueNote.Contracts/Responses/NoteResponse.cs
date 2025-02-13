namespace TrueNote.Contracts.Responses;

public class NoteResponse
{
    public required Guid Id { get; init; }
    public required string Title { get; init; }
    public required string Description { get; init; }
}
