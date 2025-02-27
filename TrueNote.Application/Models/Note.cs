namespace TrueNote.Application.Models;

public class Note
{
    public required Guid Id { get; init; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public Guid UserId { get; set; }
}
