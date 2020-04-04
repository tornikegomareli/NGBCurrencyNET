using System;
using System.Collections.Generic;
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
            foreach (XElement response in responses)
            {
                var code = response.Element("return").Value;
            }

            return null;
        }
    }
}
