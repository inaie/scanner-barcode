using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using ZXing.Mobile;

namespace Bar_Code01.Droid
                //da linha 10 a 12 foi apenas dividida para uma melhor visualização
{
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