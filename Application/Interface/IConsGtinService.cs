using Application.DTO;
using Domain;

namespace Application.Interface
{
    public interface IConsGtinService
    {
        Task<ResponseDefault<EnvelopeBody>> ConsultarGtinAsync(string gtin, string envelope);
    }
}
