using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class Guest
    {
        public Guest()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int IdGuest { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Discount { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
