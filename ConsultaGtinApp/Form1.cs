using Application.UseCase;
using Domain;
using Infra.Service;
using System.Windows.Forms;

namespace ConsultaGtinApp
{
    public partial class Form1 : Form
    {
        private readonly ConsultarGtinUseCase _consultarGtinUseCase;
        private readonly List<GtinResult> _lista;
        public Form1()
        {
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            var consGtinService = new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha);
            _consultarGtinUseCase = new ConsultarGtinUseCase(consGtinService);

            _lista = new List<GtinResult>();

            InitializeComponent();

            dgvConsultaGtin.AutoGenerateColumns = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblConsultaGtin_Click(object sender, EventArgs e)
        {

        }

        private async void btnConsultaGtin_Click(object sender, EventArgs e)
        {
            try
            {
                string gtin = txtConsultaGtin.Text;

                
                var result = await _consultarGtinUseCase.ExecutarAsync(gtin);

                if (result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN != null)
                {
                    var ret = result.Dados.ccgConsGTINResponse.nfeResultMsg.retConsGTIN;

                    var gtinResult = new GtinResult
                    {
                        GTIN = ret.GTIN.ToString(),
                        Produto = ret.xProd,
                        NCM = ret.NCM.ToString(),
                        CEST = ret.CEST.ToString(),                        
                    };

                    _lista.Add(gtinResult);

                    dgvConsultaGtin.DataSource = _lista.ToList();
                    dgvConsultaGtin.Refresh();
                }
                else
                {
                    MessageBox.Show("Erro ao processar a resposta ou GTIN inválido.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}");
            }
        }

    }
    
}
