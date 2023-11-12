using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using AmazingShopPV113.FrontendBlazor;
using MudBlazor.Services;
using AmazingShopPV113.HttpApiClient;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton(sp => new HttpClient() { 
    Timeout = TimeSpan.FromSeconds(5)
});
builder.Services.AddSingleton(provider
    => new AmazingShopClient(provider.GetRequiredService<HttpClient>(), "https://localhost:7072"));

builder.Services.AddMudServices();

await builder.Build().RunAsync();
