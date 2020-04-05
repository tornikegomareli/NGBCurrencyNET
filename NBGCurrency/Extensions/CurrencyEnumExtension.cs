using NBGCurrency.Configuration;

namespace NBGCurrency.Extensions
{
    internal static class CurrencyEnumExtension
    {
        internal static string toEnumString(this CurrencyEnumCodes currencyEnumCode) => Constants.CurrencyCodes[currencyEnumCode];
    }
}
