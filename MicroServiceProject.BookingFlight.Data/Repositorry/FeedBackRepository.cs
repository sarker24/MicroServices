using MicroServiceProject.BookingFlight.Data.Context;
using MicroServiceProject.BookingFlight.Domain.Interfaces;
using MicroServiceProject.BookingFlight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Data.Repositorry
{
    public class FeedBackRepository : IfeedBackRepository
    {
        private BookingFlightDBContext _ctx;

        public FeedBackRepository(BookingFlightDBContext ctx)
        {
            _ctx = ctx;
        }

        public IEnumerable<FeedBack> GetFeedBacks()
        {
            return _ctx.feedBacks;
        }

       
    }
}
