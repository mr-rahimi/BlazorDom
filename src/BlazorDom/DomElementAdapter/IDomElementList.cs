using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public interface IDomElementList
    {
        Task<IDomElement> FindAsync(string selector);

        Task<IDomElementList> FindAllAsync(string selector);

        Task<DomEventHandler> AddEventListenerAsync(string eventName, Action<object> handler);
        Task<int> CountAsync();
    }
}