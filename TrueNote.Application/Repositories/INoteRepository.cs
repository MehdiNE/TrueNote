using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public interface INoteRepository
{
    Task<bool> CreateAsync(Note note, CancellationToken token = default);

    Task<Note?> GetByIdAsync(Guid id, Guid userId, CancellationToken token = default);

    Task<IEnumerable<Note>> GetAllAsync(Guid userId, CancellationToken token = default);

    Task<bool> UpdateAsync(Note note, Guid userId, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, Guid userId, CancellationToken token = default);

    //Task<bool> ExistsByIdAsync(Guid id);
}
