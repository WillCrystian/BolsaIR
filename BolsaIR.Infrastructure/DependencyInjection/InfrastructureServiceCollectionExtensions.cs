using BolsaIR.Application.Features.Assets.Services;
using BolsaIR.Application.Features.BrokerageNotes.Services;
using BolsaIR.Application.Features.Brokers.Services;
using BolsaIR.Application.Features.Companies.Services;
using BolsaIR.Application.Features.CorporateActions.Services;
using BolsaIR.Application.Features.Dividends.Services;
using BolsaIR.Application.Features.Operations.Services;
using BolsaIR.Application.Features.PositionProcessing.Services;
using BolsaIR.Application.Features.Positions.Services;
using BolsaIR.Application.Features.TaxCalculation.Results;
using BolsaIR.Application.Features.TaxCalculation.Services;
using BolsaIR.Application.Importers.Interfaces;
using BolsaIR.Domain.Interfaces;
using BolsaIR.Infrastructure.Importers;
using BolsaIR.Infrastructure.Persistence;
using BolsaIR.Infrastructure.Persistence.Repositories;
using BolsaIR.Infrastructure.ReadServices;
using BolsaIR.Infrastructure.Repositories;
using BolsaIR.Infrastructure.Services;
using BolsaIR.Infrastructure.Services.TaxCalculation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace BolsaIR.Infrastructure.DependencyInjection;

public static class InfrastructureServiceCollectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		var databasePath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, @"..\..\..\..\BolsaIR.Infrastructure\BolsaIR.db"));

		services.AddDbContext<BolsaIRDbContext>(options =>
		{
			//options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
			options.UseSqlite($"Data Source={databasePath}");
		});

		services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
		services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
		services.AddScoped<IUnitOfWork, UnitOfWork>();

		services.AddScoped<IAssetReadService, AssetReadService>();
		services.AddScoped<IBrokerReadService, BrokerReadService>();
		services.AddScoped<ICompanyReadService, CompanyReadService>();
		services.AddScoped<IDividendReadService, DividendReadService>();
		services.AddScoped<IPositionReadService, PositionReadService>();
		services.AddScoped<IOperationReadService, OperationReadService>();
		services.AddScoped<IPositionSnapshotService, PositionSnapshotService>();
		services.AddScoped<IBrokerageNoteReadService, BrokerageNoteReadService>();
		services.AddScoped<ICorporateActionReadService, CorporateActionReadService>();
		services.AddScoped<IPositionCalculationService, PositionCalculationService>();
		services.AddScoped<ITaxCalculationQueryService, TaxCalculationQueryService>();


		services.AddScoped<IPositionRepository, PositionRepository>();

		services.AddScoped<IPositionProcessor, PositionProcessor>();
		services.AddScoped<IMonthlyProcessor, MonthlyProcessor>();

		//services.AddScoped<IMonthlyTaxCalculator, MonthlyTaxCalculator>();
		services.AddScoped<IDarfCalculator, DarfCalculator>();
		services.AddScoped<IProfitCalculator, ProfitCalculator>();
		services.AddScoped<ITaxRateCalculator, TaxRateCalculator>();
		services.AddScoped<ILossCompensationCalculator, LossCompensationCalculator>();
		//services.AddScoped<IExemptionCalculator, ExemptionCalculator>();

		services.AddScoped<IAnnualResultAggregator, AnnualResultAggregator>();
		services.AddScoped<IMonthlyResultAggregator, MonthlyResultAggregator>();

		services.AddScoped<ITaxCalculationEngine, TaxCalculationEngine>();

		services.AddScoped<IExemptionRule, ExemptionRule>();

		services.AddScoped<IPdfImporter, BtgPdfImporter>();


		return services;
	}
}