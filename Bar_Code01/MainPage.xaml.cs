using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Bar_Code01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void buttonScan_Clicked(object sender, EventArgs e) => await OpenScan();
        //iniciando scanner ao clicar 
        private async Task OpenScan()
        {
            //criando variavel para scanner e result
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();

            if (!string.IsNullOrEmpty(result))
            {
                // toda a lógica do scanner ao ler e capturar o código de barras ou código qr
                //Qrcode captura o result e passa para o ean.Text mostrando
                ////o Ean capturado na tela como forma de texto inalterável em um botão
                var Code = result;
                scan.Text = "Ean:" + Code;
                //retirando a barra azul do xamarin
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }
    }
}
