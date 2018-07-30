using eventizr.Helpers;
using eventizr.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace eventizr.Services
{

    public class FbService
    {
        StringsHelper _stringshelper;

        public FbService()
        {
            _stringshelper = new StringsHelper();
        }

        public async Task<Page> GetPageInfo(string url)
        {
            try
            {
                var client = new HttpClient();
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Page>(result);
            }

            catch (Exception ) { return null; }
        }


        public async Task<FbToken> GetFbToken() {
			try
			{
				var client = new HttpClient();
                var url = _stringshelper.CreateTokenRequestUrl();
				var response = await client.GetAsync(url);
				var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FbToken>(result);
			}

			catch (Exception) { return null; }
		}



        public async Task<Event> GetPageEvents(string id)
        {
            try
            {
                var client = new HttpClient();
                var url = await _stringshelper.CreateEventsRequest(id);
                var response = await client.GetAsync(url);
                var result = await response.Content.ReadAsStringAsync();
                var events =  JsonConvert.DeserializeObject<Event>(result);
                return events;
            }

            catch (Exception)
            {
                return new Event();
            }
        }


    }
}
