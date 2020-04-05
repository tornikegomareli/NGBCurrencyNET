using System;
using System.Threading.Tasks;
using NBGCurrency.Client;
using NUnit.Framework;

namespace NBGCurrency.Tests
{
    public class CurrencyClientTest
    {
        NBGCurrencyClient client;
        [SetUp]
        public void Setup()
        {
            client = NBGCurrencyClient.Shared;
        }

        [Test]
        public async Task Test_Current_Date_Is_Correct()
        {
            // This test might fail because the NGB web-server misbehaves and responds with an incorrect timestamp.
            var currentValue = await client.GetCurrentDateAsync();
            var currentDateTime = DateTime.Now.Date;

            Assert.AreEqual(currentValue, currentDateTime);
        }

        [Test]
        public async Task Test_Current_Date_Type_Is_DateTime()
        {
            var currentValue = await client.GetCurrentDateAsync();

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