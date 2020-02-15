using CheapAwesome.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CheapAwesome.Service.Interfaces
{
    public interface IBargainsForCouplesDataService
    {
        IEnumerable<BargainsForCouplesDTO> FindBargains(int destinationId, int totalOfNights);
    }
}
