namespace Application.DTO
{
    public class ResponseDefault<TData>
    {
        public ResponseDefault(bool sucesso, string mensagem, TData dados)
        {
            Sucesso = sucesso;
            Mensagem = mensagem;
            Dados = dados;
        }

        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public TData Dados { get; set; }

    }
}
