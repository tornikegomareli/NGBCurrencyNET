using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace NBGCurrency.Extensions
{
    public static class SoapResponseExtensions
    {
        public static string ToValue(this string soapResponse, string actionName)
        {
            XDocument doc = XDocument.Parse(soapResponse);
            XNamespace ns = "urn:NBGCurrency";
            IEnumerable<XElement> responses = doc.Descendants(ns + $"{actionName}Response");

            var rootResponse = responses.First();

            var value = rootResponse.Element("return").Value;

            return value;           
        }
    }
}
