using System;
using System.Threading.Tasks;
using NBGCurrency.Configuration;

namespace NBGCurrency.Client.Interfaces
{
    public interface INGBCurrencyClient
    {
        Task<string> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode);
        Task<string> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode);
        Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode);
        Task<string> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode);
        Task<string> GetDate(CurrencyEnumCodes currencyEnumCode);
    }
}
