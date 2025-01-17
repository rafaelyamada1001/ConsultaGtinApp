using Application.UseCase;
using Infra.Service;

namespace ConsultaGtinApp
{
    public partial class Form1 : Form
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
        public Form1()
        {
            InitializeComponent();
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev6\Desktop\Certificados\certificado.pfx";
            string certificadoSenha = "123456";

            var consGtinService = new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha);
            _consultarGtinUseCase = new ConsultarGtinUseCase(consGtinService);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
