﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TrueNote.Application.Database;
using TrueNote.Application.Models;
using TrueNote.Application.Repositories;
using TrueNote.Application.Services;

namespace TrueNote.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<INoteService, NoteService>();
        services.AddDbContext<NotesContext>();
        services.AddValidatorsFromAssemblyContaining<Note>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        return services;
    }
}
