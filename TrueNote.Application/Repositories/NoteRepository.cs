using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly List<Note> _notes = [];

    public Task<bool> CreateAsync(Note note)
    {
        _notes.Add(note);
        return Task.FromResult(true);
    }

    public Task<Note?> GetByIdAsync(Guid id)
    {
        var note = _notes.SingleOrDefault(x => x.Id == id);
        return Task.FromResult(note);
    }

    public Task<IEnumerable<Note>> GetAllAsync()
    {
        return Task.FromResult(_notes.AsEnumerable());
    }

    public Task<bool> UpdateAsync(Note note)
    {
        var noteIndex = _notes.FindIndex(x => x.Id == note.Id);
        if (noteIndex == -1)
        {
            return Task.FromResult(false);
        }

        _notes[noteIndex] = note;
        return Task.FromResult(true);
    }

    public Task<bool> DeleteByIdAsync(Guid id)
    {
        var removedCount = _notes.RemoveAll(x => x.Id == id);
        var noteRemoved = removedCount > 0;
        return Task.FromResult(noteRemoved);
    }
}
