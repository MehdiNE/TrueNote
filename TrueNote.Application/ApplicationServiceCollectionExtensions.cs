using Microsoft.Extensions.DependencyInjection;
using TrueNote.Application.Repositories;

namespace TrueNote.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        return services;
    }
}
