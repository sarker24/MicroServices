using MicroServiceProject.BookingFlight.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroServiceProject.BookingFlight.Data.Context
{
  public class BookingFlightDBContext: DbContext
    {
        public BookingFlightDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FeedBack> feedBacks { get; set; }
    }
}
