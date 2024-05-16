using ConoverHomeInspections.Client.Pages;
using ConoverHomeInspections.Components;
using ConoverHomeInspections.Data;
using ConoverHomeInspections.Services;
using ConoverHomeInspections.Shared;
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
       .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddDbContext<ConfigDbContext>();
builder.Services.AddSingleton<IProductService, ServerProductService>();
builder.Services.AddMudServices();
builder.Services.AddEndpointsApiExplorer();
// Add NSwag services
builder.Services.AddOpenApiDocument();

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