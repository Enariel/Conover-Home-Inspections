using ConoverHomeInspections;
using ConoverHomeInspections.Components;
using ConoverHomeInspections.Data;
using ConoverHomeInspections.Services;
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
       .AddInteractiveServerComponents()
       .AddInteractiveWebAssemblyComponents();
builder.Services.AddControllersWithViews()
       .ConfigureApiBehaviorOptions(options => { options.InvalidModelStateResponseFactory = context => new BadRequestObjectResult(context.ModelState); })
       .AddJsonOptions(x =>
       {
           x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
           x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
           x.JsonSerializerOptions.WriteIndented = true;
       });
builder.Services.AddDbContextFactory<ConfigDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("ConfigConnection"));
});
builder.Services.AddScoped<IProductService, ServerProductService>();

builder.Services.AddHttpContextAccessor();
builder.Services.AddMudServices();
builder.Services.AddEndpointsApiExplorer();
// Add NSwag services
builder.Services.AddOpenApiDocument();

// Automapper mappings
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AllowNullCollections = true;
    cfg.AllowNullDestinationValues = true;
});
builder.Services.AddAutoMapper(typeof(ServiceProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapControllers();
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode()
   .AddInteractiveWebAssemblyRenderMode()
   .AddAdditionalAssemblies(typeof(ConoverHomeInspections.Client._Imports).Assembly);

app.Run();