using TrueNote.Application.Database;
using TrueNote.Application.Models;
using TrueNote.Application.Repositories;

namespace TrueNote.Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;

    public NoteService(INoteRepository noteRepository)
    {
        _noteRepository = noteRepository;
    }

    public Task<bool> CreateAsync(Note note)
    {
        return _noteRepository.CreateAsync(note);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        return _noteRepository.DeleteByIdAsync(id);
    }

    public Task<IEnumerable<Note>> GetAllAsync()
    {
        return _noteRepository.GetAllAsync();
    }

    public Task<Note?> GetByIdAsync(Guid id)
    {
        return _noteRepository.GetByIdAsync(id);
    }

    public async Task<Note?> UpdateAsync(Note note)
    {
        var isUpdated = await _noteRepository.UpdateAsync(note);
        if (!isUpdated)
        {
            return null;
        }

        return note;


    }
}
