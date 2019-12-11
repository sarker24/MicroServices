using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.Domain.Core.Events
{
  public  class Event
    {
        public DateTime TimeStamp { get; protected set; }

        protected Event()
    {
        TimeStamp = DateTime.Now;
    }
    }
}
