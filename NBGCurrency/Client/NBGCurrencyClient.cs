using System;
using System.Threading.Tasks;
using NBGCurrency.Client.Interfaces;
using NBGCurrency.Configuration;
using NBGCurrency.Extensions;
using NBGCurrency.NetworkLayer;

namespace NBGCurrency.Client
{
    public class NBGCurrencyClient : INBGCurrencyClient
    {
        private static readonly Lazy<NBGCurrencyClient> _instance = new Lazy<NBGCurrencyClient>(() => new NBGCurrencyClient());
        private NBGNetworkManager networkLayer = NBGNetworkManager.SharedInstance;

        public static NBGCurrencyClient Shared
        {
            get
            {
                return _instance.Value;
            }
        }

        public async Task<float> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrency";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToEnumString());
            return float.Parse(content.ToValue(responseNs));
        }

        public async Task<float> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyChange";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToEnumString());
            return float.Parse(content.ToValue(responseNs));
        }

        public async Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyDescription";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToEnumString());
            return content.ToValue(responseNs);
        }

        public async Task<int> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyRate";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToEnumString());
            return int.Parse(content.ToValue(responseNs));
        }

        public async Task<DateTimeOffset> GetCurrentDateAsync()
        {
            var responseNs = "GetDate";

            var content = await networkLayer.MakeNBGCurrentDateCall(responseNs);
            var result = DateTimeOffset.Parse(content.ToValue(responseNs));

            return result;
        }
    }
}