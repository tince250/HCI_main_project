using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    class LocationService
    {
        private const string BingMapsApiKey = "Kj3TXYFWtOhdSJsEwaRg~MYtBweETdCEyT2r6ULdioA~AnDgeIBQnE12E3dWCqRoZDwCljaffq0SmrInOH5-FEHBGfLzqbwDBsLm0ewXkMHy";

        public async Task<string> GetAddress(double latitude, double longitude)
        {
            var client = new RestClient("http://dev.virtualearth.net");
            var request = new RestRequest("REST/v1/Locations/{latitude},{longitude}", Method.Get);
            request.AddParameter("latitude", latitude);
            request.AddParameter("longitude", longitude);
            request.AddParameter("key", BingMapsApiKey);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JObject.Parse(response.Content);
                var address = content["resourceSets"][0]["resources"][0]["address"]["addressLine"].ToString();
                return address;
            }
            else
            {
                // Handle API error
                return null;
            }
        }
    }
}
