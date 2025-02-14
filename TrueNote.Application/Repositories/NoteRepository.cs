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

    public async Task<bool> CreateAsync(Note note)
    {
        await _notesContext.Notes.AddAsync(note);
        await _notesContext.SaveChangesAsync();
        return true;
    }

    public async Task<Note?> GetByIdAsync(Guid id)
    {
        var note = await _notesContext.Notes.SingleOrDefaultAsync(x => x.Id == id);
        return note;
    }

    public async Task<IEnumerable<Note>> GetAllAsync()
    {
        return await _notesContext.Notes.ToListAsync();
    }

    public async Task<bool> UpdateAsync(Note note)
    {
        var existingNote = await _notesContext.Notes.FindAsync(note.Id);
        if (existingNote is null)
        {
            return false;
        }

        existingNote.Title = note.Title;
        existingNote.Description = note.Description;

        await _notesContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteByIdAsync(Guid id)
    {
        var existingNote = await _notesContext.Notes.FindAsync(id);
        if (existingNote is null)
        {
            return false;
        }

        _notesContext.Notes.Remove(existingNote);

        await _notesContext.SaveChangesAsync();

        return true;
    }
}
