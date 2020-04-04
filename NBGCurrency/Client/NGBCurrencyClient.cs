using System;
using System.Threading.Tasks;
using NBGCurrency.Client.Interfaces;
using NBGCurrency.Configuration;
using NBGCurrency.Extensions;
using NBGCurrency.NetworkLayer;

namespace NBGCurrency.Client
{
    public class NGBCurrencyClient : INGBCurrencyClient
    {
        private static NGBCurrencyClient _instance;
        private static volatile object _rootLock = new object();
        private NGBNetworkManager networkLayer = NGBNetworkManager.SharedInstance;

        public static NGBCurrencyClient Shared
        {
            get
            {
                if (_instance == null)
                {
                    lock (_rootLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NGBCurrencyClient();
                        }
                    }
                }

                return _instance;
            }
        }

        public async Task<string> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrency";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return content.ToValue(responseNs);
        }

        public async Task<string> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyChange";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return content.ToValue(responseNs);
        }

        public async Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyDescription";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return content.ToValue(responseNs);
        }

        public async Task<string> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyRate";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return content.ToValue(responseNs);
        }

        public async Task<string> GetCurrentDateAsync()
        {
            var responseNs = "GetDate";

            var content = await networkLayer.MakeNBGDateEnvelope(responseNs);
            return content.ToValue(responseNs);
        }
    }
}
