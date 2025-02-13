using Application.Interface;
using Domain;

namespace Infra.Service
{
    public class ArquivoService : ICriarArquivoServico
    {
        public async Task CriarCsvAsync(List<GtinResult> conteudo, string diretorio)
        {
            try
            {
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                string nomeArquivo = $"dados_{DateTime.Now:yyyyMMdd_HHmmss}.csv";
                string caminhoArquivo = Path.Combine(diretorio, nomeArquivo);

                var linhas = new List<string>
                {
                    "GTIN;Produto;NCM;CEST"
                };

                linhas.AddRange(conteudo.Select(item => $"{item.GTIN};{item.Produto};{item.NCM};{item.CEST}"));

                File.WriteAllLines(caminhoArquivo, linhas);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao salvar arquivo CSV: {ex.Message}");
            }
        }
    }
}