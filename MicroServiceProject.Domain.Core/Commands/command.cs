using MicroServiceProject.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.Domain.Core.Commands
{
   public abstract class Command : Message
    {
        // command send time
        // only who gets this class can set timestamp
        public DateTime TimeStamp { get; protected set; }
    
        protected Command()
        {
            TimeStamp = DateTime.Now;
        }
    }

}
