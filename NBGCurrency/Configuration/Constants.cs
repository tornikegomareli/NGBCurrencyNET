using System;
using System.Collections.Generic;

namespace NBGCurrency.Configuration
{
    internal static class Constants
    {
        internal static string MainWsdlUrl = "http://nbg.gov.ge/currency.wsdl";
        internal static string NBGPhpServerApiUrl = "http://nbg.gov.ge/currency_service.php";

        public static IReadOnlyDictionary<CurrencyEnumCodes, String> CurrencyCodes = new Dictionary<CurrencyEnumCodes, string>()
        {
            {CurrencyEnumCodes.AED, "AED" },
            {CurrencyEnumCodes.AMD, "AMD" },
            {CurrencyEnumCodes.AUD, "AUD" },
            {CurrencyEnumCodes.AZN, "AZN" },
            {CurrencyEnumCodes.BGN, "BGN" },
            {CurrencyEnumCodes.BYR, "BYR" },
            {CurrencyEnumCodes.CAD, "CAD" },
            {CurrencyEnumCodes.CHF, "CHF" },
            {CurrencyEnumCodes.CNY, "CNY" },
            {CurrencyEnumCodes.CZK, "CZK" },
            {CurrencyEnumCodes.DKK, "DKK" },
            {CurrencyEnumCodes.EEK, "EEK" },
            {CurrencyEnumCodes.EGP, "EGP" },
            {CurrencyEnumCodes.EUR, "EUR" },
            {CurrencyEnumCodes.GBP, "GBP" },
            {CurrencyEnumCodes.HKD, "HKD" },
            {CurrencyEnumCodes.HUF, "HUF" },
            {CurrencyEnumCodes.ILS, "ILS" },
            {CurrencyEnumCodes.INR, "INR" },
            {CurrencyEnumCodes.IRR, "IRR" },
            {CurrencyEnumCodes.ISK, "ISK" },
            {CurrencyEnumCodes.JPY, "JPY" },
            {CurrencyEnumCodes.KWD, "KWD" },
            {CurrencyEnumCodes.KZT, "KZT" },
            {CurrencyEnumCodes.LTL, "LTL" },
            {CurrencyEnumCodes.LVL, "LVL" },
            {CurrencyEnumCodes.MDL, "MDL" },
            {CurrencyEnumCodes.NOK, "NOK" },
            {CurrencyEnumCodes.NZD, "NZD" },
            {CurrencyEnumCodes.PLN, "PLN" },
            {CurrencyEnumCodes.RON, "RON" },
            {CurrencyEnumCodes.RUB, "RUB" },
            {CurrencyEnumCodes.SEK, "SEK" },
            {CurrencyEnumCodes.SGD, "SGD" },
            {CurrencyEnumCodes.TJS, "TJS" },
            {CurrencyEnumCodes.TMT, "TMT" },
            {CurrencyEnumCodes.TRY, "TRY" },
            {CurrencyEnumCodes.UAH, "UAH" },
            {CurrencyEnumCodes.USD, "USD" },
            {CurrencyEnumCodes.UZS, "UZS" },
        };
    }
}
