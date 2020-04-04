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
            var networklayer = NGBNetworkManager.SharedInstance;
            var content = await networklayer.MakeNGBSoapApiRequestAync("GetCurrency", currencyEnumCode.ToStr());

            return content;
        }

        public Task<string> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetDate(CurrencyEnumCodes currencyEnumCode)
        {
            throw new NotImplementedException();
        }
    }
}
