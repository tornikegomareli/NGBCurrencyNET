using System;
using NBGCurrency.Configuration;

namespace NBGCurrency.Extensions
{
    internal static class CurrencyEnumExtension
    {
        internal static string ToStr(this CurrencyEnumCodes currencyEnumCode)
        {
            return Constants.CurrencyCodes[currencyEnumCode];
		}
    }
}
