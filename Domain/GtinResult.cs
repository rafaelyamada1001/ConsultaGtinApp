namespace Domain
{
    public class GtinResult
    {
        public GtinResult(string gTIN, string produto, string nCM, string cEST, string mensagem)
        {
            GTIN = gTIN;
            Produto = produto;
            NCM = nCM;
            CEST = cEST;
            Mensagem = mensagem;
        }

        public string GTIN { get; set; }
        public string Produto { get; set; }
        public string NCM { get; set; }
        public string CEST { get; set; }
        public string Mensagem { get; set;}
    }
}
