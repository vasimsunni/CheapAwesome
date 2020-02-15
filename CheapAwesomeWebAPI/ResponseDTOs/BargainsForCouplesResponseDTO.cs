using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeWebAPI.ResponseDTOs
{
    public class BargainsForCouplesResponseDTO
    {
        public BargainsForCouplesHotelResponseDTO Hotel { get; set; }
        public IEnumerable<BargainsForCouplesHotelRateResponseDTO> Rates { get; set; }
    }
}
