using Application.Interface;
using Application.UseCase;
using Infra.Builder;
using Infra.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ConsultaGtinApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Configuração do contêiner de serviços
            var services = new ServiceCollection();
            ConfigureServices(services);

            using (var serviceProvider = services.BuildServiceProvider())
            {
                // Resolve o formulário principal
                var cosultaGtinForm = serviceProvider.GetRequiredService<ConsultaGtinForm>();
                System.Windows.Forms.Application.Run(cosultaGtinForm);
            }
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Adicionando dependências específicas
            string url = "https://dfe-servico.svrs.rs.gov.br/ws/ccgConsGTIN/ccgConsGTIN.asmx";
            string soapAction = "http://www.portalfiscal.inf.br/nfe/wsdl/ccgConsGtin/ccgConsGTIN";
            string certificadoCaminho = @"C:\Users\dev4lions1\Desktop\Certificados(atualizado)\SUPERMERCADO CANTARELLAS LTDA00423676000198 - COM VENC 13012026 - SENHA 123456.pfx";
            string certificadoSenha = "123456";

            // Injetando as implementações e casos de uso
            services.AddTransient<ICriarArquivoServico, ArquivoService>();
            services.AddTransient<IConsGtinService>(provider => new ConsGtinService(url, soapAction, certificadoCaminho, certificadoSenha));
            services.AddTransient<ISoapEnvelopeBuilder, SoapEnvelopeBuilder>();
            services.AddTransient<ConsultarGtinUseCase>();
            services.AddTransient<ConsultarListaGtinUseCase>();
            services.AddTransient<ExportarConsultaUseCase>();

            // Registro do formulário principal
            services.AddTransient<ConsultaGtinForm>();
        }
    }
}