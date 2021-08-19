using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public class DomElementList : IDomElementList
    {
        private IJSInProcessObjectReference _DomObject;

        public DomElementList(IJSInProcessObjectReference domObject)
        {
            _DomObject = domObject;
        }

        public async Task<DomEventHandler> AddEventListenerAsync(string eventName, Action<object> handler)
        {
            var options = new
            {
                eventName
            };

            EventHandlerInvokeHelper eventHandlerInvokeHelper = new EventHandlerInvokeHelper(handler);

            var eventHandleObject = await _DomObject.InvokeAsync<IJSInProcessObjectReference>("addEventListener", DotNetObjectReference.Create(eventHandlerInvokeHelper), options);

            return new DomEventHandler(eventHandleObject);
        }

        public async Task<IDomElement> FindAsync(string selector)
        {
            var Object = await _DomObject.InvokeAsync<IJSInProcessObjectReference>("find", selector);
            return new DomElement(Object);
        }

        public async Task<IDomElementList> FindAllAsync(string selector)
        {
            var Object = await _DomObject.InvokeAsync<IJSInProcessObjectReference>("findAll", selector);
            return new DomElementList(Object);
        }
        public async Task<int> CountAsync()
        {
            var count = await _DomObject.InvokeAsync<int>("count");
            return count;
        }
    }
}