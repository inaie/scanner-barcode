using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Bar_Code01.Services;
using ZXing.Mobile;

[assembly: Dependency(typeof(Bar_Code01.iOS.Services.QrCodeScannigService))]
namespace Bar_Code01.iOS.Services
{
    public class QrCodeScannigService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var scanner = new MobileBarcodeScanner()
            {
                TopText = "Aproxime a tela do código de barra",
                BottomText = "Toque na tela para focar"
            };
            var scanResults = await scanner.Scan();

            return(scanResults != null) ? scanResults.Text : string.Empty;
        }
    }
}