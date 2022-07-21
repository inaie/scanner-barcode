using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ZXing.Mobile;

[assembly: Dependency(typeof(Bar_Code01.iOS.QrCodeScannigService))]
namespace Bar_Code01.iOS
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

            return (scanResults != null) ? scanResults.Text : string.Empty;
        }
    }
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
