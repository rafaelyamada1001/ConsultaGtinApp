using Application.DTO;
using Application.Interface;
using Domain;
using Infra.Serializer;
using System.Security.Cryptography.X509Certificates;
using System.Text;


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

        public async Task<ResponseDefault<EnvelopeBody>> ConsultarGtinAsync(string gtin, string envelope)
        {
            try
            {
                using (var handler = new HttpClientHandler())
                {
                    handler.ClientCertificates.Add(_certificado);
                    using (var client = new HttpClient(handler))
                    {
                        //string envelope = SoapEnvelopeBuilder.CreateGtinEnvelope(gtin);
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

        private static ResponseDefault<Envelope> DeserializeEnvelope(string content)
        {
            try
            {
                var data = EnvelopeSerializer.Deserialize<Envelope>(content);
                return new ResponseDefault<Envelope>(true, "OK", data);
            }
            catch (Exception ex)
            {
                return new ResponseDefault<Envelope>(false, $"Erro:{ex.Message}", null);
            }
        }
    }
}