using FluentValidation;
using TrueNote.Application.Models;

namespace TrueNote.Application.Validators;

public class NoteValidator : AbstractValidator<Note>
{
    public NoteValidator()
    {
        RuleFor(x => x.Title)
             .NotEmpty()
             .MinimumLength(1);

        RuleFor(x => x.Description)
            .NotEmpty();
    }
}
