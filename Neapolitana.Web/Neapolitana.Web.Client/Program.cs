using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);


builder.Services.AddScoped(sp =>
new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["FrontEndUrl"] ?? "https://localhost:7001")
});

await builder.Build().RunAsync();
