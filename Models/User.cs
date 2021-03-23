using System;
using System.Collections.Generic;

#nullable disable

namespace MiniTaxiBookingApplication.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserType { get; set; }

        public virtual UserType UserTypeNavigation { get; set; }
    }
}
