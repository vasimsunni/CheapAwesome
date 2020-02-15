using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CheapAwesome.Service.Interfaces;
using CheapAwesomeWebAPI.Helpers;
using CheapAwesomeWebAPI.ResponseDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheapAwesomeWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BargainsForCouplesController : ControllerBase
    {
        private readonly IBargainsForCouplesDataService bargainsForCouplesDataService;
        private readonly IMapper mapper;

        public BargainsForCouplesController(IBargainsForCouplesDataService bargainsForCouplesDataService, IMapper mapper)
        {
            this.bargainsForCouplesDataService = bargainsForCouplesDataService;
            this.mapper = mapper;
        }

        [HttpGet("FindBargain")]
        public IActionResult FindAndCalculateBargain([FromQuery] int destinationId, int nights)
        {
            ResponseDTO<IEnumerable<BargainsForCouplesResponseDTO>> response = new ResponseDTO<IEnumerable<BargainsForCouplesResponseDTO>>();
            int returnStatusCode = 0;
            bool isSuccess = false;
            IEnumerable<BargainsForCouplesResponseDTO> Response = null;
            string Message = "";
            string ExceptionMessage = "";

            try
            {
                var hotels = bargainsForCouplesDataService.FindBargains(destinationId, nights);

                if (hotels == null || !hotels.Any())
                {
                    Response = null;
                    returnStatusCode = 404;
                    isSuccess = false;
                    Message = "Hotel(s) not found.";
                   
                }
                else
                {
                    //Calculation of rates
                    foreach (var hotel in hotels)
                    {
                        foreach(var rate in hotel.Rates)
                        {
                            if(rate.RateType.Trim()== "PerNight")
                            {
                                rate.Value = rate.Value * nights;
                            }
                        }
                    }

                    var bargainHotel = mapper.Map<IEnumerable<BargainsForCouplesResponseDTO>>(hotels);
                    
                    Response = bargainHotel;
                    returnStatusCode = 200;
                    isSuccess = true;
                    Message = "Hotel(s) fetched successfully";
                }
            }
            catch (Exception ex)
            {
                isSuccess = false;
                returnStatusCode = 500;
                Message = "Failed while fetching data.";
                ExceptionMessage = ex.Message.ToString();
               
            }

            response.StatusCode = returnStatusCode;
            response.IsSuccess = isSuccess;
            response.Response = Response;
            response.Message = Message;
            response.ExceptionMessage = ExceptionMessage;

            return ResponseHelper<IEnumerable<BargainsForCouplesResponseDTO>>.GenerateResponse(response);
        }

    }
}