using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GrabData
{
    public class RawService
    {
        private readonly INextBusApi _nextBusApi;
        public RawService()
        {
            _nextBusApi = RestService.For<INextBusApi>("http://webservices.nextbus.com/service/publicJSONFeed");
        }
        public async Task<ApiResponse> IndexRouteBusList(string agency, string route)
        {
            try
            {
                var busList = await _nextBusApi.GetVehicleLocations("vehicleLocations", agency, route, "0");
                return busList;
            }
            catch (ValidationApiException validationException)
            {
                // handle validation here by using validationException.Content, 
                // which is type of ProblemDetails according to RFC 7807
            }
            catch (ApiException exception)
            {
                // other exception handling
            }
            return null;
        }
    }
}
