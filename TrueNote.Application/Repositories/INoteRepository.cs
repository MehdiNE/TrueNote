using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public interface INoteRepository
{
    Task<bool> CreateAsync(Note note);

    Task<Note?> GetByIdAsync(Guid id);

    Task<IEnumerable<Note>> GetAllAsync();

    Task<bool> UpdateAsync(Note note);

    Task<bool> DeleteByIdAsync(Guid id);
}
