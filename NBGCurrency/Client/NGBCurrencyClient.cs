using System;
using System.Threading.Tasks;
using NBGCurrency.Client.Interfaces;
using NBGCurrency.Configuration;

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

        public Task<string> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode)
        {
            throw new NotImplementedException();
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
