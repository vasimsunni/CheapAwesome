using CheapAwesome.Service.DTOs;
using CheapAwesome.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CheapAwesome.Service.Services
{
    public class BargainsForCouplesDataService : IBargainsForCouplesDataService
    {
        static string BASEURL = "https://webbedsdevtest.azurewebsites.net/api/";
        static string CODE = "aWH1EX7ladA8C/oWJX5nVLoEa4XKz2a64yaWVvzioNYcEo8Le8caJw==";

        public IEnumerable<BargainsForCouplesDTO> FindBargains(int destinationId, int totalOfNights)
        {
            string URL = BASEURL + "findBargain?destinationId=" + destinationId + "&nights=" + totalOfNights + "&code=" + CODE;


            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Method = "GET";
                request.ContentType = "application/json";

                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();

                if (!string.IsNullOrEmpty((string)response))
                {
                    return JsonConvert.DeserializeObject<IEnumerable<BargainsForCouplesDTO>>(response);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Server ("+ BASEURL + ") API failed to fetch data.");
            }
            return null;
        }
    }
}
