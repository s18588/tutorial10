using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class CategoryReservation
    {
        public int IdCategoryReservation { get; set; }
        public int IdCategory { get; set; }
        public int IdReservation { get; set; }
        public int NumberOfRooms { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual Reservation IdReservationNavigation { get; set; }
    }
}
