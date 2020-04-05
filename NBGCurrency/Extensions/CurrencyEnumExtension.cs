using NBGCurrency.Configuration;

namespace NBGCurrency.Extensions
{
    internal static class CurrencyEnumExtension
    {
        internal static string ToEnumString(this CurrencyEnumCodes currencyEnumCode) => Constants.CurrencyCodes[currencyEnumCode];
    }
}
