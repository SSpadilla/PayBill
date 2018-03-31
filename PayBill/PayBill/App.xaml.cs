using Xamarin.Forms;
namespace PayBill
{
	public partial class App : Application
	{
        //Constructor
		public App()
		{
            InitializeComponent();
			MainPage = new Inicio();//establece "Inicio" como página inicial
        }
    }
}
