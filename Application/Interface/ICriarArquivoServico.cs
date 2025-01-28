using Domain;


namespace Application.Interface
{
    public interface ICriarArquivoServico
    {
        void CriarCsv(List<GtinResult> conteudo, string diretorio);
    }
}
