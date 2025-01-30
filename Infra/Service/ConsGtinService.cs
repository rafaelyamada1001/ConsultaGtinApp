using Application.DTO;
using Application.Interface;
using Domain;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Serialization;


namespace Infra.Service
{
    public class ConsGtinService : IConsGtinService
    {
        private readonly string _url;
        private readonly string _soapAction;
        private readonly X509Certificate2 _certificado;

        public ConsGtinService(string url, string soapAction, string certificadoCaminho, string certificadoSenha)
        {
            _url = url;
            _soapAction = soapAction;
            _certificado = new X509Certificate2(certificadoCaminho, certificadoSenha);
        }

        public async Task<ResponseDefault<EnvelopeBody>> ConsultarGtinAsync(string gtin)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    handler.ClientCertificates.Add(_certificado);
                    using (var client = new HttpClient(handler))
                    {
                        string envelope = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<ssoap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns=\"http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin\">" +
                        "<soap:Header/>" +
                        "<soap:Body>" +
                        "<ccgConsGTIN>" +
                        "<nfeDadosMsg>" +
                        "<consGTIN xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"1.00\">" +
                        $"<GTIN>{gtin}</GTIN>" +
                        "</consGTIN>" +
                        "</nfeDadosMsg>" +
                        "</ccgConsGTIN>" +
                        "</soap:Body>" +
                        "</soap:Envelope>";
                        var content = new StringContent(envelope, Encoding.UTF8, "text/xml");
                        content.Headers.Add("SOAPAction", _soapAction);

                        HttpResponseMessage response = await client.PostAsync(_url, content);
                        response.EnsureSuccessStatusCode();

                        string result = await response.Content.ReadAsStringAsync();
                        var envelopeResponse = DeserializeEnvelope(result);
                        
                        return new ResponseDefault<EnvelopeBody>(true, "OK", envelopeResponse.Dados.Body);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ResponseDefault<EnvelopeBody>(false, $"Erro{ex.Message}", null);
            }
        }

        private static ResponseDefault<Envelope>DeserializeEnvelope(string content)
        {
            try
            {
                var serializer = new XmlSerializer(typeof(Envelope));
                using (var reader = new StringReader(content))
                {
                    var data = (Envelope)serializer.Deserialize(reader);

                    return new ResponseDefault<Envelope>(true, "OK", data);
                }
            }
            catch (Exception ex)
            {
                return new ResponseDefault<Envelope>(false, $"Erro:{ex.Message}", null);
            }
        }
    }
}
