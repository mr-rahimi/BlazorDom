using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public interface IImportModule
    {
        Task<IJSInProcessObjectReference> GetModule();
    }
    public class ImportModule : IImportModule
    {
        private readonly IJSRuntime _JSRuntime;
        private static IJSInProcessObjectReference _Module;
        private readonly Lazy<Task<IJSInProcessObjectReference>> moduleTask;

        public ImportModule(IJSRuntime jSRuntime)
        {
            this._JSRuntime = jSRuntime;
            moduleTask = new(() => _JSRuntime.InvokeAsync<IJSInProcessObjectReference>(
               "import", "./_content/BlazorDom/blazorDom/index.js").AsTask());
        }
        public async Task<IJSInProcessObjectReference> GetModule()
        {

            var module = await moduleTask.Value;
            return await module.InvokeAsync<IJSInProcessObjectReference>("blazorDom");
        }
    }
}