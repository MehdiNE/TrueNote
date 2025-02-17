using TrueNote.Application.Models;

namespace TrueNote.Application.Services;

public interface INoteService
{
    Task<bool> CreateAsync(Note note, CancellationToken token = default);

    Task<Note?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken token = default);

    Task<Note?> UpdateAsync(Note note, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
}
