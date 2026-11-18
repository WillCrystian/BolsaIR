using BolsaIR.Application.DependencyInjection;
using BolsaIR.Infrastructure.DependencyInjection;
using BolsaIR.Infrastructure.Persistence;
using BolsaIR.Infrastructure.Persistence.Seeds;
using BolsaIR.Web.Components;
using Microsoft.Extensions.Options;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();



//vem do projeto Infrastructure, que é onde está o DbContext e as configurações do EF Core
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

Debug.WriteLine(Environment.CurrentDirectory);

Debug.WriteLine(Path.GetFullPath("BolsaIR.db"));


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
	var context =
		scope.ServiceProvider
			.GetRequiredService<BolsaIRDbContext>();

	BrokerSeed.Seed(context);
}



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
