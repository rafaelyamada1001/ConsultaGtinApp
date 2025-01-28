using Application.Interface;
using Domain;

namespace Application.UseCase
{
    public class ExportarConsultaUseCase
    {
        private readonly ICriarArquivoServico criarArquivoServico;

        public ExportarConsultaUseCase(ICriarArquivoServico criarArquivoServico)
        {
            this.criarArquivoServico = criarArquivoServico;
        }

        public void Executar(List<GtinResult> lista, string diretorio)
        {
            criarArquivoServico.CriarCsv(lista, diretorio);
        }
    }
}
