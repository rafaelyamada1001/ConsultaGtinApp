using Application.Interface;
using Domain;

namespace Application.UseCase
{
    public class ConsultarGtinUseCase
    {
        private readonly IConsGtinService _consGtinService;
        private readonly ISoapEnvelopeBuilder _envelope;


        public ConsultarGtinUseCase(IConsGtinService consGtinService, ISoapEnvelopeBuilder envelope)
        {
            _consGtinService = consGtinService;
            _envelope = envelope;
        }

        public async Task<GtinResult> ExecuteAsync(string gtin)
        {
 
            var envelope = _envelope.CreateGtinEnvelope(gtin);

            var response = await _consGtinService.ConsultarGtinAsync(gtin, envelope);
            if (!response.Sucesso) return null;

            var ret = response.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

            return new GtinResult(ret.GTIN, ret.xProd, ret.NCM, ret.CEST, ret.xMotivo);
        }
    }
}
