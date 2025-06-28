using FluentValidation;
using FluentValidation.AspNetCore;
using LifeSync.Application.Books.DTOs;
using LifeSync.Application.Books.Validators;
using LifeSync.Application.Finance.DTOs;
using LifeSync.Application.Finance.Validators;

namespace LifeSync.Api.DependencyInjection;

public static class ValidationDependency
{
    public static IServiceCollection AddValidationServices(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<BookDtoValidator>();
        services.AddValidatorsFromAssemblyContaining<TransactionDtoValidator>();
        return services;
    }
} 