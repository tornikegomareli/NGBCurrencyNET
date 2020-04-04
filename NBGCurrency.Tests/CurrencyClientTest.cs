using System;
using System.Threading.Tasks;
using NBGCurrency.Client;
using NUnit.Framework;

namespace NGBCurrency.Tests
{
    public class CurrencyClientTest
    {
        NGBCurrencyClient client;
        [SetUp]
        public void Setup()
        {
            client = NGBCurrencyClient.Shared;
        }

        [Test]
        public async Task Test_Current_Date_Is_Correct()
        {
           var currentValue = await client.GetCurrentDateAsync();
           var currentDateTime = DateTime.Now.Date;

           Assert.AreEqual(currentValue, currentDateTime);
        }

        [Test]
        public async Task Test_Current_Date_Type_Is_DateTime()
        {
            var currentValue = await client.GetCurrentDateAsync();
            var currentDateTime = DateTime.Now.Date;

            Assert.IsInstanceOf(typeof(DateTime), currentValue);
        }

        [Test]
        public async Task Test_Current_Date_Description_Is_String()
        {
            var currentValue = await client.GetCurrencyDescriptionAsync(NBGCurrency.Configuration.CurrencyEnumCodes.USD);

            Assert.IsInstanceOf(typeof(string), currentValue);
        }

        [Test]
        public async Task Test_Current_Date_Description()
        {
            var currentValue = await client.GetCurrencyDescriptionAsync(NBGCurrency.Configuration.CurrencyEnumCodes.USD);
            var expected = "1 აშშ დოლარი";
            Assert.AreEqual(expected, currentValue);
        }
    }
}