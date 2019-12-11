using MicroServiceProject.Domain.Core.Commands;
using MicroServiceProject.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroServiceProject.Domain.Core.Bus
{
   public interface IEventBus
    {
        // Send command use MediatR library to send command
        Task SendCommand<T>(T commnd) where T : Command;
        // Publish event
        void publish<T>(T @event) where T : Event;
        // Subscribe event task and event handler
        void Subscribe<T, TH >()
             where T: Event
             where TH : IEventHandler<T>;
    }
}
