using System;
using System.Threading.Tasks;
using NBGCurrency.Configuration;

namespace NBGCurrency.Client.Interfaces
{
    public interface INBGCurrencyClient
    {
        Task<float> GetCurrencyAsync(CurrencyEnumCodes currencyEnumCode);
        Task<float> GetCurrencyChangeAsync(CurrencyEnumCodes currencyEnumCode);
        Task<string> GetCurrencyDescriptionAsync(CurrencyEnumCodes currencyEnumCode);
        Task<int> GetCurrencyRateAsync(CurrencyEnumCodes currencyEnumCode);
        Task<DateTime> GetCurrentDateAsync();
    }
}
