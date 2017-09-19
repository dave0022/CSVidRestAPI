using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppDAL.Entities
{
    public class Video
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string PricePerDay { get; set; }

        public string Genre { get; set; }

        public List<Order> Orders { get; set; }
    }
}
