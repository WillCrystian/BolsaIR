using BolsaIR.Application.Behaviors;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Application.Importers;
using BolsaIR.Application.Importers.Interfaces;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BolsaIR.Application.DependencyInjection;

public static class ApplicationServiceCollectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(cfg =>
		{
			cfg.RegisterServicesFromAssembly(
				typeof(ApplicationServiceCollectionExtensions).Assembly);
		});

		services.AddValidatorsFromAssembly(
			typeof(ApplicationServiceCollectionExtensions).Assembly);

		services.AddTransient(
			typeof(IPipelineBehavior<,>),
			typeof(ValidationBehavior<,>));

		services.AddAutoMapper(Assembly.GetExecutingAssembly());

		services.AddScoped<IImportBrokerageNoteService, ImportBrokerageNoteService>();

		
		return services;
	}
}