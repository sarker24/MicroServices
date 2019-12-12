using MicroServiceProject.BookingFlight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Domain.Interfaces
{
    public interface IFeedBackRepository
    {
        IEnumerable<FeedBack> GetFeedBacks();
    }
}