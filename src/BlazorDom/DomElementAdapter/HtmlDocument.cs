using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public class HtmlDocument
    {
        private readonly IImportModule _ImportModule;
        public HtmlDocument(IImportModule blazorDomModule)
        {
            _ImportModule = blazorDomModule;
        }
        public async Task<IDomElement> Find(string selector)
        {
            var module = await _ImportModule.GetModule();
            var objectReference = await module.InvokeAsync<IJSInProcessObjectReference>("find", selector);
            return new DomElement(objectReference);
        }
        public async Task<IDomElementList> FindAll(string selector)
        {
            var module = await _ImportModule.GetModule();
            var objectReference = await module.InvokeAsync<IJSInProcessObjectReference>("findAll", selector);
            return new DomElementList(objectReference);
        }
        public async Task<DomElement> Body()
        {
            var module = await _ImportModule.GetModule();
            var objectReference = await module.InvokeAsync<IJSInProcessObjectReference>("find", "body");
            return new DomElement(objectReference);
        }
    }
}