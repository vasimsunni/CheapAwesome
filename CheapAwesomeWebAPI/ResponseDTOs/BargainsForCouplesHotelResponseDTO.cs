using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeWebAPI.ResponseDTOs
{
    public class BargainsForCouplesHotelResponseDTO
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public int GeoId { get; set; }
        public int Rating { get; set; }
    }
}
