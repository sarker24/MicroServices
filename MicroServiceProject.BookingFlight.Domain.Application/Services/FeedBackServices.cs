using MicroServiceProject.BookingFlight.Application.Interfaces;
using MicroServiceProject.BookingFlight.Domain.Interfaces;
using MicroServiceProject.BookingFlight.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Application.Services
{
    public class FeedBackServices : IFeedBackService
    {
        private readonly IfeedBackRepository _feedBackRepository;

        public FeedBackServices(IfeedBackRepository feedBackRepository)
        {
            _feedBackRepository = feedBackRepository;
        }

        public IEnumerable<FeedBack> GetFeedbacks()
        {
            return _feedBackRepository.GetFeedBacks();
        }
    }
}
