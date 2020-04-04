using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NBGCurrency.Configuration;
using NBGCurrency.Extensions;

namespace NBGCurrency.NetworkLayer
{
    internal class NGBNetworkManager
    {
        private NGBNetworkManager()
        {
        }

        private static NGBNetworkManager _instance;
        private static volatile object _rootLock = new object();

        internal static NGBNetworkManager SharedInstance
        {
            get 
			{
                if (_instance == null)
                {
                    lock (_rootLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new NGBNetworkManager();
					}
                    }
                }

                return _instance;
            }
		}


        internal async Task<string> MakeNBGDateEnvelope(string actionName)
        {
            string envelopeString = $@"<?xml version=""1.0"" encoding=""utf-8""?>
          <Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
              <Body>
                 <{actionName} xmlns=""urn: NBGCurrency""/>
              </Body>
          </Envelope>";

          HttpResponseMessage response = await XmlRequestAsync(Constants.NGBPhpServerApiUrl, envelopeString);

          string content = await response.Content.ReadAsStringAsync();

          return content;
        }

        internal async Task<string> MakeNBGCurrencyEnvelope(string actionName, string currency) 
		{
            var currentEnvelopeString = CreateNGBSoapEnvelope(actionName, currency);

            HttpResponseMessage response = await XmlRequestAsync(Constants.NGBPhpServerApiUrl, currentEnvelopeString);
            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        internal string CreateNGBSoapEnvelope(string actionName, string currency)
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