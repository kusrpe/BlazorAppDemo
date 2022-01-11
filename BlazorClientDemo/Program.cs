using BlazorClientDemo;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorClientDemo.ServicesProxy.Implementation;
using BlazorClientDemo.ServicesProxy.Interfaces;
using BlazorStrap;
using Toolbelt.Blazor.Extensions.DependencyInjection;
var builder = WebAssemblyHostBuilder.CreateDefault(args);
string DogsAPIUrl = builder.Configuration.GetValue<string>("DogsAPIURL");
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBootstrapCss();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient<IDogs,DogsImpl>("DogsAPI", (sp, cl) =>
{
    cl.BaseAddress = new Uri(DogsAPIUrl);
    cl.EnableIntercept(sp);
    
});
builder.Services.AddScoped(sp => sp.GetService<IHttpClientFactory>().CreateClient("DogsAPI"));
builder.Services.AddHttpClientInterceptor();
builder.Services.AddScoped<IDogs, DogsImpl>();
await builder.Build().RunAsync();
