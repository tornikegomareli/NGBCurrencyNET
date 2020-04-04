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

            HttpResponseMessage response = await PostXmlRequest("http://nbg.gov.ge/currency_service.php", soapString);
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

public static class SOAPHelper
{
    /// <summary>
    /// Sends a custom sync SOAP request to given URL and receive a request
    /// </summary>
    /// <param name="url">The WebService endpoint URL</param>
    /// <param name="action">The WebService action name</param>
    /// <param name="parameters">A dictionary containing the parameters in a key-value fashion</param>
    /// <param name="soapAction">The SOAPAction value, as specified in the Web Service's WSDL (or NULL to use the url parameter)</param>
    /// <param name="useSOAP12">Set this to TRUE to use the SOAP v1.2 protocol, FALSE to use the SOAP v1.1 (default)</param>
    /// <returns>A string containing the raw Web Service response</returns>
    public static string SendSOAPRequest(string url, string action, Dictionary<string, string> parameters, string soapAction = null, bool useSOAP12 = false)
    {

        WebRequest webRequest = WebRequest.Create(Constants.MainWsdlUrl);
        HttpWebRequest httpRequest = (HttpWebRequest)webRequest;
        httpRequest.Method = "POST";
        httpRequest.ContentType = "text/xml; charset=utf-8";
        httpRequest.Headers.Add($"SOAPAction:{Constants.MainWsdlUrl}" + "GetCurrency");
        httpRequest.ProtocolVersion = HttpVersion.Version11;
        httpRequest.Credentials = CredentialCache.DefaultCredentials;
        Stream requestStream = httpRequest.GetRequestStream();
        //Create Stream and Complete Request             
        StreamWriter streamWriter = new StreamWriter(requestStream, Encoding.ASCII);

        StringBuilder soapRequest = new StringBuilder("<soap:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"");
        soapRequest.Append(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
        soapRequest.Append("xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\"><soap:Body>");
        soapRequest.Append($"<GetCurrency xmlns={Constants.MainWsdlUrl}><message>USD</message></GetCurrency>");
        soapRequest.Append("</soap:Body></soap:Envelope>");

        streamWriter.Write(soapRequest.ToString());
        streamWriter.Close();
        //Get the Response    
        HttpWebResponse wr = (HttpWebResponse)httpRequest.GetResponse();
        StreamReader srd = new StreamReader(wr.GetResponseStream());
        string resulXmlFromWebService = srd.ReadToEnd();
        return resulXmlFromWebService;
    }
}