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
    }
}