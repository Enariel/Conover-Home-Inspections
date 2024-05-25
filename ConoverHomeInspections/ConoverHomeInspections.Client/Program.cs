using ConoverHomeInspections.Client.Services;
using ConoverHomeInspections.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton(new HttpClient() { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IProductService, ClientProductService>();
builder.Services.AddSingleton<IContactService, ClientContactService>();
builder.Services.AddMudServices();
await builder.Build().RunAsync();