using Application.DTO;
using Domain;

namespace Application.UseCase
{
    public class GtinResultProcessor
    {
        public GtinResult Processar(ResponseDefault<retConsGTIN> response)
        {
            return new GtinResult
            {
                GTIN = response.Dados.GTIN.ToString(),
                Produto = response.Dados.xProd,
                NCM = response.Dados.NCM.ToString(),
                CEST = response.Dados.CEST.ToString(),
                Mensagem = response.Dados.xMotivo,
            };
        }
    }
}
