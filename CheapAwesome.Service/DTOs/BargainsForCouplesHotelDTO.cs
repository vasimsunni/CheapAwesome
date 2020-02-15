using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesome.Service.DTOs
{
    public class BargainsForCouplesHotelDTO
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public int GeoId { get; set; }
        public int Rating { get; set; }
    }
}
