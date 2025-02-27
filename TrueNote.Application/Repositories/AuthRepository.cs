using Microsoft.EntityFrameworkCore;
using TrueNote.Application.Database;
using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly NotesContext _notesContext;

    public AuthRepository(NotesContext notesContext)
    {
        _notesContext = notesContext;
    }

    public async Task<bool> AddRegisterAsync(User user)
    {
        _notesContext.Users.Add(user);
        await _notesContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CheckRegisterAsync(string userName)
    {
        var user = await _notesContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user is not null;
    }

    public async Task<User?> LoginAsync(string userName)
    {
        var user = await _notesContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        return user;
    }
}
