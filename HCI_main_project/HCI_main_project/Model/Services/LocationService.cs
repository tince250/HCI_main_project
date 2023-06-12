using HCI_main_project.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HCI_main_project.Model.Services
{
    class LocationService
    {
        private const string BingMapsApiKey = "Kj3TXYFWtOhdSJsEwaRg~MYtBweETdCEyT2r6ULdioA~AnDgeIBQnE12E3dWCqRoZDwCljaffq0SmrInOH5-FEHBGfLzqbwDBsLm0ewXkMHy";
      
        public async void GetAddress(double latitude, double longitude, AddressFormViewModel viewModel)
        {
            var client = new RestClient("http://dev.virtualearth.net");
            string uri = "REST/v1/Locations/" + latitude.ToString() + "," + longitude.ToString();

            var request = new RestRequest(uri, Method.Get);
            request.AddParameter("userIp", "127.0.0.1");
            request.AddParameter("c", "en");
            request.AddParameter("key", BingMapsApiKey);

            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JObject.Parse(response.Content);
                var address = content["resourceSets"][0]["resources"][0]["address"]["addressLine"];
                var city = content["resourceSets"][0]["resources"][0]["address"]["locality"];
                string[] ret = new string[]{ "", "", "", "" };
                if (address != null)
                {
                    string[] tokens = address.ToString().Split(" ");
                    if ((new Regex("^[a-zA-Z]+$")).IsMatch(tokens.Last()))
                    {
                        viewModel.Street = address.ToString().Replace(tokens[0], "").Trim();
                        viewModel.StreetNo = "0";
                    }
                    else
                    {
                        viewModel.Street = address.ToString().Replace(tokens.Last(), "").Replace(tokens[0], "").Trim();
                        viewModel.StreetNo = tokens.Last().Trim();
                    }
                }
                if (city != null)
                {
                    viewModel.City = city.ToString().Trim();
                }
            }
        }

        public async Task<Location> getLocationByAddress(string address, string locality)
        {
            var client = new RestClient("http://dev.virtualearth.net");
            string uri = "REST/v1/Locations";

            var request = new RestRequest(uri, Method.Get);
            request.AddParameter("addressLine", address);
            request.AddParameter("locality", locality);
            request.AddParameter("countryRegion", "RS");
            request.AddParameter("userIp", "127.0.0.1");
            //request.AddParameter("c", "en");
            request.AddParameter("key", BingMapsApiKey);


            var response = await client.ExecuteAsync(request);
            if (response.IsSuccessful)
            {
                var content = JObject.Parse(response.Content);
                var latitude = content["resourceSets"][0]["resources"][0]["point"]["coordinates"][0];
                var longitede = content["resourceSets"][0]["resources"][0]["point"]["coordinates"][1];
                try
                {
                    return new Location(Double.Parse(latitude.ToString()), Double.Parse(longitede.ToString()));
                }
                catch (Exception)
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
