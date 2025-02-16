using TrueNote.Application.Models;

namespace TrueNote.Application.Services;

public interface INoteService
{
    Task<bool> CreateAsync(Note note);

    Task<Note?> GetByIdAsync(Guid id);

    Task<IEnumerable<Note>> GetAllAsync();

    Task<Note?> UpdateAsync(Note note);

    Task<bool> DeleteByIdAsync(Guid id);
}
