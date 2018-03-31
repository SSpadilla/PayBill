using Android.App;
using Android.Content.PM;
using Android.OS;
using Acr.UserDialogs;


namespace PayBill.Droid
{
    [Activity(Label = "PayBill", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle bundle)
        {
            UserDialogs.Init(() => this);

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());

            
        }
    }
}

