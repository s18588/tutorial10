using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class Room
    {
        public Room()
        {
            RoomAssigned = new HashSet<RoomAssigned>();
        }

        public int IdRoom { get; set; }
        public string Number { get; set; }
        public int IdCategory { get; set; }

        public virtual Category IdCategoryNavigation { get; set; }
        public virtual ICollection<RoomAssigned> RoomAssigned { get; set; }
    }
}
