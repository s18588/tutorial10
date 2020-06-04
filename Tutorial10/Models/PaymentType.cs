using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Reservation = new HashSet<Reservation>();
        }

        public int IdPaymentType { get; set; }
        public string PaymentType1 { get; set; }

        public virtual ICollection<Reservation> Reservation { get; set; }
    }
}
