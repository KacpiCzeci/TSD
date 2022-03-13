using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TSD.Linq.Task1.Lib.Model;
using System.Linq;
using System.Xml.Linq;

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

        //TASK 3
        public List<GoldPrice> get005BetterQuery1(){
            //Profit over 5% compared to current day
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            GoldPrice current = this.GetCurrentGoldPrice().GetAwaiter().GetResult();
            return (from price in prices where current.Price / price.Price >= 1.05 select price).ToList();
        }

        public List<GoldPrice> get005BetterMethod1(){
            //Profit over 5% compared to current day
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            GoldPrice current = this.GetCurrentGoldPrice().GetAwaiter().GetResult();
            return prices.Where(price => current.Price / price.Price >= 1.05).ToList();
        }

        public List<Tuple<DateTime, List<GoldPrice>>> get005BetterQuery2(){
            //Profit over 5% compared to every other day in January
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            List<Tuple<DateTime, List<GoldPrice>>> all = new List<Tuple<DateTime, List<GoldPrice>>>();
            foreach (GoldPrice day_of_purchase in prices){
                all.Add((day_of_purchase.Date, (from price in prices where day_of_purchase.Price / price.Price >= 1.05 select price).ToList()).ToTuple());
            }
            return all;
        }

        public List<Tuple<DateTime, List<GoldPrice>>> get005BetterMethod2(){
            //Profit over 5% compared to every other day in January
            List<GoldPrice> prices = this.GetGoldPrices(new DateTime(2020, 01, 01), new DateTime(2020, 01, 31)).GetAwaiter().GetResult();
            List<Tuple<DateTime, List<GoldPrice>>> all = new List<Tuple<DateTime, List<GoldPrice>>>();
            foreach (GoldPrice day_of_purchase in prices){
                all.Add((day_of_purchase.Date, prices.Where(price => day_of_purchase.Price / price.Price >= 1.05).ToList()).ToTuple());
            }
            return all;
        }

        //TASK 4
        public List<GoldPrice> getBest3ofSecondTenQuery(){
            List<GoldPrice> prices = new List<GoldPrice>();
            DateTime start = new DateTime(2019, 01, 01);
            DateTime next = new DateTime(2019, 01, 01);
            DateTime end = DateTime.Now;
            int difference = (end-start).Days;
            System.Console.WriteLine(difference);
            while(difference > 0){
                if (difference >= 93){
                    next = next.AddDays(93);
                    prices.AddRange(this.GetGoldPrices(start, next).GetAwaiter().GetResult());
                    start = start.AddDays(93);
                    difference -= 93;
                }
                else{
                    prices.AddRange(this.GetGoldPrices(start, end).GetAwaiter().GetResult());
                    difference -= 93;
                }
            }
            return (from price in prices orderby price.Price descending select price).Skip(10).Take(3).ToList();
        }

        public List<GoldPrice> getBest3ofSecondTenMethod(){
            List<GoldPrice> prices = new List<GoldPrice>();
            DateTime start = new DateTime(2019, 01, 01);
            DateTime next = new DateTime(2019, 01, 01);
            DateTime end = DateTime.Now;
            int difference = (end-start).Days;
            System.Console.WriteLine(difference);
            while(difference > 0){
                if (difference >= 93){
                    next = next.AddDays(93);
                    prices.AddRange(this.GetGoldPrices(start, next).GetAwaiter().GetResult());
                    start = start.AddDays(93);
                    difference -= 93;
                }
                else{
                    prices.AddRange(this.GetGoldPrices(start, end).GetAwaiter().GetResult());
                    difference -= 93;
                }
            }
            return prices.OrderByDescending(price => price.Price).Skip(10).Take(3).ToList();
        }

        //TASK 8
        public List<Tuple<int, double>> averageQuery(){
            List<Tuple<int, double>> averages = new List<Tuple<int, double>>();
            List<int> years = new List<int> {2019, 2020, 2021};
            foreach (int year in years){
                List<GoldPrice> prices = GetGoldPrices(new DateTime(year, 01, 01), new DateTime(year, 12, 31)).GetAwaiter().GetResult();
                averages.Add(new Tuple<int, double>(year, (from price in prices select price.Price).Average()));
            }
            return averages;
        }

        public List<Tuple<int, double>> averangeMethod(){
            List<Tuple<int, double>> averages = new List<Tuple<int, double>>();
            List<int> years = new List<int> {2019, 2020, 2021};
            foreach (int year in years){
                List<GoldPrice> prices = GetGoldPrices(new DateTime(year, 01, 01), new DateTime(year, 12, 31)).GetAwaiter().GetResult();
                averages.Add(new Tuple<int, double>(year, prices.Average(price => price.Price)));
            }
            return averages;
        }

        //TASK 9
        public Tuple<GoldPrice, GoldPrice, double> bestInvestmentBetweenQuery(){
            List<GoldPrice> prices = new List<GoldPrice>();
            DateTime start = new DateTime(2019, 01, 01);
            DateTime next = new DateTime(2019, 01, 01);
            DateTime end = DateTime.Now;
            int difference = (end-start).Days;
            System.Console.WriteLine(difference);
            while(difference > 0){
                if (difference >= 93){
                    next = next.AddDays(93);
                    prices.AddRange(this.GetGoldPrices(start, next).GetAwaiter().GetResult());
                    start = start.AddDays(93);
                    difference -= 93;
                }
                else{
                    prices.AddRange(this.GetGoldPrices(start, end).GetAwaiter().GetResult());
                    difference -= 93;
                }
            }
            GoldPrice best = (from price in prices orderby price.Price descending select price).First();
            GoldPrice worst = (from price in prices orderby price.Price select price).First();
            return (best, worst, best.Price-worst.Price).ToTuple();
        }

        public Tuple<GoldPrice, GoldPrice, double> bestInvestmentBetweenMethod(){
            List<GoldPrice> prices = new List<GoldPrice>();
            DateTime start = new DateTime(2019, 01, 01);
            DateTime next = new DateTime(2019, 01, 01);
            DateTime end = DateTime.Now;
            int difference = (end-start).Days;
            System.Console.WriteLine(difference);
            while(difference > 0){
                if (difference >= 93){
                    next = next.AddDays(93);
                    prices.AddRange(this.GetGoldPrices(start, next).GetAwaiter().GetResult());
                    start = start.AddDays(93);
                    difference -= 93;
                }
                else{
                    prices.AddRange(this.GetGoldPrices(start, end).GetAwaiter().GetResult());
                    difference -= 93;
                }
            }
            GoldPrice best = prices.OrderByDescending(price => price.Price).First();
            GoldPrice worst = prices.OrderBy(price => price.Price).First();
            return new Tuple<GoldPrice, GoldPrice, double>(best, worst, best.Price-worst.Price);
        }

        //TASK 12
        public void saveLINQtoXML(DateTime start, DateTime end){
            List<GoldPrice> prices = GetGoldPrices(start, end).GetAwaiter().GetResult();
            XDocument xml = new XDocument(
                new XComment($"Gold prices from {start.ToString()} to {end.ToString()}"),
                new XElement("GoldPrices",
                    prices.Select(price => new XElement("GoldPrice",
                            new XElement("Date", price.Date.ToString("o")),
                            new XElement("Price", price.Price.ToString())
                        )
                    )
                )
            );
            xml.Save("goldprices.xml"); 
        }
    }
}
