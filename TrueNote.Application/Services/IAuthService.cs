using TrueNote.Application.Models;

namespace TrueNote.Application.Services;

public interface IAuthService
{
    Task<User?> RegisterAsync(string userName, string password);
    Task<string?> LoginAsync(string userName, string password);
}
