using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Fina.Web;
using MudBlazor.Services;
using Fina.Core;
using Fina.Core.Handlers;
using Fina.Web.Handlers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient(WebConfiguration.HttpClientName,
    opt => opt.BaseAddress = new Uri(Configuration.BackendUrl));


builder.Services.AddTransient<ICategoryHandler, CategoryHandler>();
builder.Services.AddTransient<ITransactionHandler, TransactionHandler>();

builder.Services.AddMudServices();

await builder.Build().RunAsync();
