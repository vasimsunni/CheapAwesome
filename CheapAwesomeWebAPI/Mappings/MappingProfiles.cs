using AutoMapper;
using CheapAwesome.Service.DTOs;
using CheapAwesomeWebAPI.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheapAwesomeWebAPI.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BargainsForCouplesHotelRateDTO, BargainsForCouplesHotelRateResponseDTO>()
                .ForMember(dest=>dest.Rate,source=> source.MapFrom(src=>src.Value))
             .ReverseMap();

            CreateMap<BargainsForCouplesHotelDTO, BargainsForCouplesHotelResponseDTO>()
              .ReverseMap();

            CreateMap<BargainsForCouplesDTO, BargainsForCouplesResponseDTO>()
            .ReverseMap();
        }
    }
}
