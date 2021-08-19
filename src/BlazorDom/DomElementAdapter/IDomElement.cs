using System;
using System.Threading.Tasks;

namespace BlazorDom.DomElementAdapter
{
    public interface IDomElement : IQuerableDomElement, IDomElementEventHandler
    {
    }
    public interface IDomElementList : IQuerableDomElement, IDomElementEventHandler
    {
        Task<int> CountAsync();
    }
    public interface IQuerableDomElement
    {
        Task<IDomElement> FindAsync(string selector);

        Task<IDomElementList> FindAllAsync(string selector);
    }

    public interface IDomElementEventHandler
    {
        Task<DomEventHandler> AddEventListenerAsync(string eventName, Action<object> handler);
    }
}