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

        public async Task<ResponseDefault<EnvelopeBody>> ExecutarAsync(string gtin)
        {
            return await _consGtinService.ConsultarGtinAsync(gtin);
        }
    }
}
