using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using System.Threading.Tasks;
using Android;
using Xamarin.Forms;
using XamarinEvents.Service;

namespace XamarinEvents.Droid
{
    [Activity(Label = "XamarinEvents", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        const int RequestLocationId = 0;

        readonly string[] PermissionsLocation =
    {
                Manifest.Permission.AccessCoarseLocation,
                Manifest.Permission.AccessFineLocation
            };

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(enableFastRenderer: true);

            TryGetLocation(bundle);
            UserDialogs.Init(this);

            LoadApplication(new App());
        }

        void TryGetLocation(Bundle bundle)
        {
            if ((int)Build.VERSION.SdkInt < 23)
            {
                Xamarin.FormsMaps.Init(this, bundle);
                return;
            }

            GetLocationPermission();
        }

        void GetLocationPermission()
        {
            const string permission = Manifest.Permission.AccessFineLocation;

            if (CheckSelfPermission(permission) == (int)Permission.Granted)
            {
                return;
            }

            if (ShouldShowRequestPermissionRationale(permission))
            {
                //Explain to the user why we need to read the contacts
               // DependencyService.Get<IMessage>().LongAlert("Loading Events...");

                return;
            }

            RequestPermissions(PermissionsLocation, RequestLocationId);

        }
    }
}

