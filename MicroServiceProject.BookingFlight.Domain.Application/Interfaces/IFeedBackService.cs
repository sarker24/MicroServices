using MicroServiceProject.BookingFlight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Application.Interfaces
{
   public interface IFeedBackService
    {
        IEnumerable<FeedBack> GetFeedbacks();
    }
}
