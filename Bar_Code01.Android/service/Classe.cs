using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bar_Code01.Services;
using Xamarin.Forms;
using ZXing.Mobile;
                                                          //onde vai estar o arquivo no projeto android 

[assembly: Dependency(typeof(Bar_Code01.Droid.Services.QrCodeScannigService))]
namespace Bar_Code01.Droid.Services  
{
    public class QrCodeScannigService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsCustom = new MobileBarcodeScanningOptions()
            {
                //Aqui foi resolvido o bug da camera frontal 
                UseFrontCameraIfAvailable = false
            };
            var scanner = new MobileBarcodeScanner()
            {

                TopText = "Aproxime a câmera no código de barra",
                BottomText = "Toque na tela para focar"

            };
            var scanResults = await scanner.Scan(optionsCustom);


            return (scanResults != null) ? scanResults.Text : String.Empty;
        }
    }
}