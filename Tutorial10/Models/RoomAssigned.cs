using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class RoomAssigned
    {
        public int IdRoom { get; set; }
        public int IdReservation { get; set; }

        public virtual Reservation IdReservationNavigation { get; set; }
        public virtual Room IdRoomNavigation { get; set; }
    }
}
