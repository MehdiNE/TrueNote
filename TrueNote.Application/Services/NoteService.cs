using FluentValidation;
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

    public async Task<bool> CreateAsync(Note note, CancellationToken token)
    {
        await _noteValidator.ValidateAndThrowAsync(note, cancellationToken: token);
        return await _noteRepository.CreateAsync(note, token);
    }

    public Task<bool> DeleteByIdAsync(Guid id, Guid userId, CancellationToken token)
    {
        return _noteRepository.DeleteByIdAsync(id, userId, token);
    }

    public Task<IEnumerable<Note>> GetAllAsync(Guid userId, CancellationToken token)
    {
        return _noteRepository.GetAllAsync(userId, token);
    }

    public Task<Note?> GetByIdAsync(Guid id, Guid userId, CancellationToken token)
    {
        return _noteRepository.GetByIdAsync(id, userId, token);
    }

    public async Task<Note?> UpdateAsync(Note note, Guid userId, CancellationToken token)
    {
        await _noteValidator.ValidateAndThrowAsync(note, cancellationToken: token);
        var isUpdated = await _noteRepository.UpdateAsync(note, userId, token);
        if (!isUpdated)
        {
            return null;
        }

        return note;
    }
}
