using Mhunter;
using Mhunter.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// This is your main HttpClient (pointing to your app's root)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// 👉 Add MonsterService + external API HttpClient
builder.Services.AddScoped<MonsterService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://mhw-db.com/") });

await builder.Build().RunAsync();

