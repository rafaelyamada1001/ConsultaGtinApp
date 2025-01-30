using Domain;


namespace Application.Interface
{
    public interface ICriarArquivoServico
    {
        Task CriarCsvAsync(List<GtinResult> conteudo, string diretorio);
    }
}
