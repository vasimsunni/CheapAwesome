using System;
using System.Collections.Generic;
using System.Text;

namespace CheapAwesome.Service.DTOs
{
    public class BargainsForCouplesDTO
    {
            public BargainsForCouplesHotelDTO Hotel { get; set; }
            public IEnumerable<BargainsForCouplesHotelRateDTO> Rates { get; set; }
    }
}
