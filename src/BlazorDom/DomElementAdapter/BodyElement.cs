using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    
    public class BodyElement : DomElement, IDomElement
    {
        
        public BodyElement(IJSInProcessObjectReference BlazorDomModule) : base(BlazorDomModule)
        {
        }

        
    }
}