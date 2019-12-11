using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.Domain.Core.Events
{
    //Any request using MediatR expect true or false
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
           
    }
}
