using Application.Interface;
using System.Security.Cryptography.X509Certificates;

namespace Infra.Service;
public class CertificadoService : ICertificadoService
{
    public X509Certificate2 ObterCertificado(string certificadoCaminho, string certificadoSenha)
    {
        return new X509Certificate2(certificadoCaminho, certificadoSenha);
    }
}

