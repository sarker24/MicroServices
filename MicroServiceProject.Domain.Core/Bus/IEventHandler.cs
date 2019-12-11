using MicroServiceProject.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceProject.Domain.Core.Bus
{
    // IEventHadler take any type of event
   public interface IEventHandler<in TEvent> : IEventHandler
        where TEvent : Event
    {
        // any event comming handler that
        Task Hadler(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}
