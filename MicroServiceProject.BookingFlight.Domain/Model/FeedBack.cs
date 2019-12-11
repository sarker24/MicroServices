using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Domain.Model
{
  public  class FeedBack
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
