using FluentValidation;
using TrueNote.Application.Database;
using TrueNote.Application.Models;
using TrueNote.Application.Repositories;

namespace TrueNote.Application.Services;

public class NoteService : INoteService
{
    private readonly INoteRepository _noteRepository;
    private readonly IValidator<Note> _noteValidator;

    public NoteService(INoteRepository noteRepository, IValidator<Note> noteValidator)
    {
        _noteRepository = noteRepository;
        _noteValidator = noteValidator;
    }

    public async Task<bool> CreateAsync(Note note)
    {
        await _noteValidator.ValidateAndThrowAsync(note);
        return await _noteRepository.CreateAsync(note);
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
        await _noteValidator.ValidateAndThrowAsync(note);
        var isUpdated = await _noteRepository.UpdateAsync(note);
        if (!isUpdated)
        {
            return null;
        }

        return note;
    }
}
