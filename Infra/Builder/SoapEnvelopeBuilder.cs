namespace Infra.Builder
{
    public static class SoapEnvelopeBuilder
    {
        public static string CreateGtinEnvelope(string gtin)
        {
            return "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
                        "<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns=\"http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin\">" +
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
        }
    }
}
