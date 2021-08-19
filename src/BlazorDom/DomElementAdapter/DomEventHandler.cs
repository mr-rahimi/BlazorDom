using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public class DomEventHandler
    {
        public IJSInProcessObjectReference eventHandlerObject;

        public DomEventHandler(IJSInProcessObjectReference eventHandlerObject)
        {
            this.eventHandlerObject = eventHandlerObject;
        }

        public async Task RemoveHandler()
        {
            await eventHandlerObject.InvokeVoidAsync("removeHandler");
        }
    }
}