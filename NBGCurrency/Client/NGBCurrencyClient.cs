﻿using System;
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

        public async Task<float> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrency";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return float.Parse(content.ToValue(responseNs));
        }

        public async Task<float> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyChange";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return float.Parse(content.ToValue(responseNs));
        }

        public async Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyDescription";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return content.ToValue(responseNs);
        }

        public async Task<int> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode)
        {
            var responseNs = "GetCurrencyRate";

            var content = await networkLayer.MakeNBGCurrencyEnvelope(responseNs, currencyEnumCode.ToStr());
            return int.Parse(content.ToValue(responseNs));
        }

        public async Task<DateTime> GetCurrentDateAsync()
        {
            var responseNs = "GetDate";

            var content = await networkLayer.MakeNBGDateEnvelope(responseNs);
            DateTime result = (DateTime)Convert.ChangeType(content.ToValue(responseNs), typeof(DateTime));

            return result;
        }
    }
}
