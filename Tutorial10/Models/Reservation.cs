using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class Reservation
    {
        public Reservation()
        {
            CategoryReservation = new HashSet<CategoryReservation>();
            RoomAssigned = new HashSet<RoomAssigned>();
        }

        public int IdReservation { get; set; }
        public int IdGuest { get; set; }
        public int IdPaymentType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public DateTime? ConfirmationDate { get; set; }
        public decimal Price { get; set; }

        public virtual Guest IdGuestNavigation { get; set; }
        public virtual PaymentType IdPaymentTypeNavigation { get; set; }
        public virtual ICollection<CategoryReservation> CategoryReservation { get; set; }
        public virtual ICollection<RoomAssigned> RoomAssigned { get; set; }
    }
}
