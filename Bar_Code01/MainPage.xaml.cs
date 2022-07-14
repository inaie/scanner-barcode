using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Bar_Code01.Services;

namespace Bar_Code01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private async void Button_OnClicked(object sender, EventArgs e) => await OpenScan();
        private async Task OpenScan()
        {
            var scanner = DependencyService.Get<IQrCodeScanningService>();
            var result = await scanner.ScanAsync();

            if (!string.IsNullOrEmpty(result))
            {
              // a logica da coisa
                var qCode = result;
            }
        }

        private void buttonScan_Clicked(object sender, EventArgs e)
        {

        }
    }
}
