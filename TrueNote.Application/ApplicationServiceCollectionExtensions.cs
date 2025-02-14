using Microsoft.Extensions.DependencyInjection;
using TrueNote.Application.Database;
using TrueNote.Application.Repositories;

namespace TrueNote.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddDbContext<NotesContext>();
        return services;
    }
}
