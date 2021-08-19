using BlazorDom.DomElementAdapter;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorDom
{
    public static class ServiceConfiguration
    {
        public static void AddBlazorDom(this IServiceCollection services)
        {
            services.AddScoped<IImportModule, ImportModule>();
            services.AddScoped<HtmlDocument>();
            services.AddScoped<ExampleJsInterop>();
        }
    }
}