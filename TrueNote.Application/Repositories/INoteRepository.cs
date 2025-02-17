using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public interface INoteRepository
{
    Task<bool> CreateAsync(Note note, CancellationToken token = default);

    Task<Note?> GetByIdAsync(Guid id, CancellationToken token = default);

    Task<IEnumerable<Note>> GetAllAsync(CancellationToken token = default);

    Task<bool> UpdateAsync(Note note, CancellationToken token = default);

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);

    //Task<bool> ExistsByIdAsync(Guid id);
}
