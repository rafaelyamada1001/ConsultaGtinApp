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

        public async Task ExecutarAsync(List<GtinResult> lista, string diretorio)
        {
            await criarArquivoServico.CriarCsvAsync(lista, diretorio);
        }
    }
}