using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public class DomEventService
    {
        private readonly IJSRuntime _JSRuntime;

        public DomEventService(IJSRuntime jSRuntime)
        {
            _JSRuntime = jSRuntime;
        }

        public async Task<DomEventHandler> AddEventListener(string selector, string eventName, Action<object> handler)
        {
            var options = new
            {
                selector,
                eventName
            };

            EventHandlerInvokeHelper eventHandlerInvokeHelper = new EventHandlerInvokeHelper(handler);

            var eventHandleObject = await _JSRuntime.InvokeAsync<IJSInProcessObjectReference>("eventHandler.addEventListener", DotNetObjectReference.Create(eventHandlerInvokeHelper), options);

            return new DomEventHandler(eventHandleObject);
        }

        public class EventHandlerInvokeHelper
        {
            private Action<object> action;

            public EventHandlerInvokeHelper(Action<object> action)
            {
                this.action = action;
            }

            [JSInvokable("InvokeHandler")]
            public void InvokeHandler(object value)
            {
                action.Invoke(value);
            }
        }
    }
}