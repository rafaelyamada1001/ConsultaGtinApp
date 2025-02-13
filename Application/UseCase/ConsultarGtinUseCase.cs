using Application.DTO;
using Application.Interface;
using Domain;

namespace Application.UseCase
{
    public class ConsultarGtinUseCase
    {
        private readonly IConsGtinService _consGtinService;


        public ConsultarGtinUseCase(IConsGtinService consGtinService)
        {
            _consGtinService = consGtinService;
        }

        public async Task<GtinResult> ExecuteAsync(string gtin)
        {
            var response = await _consGtinService.ConsultarGtinAsync(gtin);
            if (!response.Sucesso) return null;

            var ret = response.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

            return new GtinResult(ret.GTIN, ret.xProd, ret.NCM, ret.CEST, ret.xMotivo);
        }
    }
}
