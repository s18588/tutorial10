using System;
using System.Collections.Generic;

namespace Tutorial10.Models
{
    public partial class Category
    {
        public Category()
        {
            CategoryReservation = new HashSet<CategoryReservation>();
            Room = new HashSet<Room>();
        }

        public int IdCategory { get; set; }
        public string Category1 { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<CategoryReservation> CategoryReservation { get; set; }
        public virtual ICollection<Room> Room { get; set; }
    }
}
