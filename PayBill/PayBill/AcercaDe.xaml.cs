using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Share;//plugin para control de links en botones

namespace PayBill
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AcercaDe : ContentPage
	{
        //abre enlace a github en el navegador
        private void githubBoton_Clicked(object sender, System.EventArgs e) => CrossShare.Current.OpenBrowser("https://github.com/SSpadilla/PayBill");

        //constructor
        public AcercaDe() => InitializeComponent();
    }
}
