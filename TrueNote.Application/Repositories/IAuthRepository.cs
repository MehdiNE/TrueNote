using TrueNote.Application.Models;

namespace TrueNote.Application.Repositories;

public interface IAuthRepository
{
    Task<User?> LoginAsync(string userName);
    Task<bool> CheckRegisterAsync(string userName);
    Task<bool> AddRegisterAsync(User user);
}
