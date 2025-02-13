using System.Security.Cryptography.X509Certificates;

namespace Application.Interface;
public interface ICertificadoService
{
    X509Certificate2 ObterCertificado(string caminho, string senha);
}

