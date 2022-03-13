using NUnit.Framework;
using TSD.Linq.Task1.Lib;
using TSD.Linq.Task1.Lib.Model;
using System;
using System.Collections.Generic;

namespace TSD.Linq.Task1.Lib.Test
{
    public class SimpleTests
    {
        GoldClient goldClient;

        [SetUp]
        public void Setup()
        {
            goldClient = new GoldClient();
        }

        [Test]
        public void CurrentPriceNotNullTest()
        {
            GoldPrice currentPrice = goldClient.GetCurrentGoldPrice().GetAwaiter().GetResult();

            Assert.IsNotNull(currentPrice);
            Assert.IsNotNull(currentPrice.Price);
            Assert.Greater(currentPrice.Price, 0.0);
            Assert.AreEqual(DateTime.Now.ToShortDateString(), currentPrice.Date.ToShortDateString());
            

          
        }

        [Test]
        public void GetGoldPricesNotNullTest()
        {
            List<GoldPrice> thisYearPrices = goldClient.GetGoldPrices(new DateTime(2021, 01, 01), new DateTime(2021, 03, 17)).GetAwaiter().GetResult();

            Assert.IsNotNull(thisYearPrices);
            Assert.Greater(thisYearPrices.Count, 0);
        }

        [Test]
        public void Task2() {
            List<GoldPrice> prices = goldClient.getBest3Query();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            prices = goldClient.getBest3Method();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            prices = goldClient.getWorst3Query();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            prices = goldClient.getWorst3Method();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }
        }

        [Test]
        public void Task3() {
            List<GoldPrice> prices1 = goldClient.get005BetterQuery1();
            foreach (GoldPrice price in prices1){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            prices1 = goldClient.get005BetterMethod1();
            foreach (GoldPrice price in prices1){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            List<Tuple<DateTime, List<GoldPrice>>> prices2 = goldClient.get005BetterQuery2();
            foreach (Tuple<DateTime, List<GoldPrice>> price in prices2){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Item1, price.Item2);
            }

            prices2 = goldClient.get005BetterMethod2();
            foreach (Tuple<DateTime, List<GoldPrice>> price in prices2){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Item1, price.Item2);
            }
        }

        [Test]
        public void Task4() {
            List<GoldPrice> prices = goldClient.getBest3ofSecondTenQuery();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }

            prices = goldClient.getBest3ofSecondTenMethod();
            foreach (GoldPrice price in prices){
                System.Console.WriteLine("Date: {0}, Price: {1}", price.Date, price.Price);
            }
        }

        [Test]
        public void hotfixTest(){
            Assert.AreEqual(0, 0);
        }
    }
}