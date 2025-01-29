using Application.DTO;
using Application.Interface;
using Domain;

namespace Application.UseCase
{
    public class ConsultarGtinUseCase
    {
        private readonly IConsGtinService _consGtinService;
        private readonly List<string> _gtinsConsultados;

        public ConsultarGtinUseCase(IConsGtinService consGtinService)
        {
            _consGtinService = consGtinService;
            _gtinsConsultados = new List<string>();
        }

        public async Task<ResponseDefault<retConsGTIN>> ExecuteAsync(string gtin)
        {
            if (_gtinsConsultados.Contains(gtin.TrimStart('0')))
            {
                return new ResponseDefault<retConsGTIN>(false, "GTIN já foi consultado", null);
            }
            _gtinsConsultados.Add(gtin);

            var response = await _consGtinService.ConsultarGtinAsync(gtin);
            if (!response.Sucesso) return new ResponseDefault<retConsGTIN>(false, $"{response.Mensagem}", null);

            var ret = response.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;
            if (ret.xProd == null) return new ResponseDefault<retConsGTIN>(false, $" Insira um GTIN válido \n{ret.xMotivo}", null);

            return new ResponseDefault<retConsGTIN>(true, "Ok", ret);
        }

        public async Task<GtinResult> ExecuteIIAsync(string gtin)
        {
            var response = await _consGtinService.ConsultarGtinAsync(gtin);
            if (!response.Sucesso) return null;

            var ret = response.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

            return new GtinResult
            {
                Produto = ret.xProd,
                NCM = ret.NCM,
                CEST = ret.CEST,
                GTIN = ret.GTIN,
                Mensagem = ret.xMotivo
            };
        }
    }
}
