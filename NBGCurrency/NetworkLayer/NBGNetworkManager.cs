using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NBGCurrency.Configuration;

namespace NBGCurrency.NetworkLayer
{
    internal class NBGNetworkManager
    {
        private NBGNetworkManager()
        {
        }

        private static readonly Lazy<NBGNetworkManager> _instance = new Lazy<NBGNetworkManager>(() => new NBGNetworkManager());
        internal static NBGNetworkManager SharedInstance
        {
            get
            {
                return _instance.Value;
            }
        }


        internal async Task<string> MakeNBGCurrentDateCall(string actionName)
        {
            string envelopeString = $@"<?xml version=""1.0"" encoding=""utf-8""?>
          <Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
              <Body>
                 <{actionName} xmlns=""urn: NBGCurrency""/>
              </Body>
          </Envelope>";

            HttpResponseMessage response = await XmlRequestAsync(Constants.NBGPhpServerApiUrl, envelopeString);

            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        internal async Task<string> MakeNBGCurrencyEnvelope(string actionName, string currency)
        {
            var currentEnvelopeString = CreateNBGSoapEnvelope(actionName, currency);

            HttpResponseMessage response = await XmlRequestAsync(Constants.NBGPhpServerApiUrl, currentEnvelopeString);
            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        internal string CreateNBGSoapEnvelope(string actionName, string currency)
        {
            string envelopeString = $@"<?xml version=""1.0"" encoding=""utf-8""?>
          <Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
              <Body>
                 <{actionName} xmlns=""urn: NBGCurrency"">
                      <code>{currency}</code >
                 </{actionName}>
              </Body>
          </Envelope>";

            return envelopeString;
        }

        internal async Task<HttpResponseMessage> XmlRequestAsync(string baseUrl, string xmlString)
        {
            using (var httpClient = new HttpClient())
            {
                var httpContent = new StringContent(xmlString, Encoding.UTF8, "text/xml");
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("text/html");

                return await httpClient.PostAsync(baseUrl, httpContent);
            }
        }
    }
}