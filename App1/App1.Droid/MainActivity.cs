using System;
using Android.App;
using Android.Content.PM;
using Android.Content;
using Android.OS;
using Xamarin.Forms.Platform.Android.AppLinks;

namespace App1.Droid
{
    [Activity(Label = "App1", Theme = "@style/MainTheme", MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(new[] {Intent.ActionView}, Categories = new [] {Intent.CategoryDefault, Intent.CategoryBrowsable},
        DataScheme = "cirroByTsd",
        AutoVerify = true)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            if (this.Intent.Data != null)
            {
                var data = this.Intent.Data.ToString();
                data = data.Replace("cirroByTsd://", "https://tsdweb.com/?q=");
                this.Intent.SetData(Android.Net.Uri.Parse(data));
            }
            LoadApplication(new App());

        }

        protected override void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);
        }
    }
}