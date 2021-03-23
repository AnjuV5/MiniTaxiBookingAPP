using System;
using System.Collections.Generic;

#nullable disable

namespace MiniTaxiBookingApplication.Models
{
    public partial class BookingStatus
    {
        public BookingStatus()
        {
            BookingData = new HashSet<BookingDatum>();
        }

        public int Id { get; set; }
        public string Status { get; set; }

        public virtual ICollection<BookingDatum> BookingData { get; set; }
    }
}
