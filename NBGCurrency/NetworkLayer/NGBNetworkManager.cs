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

namespace NBGCurrency.NetworkLayer
{
    public class NGBNetworkManager
    {
        private NGBNetworkManager()
        {
        }

        private static NGBNetworkManager _instance;
        private static volatile object _rootLock = new object();

        public static NGBNetworkManager SharedInstance
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

        public async Task<string> CreateSoapEnvelope()
        {
            string soapString = @"<?xml version=""1.0"" encoding=""utf-8""?>
          <Envelope xmlns=""http://schemas.xmlsoap.org/soap/envelope/"">
              <Body>
                 <GetCurrency xmlns=""urn: NBGCurrency"">
                      <code>USD</code >
                 </GetCurrency >
              </Body>
          </Envelope>";

            HttpResponseMessage response = await PostXmlRequest(Constants.NGBPhpServerApiUrl, soapString);
            string content = await response.Content.ReadAsStringAsync();

            return content;
        }

        public static async Task<HttpResponseMessage> PostXmlRequest(string baseUrl, string xmlString)
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