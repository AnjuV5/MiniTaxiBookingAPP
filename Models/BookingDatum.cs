using System;
using System.Collections.Generic;

#nullable disable

namespace MiniTaxiBookingApplication.Models
{
    public partial class BookingDatum
    {
        public int Id { get; set; }
        public int? BookingNo { get; set; }
        public DateTime? BookingDate { get; set; }
        public byte[] EmiratesId { get; set; }
        public string BookingType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string LocationDesc { get; set; }
        public int? BookingStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual BookingStatus BookingStatusNavigation { get; set; }
    }
}
