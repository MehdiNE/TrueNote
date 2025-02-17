using Microsoft.EntityFrameworkCore;
using TrueNote.Application.Database;
using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public class NoteRepository : INoteRepository
{
    private readonly NotesContext _notesContext;

    public NoteRepository(NotesContext notesContext)
    {
        _notesContext = notesContext;
    }

    public async Task<bool> CreateAsync(Note note, CancellationToken token = default)
    {
        await _notesContext.Notes.AddAsync(note, token);
        await _notesContext.SaveChangesAsync(token);
        return true;
    }

    public async Task<Note?> GetByIdAsync(Guid id, CancellationToken token = default)
    {
        var note = await _notesContext.Notes.SingleOrDefaultAsync(x => x.Id == id, token);
        return note;
    }

    public async Task<IEnumerable<Note>> GetAllAsync(CancellationToken token = default)
    {
        return await _notesContext.Notes.ToListAsync(token);
    }

    public async Task<bool> UpdateAsync(Note note, CancellationToken token = default)
    {
        var existingNote = await _notesContext.Notes.FindAsync(note.Id, token);
        if (existingNote is null)
        {
            return false;
        }

        existingNote.Title = note.Title;
        existingNote.Description = note.Description;

        await _notesContext.SaveChangesAsync(token);
        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default)
    {
        var existingNote = await _notesContext.Notes.FindAsync(id, token);
        if (existingNote is null)
        {
            return false;
        }

        _notesContext.Notes.Remove(existingNote);

        await _notesContext.SaveChangesAsync(token);

        return true;
    }

    //public async Task<bool> ExistsByIdAsync(Guid id)
    //{
    //    var existingNote = await _notesContext.Notes.FindAsync(id);
    //    if (existingNote is null)
    //    {
    //        return false;
    //    }

    //    _notesContext.Notes.Remove(existingNote);

    //    await _notesContext.SaveChangesAsync();

    //    return true;
    //}
}
