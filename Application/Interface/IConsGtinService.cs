using Domain;

namespace Application.Interface
{
    public interface IConsGtinService
    {
        Task<EnvelopeBody> ConsultarGtinAsync(string gtin);
    }
}
