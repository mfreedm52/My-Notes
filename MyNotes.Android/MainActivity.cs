using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.App;
using Android.Content.PM;
using Android.OS;
using MyNotes;

namespace MyNotes.Droid
{
    [Activity(Label = "KindleScrape", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
           
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            CookieWebView web = new CookieWebView
            {
                Source = "https://read.amazon.com/notebook",
                HeightRequest = (int)(Resources.DisplayMetrics.HeightPixels * .90),
            };

            MyNotes.DeviceDetails myDevice = new MyNotes.DeviceDetails(Resources.DisplayMetrics.HeightPixels, Resources.DisplayMetrics.WidthPixels);

            LoadApplication(new App(myDevice, web));

        }
    }
}
