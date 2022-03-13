using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TSD.Linq.Task1.Lib.Model;
using System.Linq;

namespace TSD.Linq.Task1.Lib
{
    public class GoldClient
    {
        private HttpClient _client;
        public GoldClient()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://api.nbp.pl/api/");
            _client.DefaultRequestHeaders.Accept.Clear();

        }
        public async Task<GoldPrice> GetCurrentGoldPrice()
        {
            HttpResponseMessage responseMsg = _client.GetAsync("cenyzlota/").GetAwaiter().GetResult();
            if (responseMsg.IsSuccessStatusCode)
            {
                string content = await responseMsg.Content.ReadAsStringAsync();
                List<GoldPrice> prices = JsonConvert.DeserializeObject<List<GoldPrice>>(content);
                if (prices != null && prices.Count == 1)
                {
                    return prices[0];
                }
            }
            return null;
        }

        public async Task<List<GoldPrice>> GetGoldPrices(DateTime startDate, DateTime endDate)
        {
            string dateFormat = "yyyy-MM-dd";
            string requestUri = $"cenyzlota/{startDate.ToString(dateFormat)}/{endDate.ToString(dateFormat)}";
            HttpResponseMessage responseMsg = _client.GetAsync(requestUri).GetAwaiter().GetResult();
            if (responseMsg.IsSuccessStatusCode)
            {
                string content = await responseMsg.Content.ReadAsStringAsync();
                List<GoldPrice> prices = JsonConvert.DeserializeObject<List<GoldPrice>>(content);
                return prices;
            }
            else
            {
                return null;
            }

        }

        //TASK 2
        public List<GoldPrice> getBest3Query() {
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();
            return (from price in prices orderby price.Price descending select price).Take(3).ToList();
        }

        public List<GoldPrice> getBest3Method() {
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();
            return prices.OrderByDescending(price => price.Price).Take(3).ToList();
        }

        public List<GoldPrice> getWorst3Query() {
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();
            return (from price in prices orderby price.Price select price).Take(3).ToList();
        }

        public List<GoldPrice> getWorst3Method() {
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2022, 01, 01), new DateTime(2022, 03, 13)).GetAwaiter().GetResult();
            return prices.OrderBy(price => price.Price).Take(3).ToList();
        }

    }
}
