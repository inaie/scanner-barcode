using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using ZXing.Mobile;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Bar_Code01.Droid.QrCodeScannigService))]
namespace Bar_Code01.Droid


{
    public class QrCodeScannigService : IQrCodeScanningService
    {
        public async Task<string> ScanAsync()
        {
            var optionsCustom = new MobileBarcodeScanningOptions()
            {
                //Para ativar câmera frontal retire o 
                //comentario abaixo e transforme como true
                //  UseFrontCameraIfAvailable = false
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

    //da linha 45 a 48 foi apenas dividida para uma melhor visualização
    [Activity(Label = "Bar_Code01", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, 
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation |
        ConfigChanges.UiMode| ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]

    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle Bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            base.OnCreate(Bundle);
            MobileBarcodeScanner.Initialize(this.Application);
            Xamarin.Essentials.Platform.Init(this, Bundle);
            global::Xamarin.Forms.Forms.Init(this, Bundle);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            global::ZXing.Net.Mobile.Android.PermissionsHandler.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}