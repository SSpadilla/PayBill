using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PayBill.AgregarVentana;

namespace PayBill
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AgregarCuenta : ContentPage
	{
        public static int j { get; set; }//Guarda la informacion del usuario que se agregara
    
        //Cierra la ventana al precionar cancelar
        private void CancelarBoton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
        
        //Guarda los cambios ingresados para agregarlos
        private void AceptarBoton_Clicked(object sender, EventArgs e)
        {
            Usuario[j].Cuenta += float.Parse(CuentaAgregar.Text);//Agrega al usuario ingresado la cantidad ingresada (Declarada en el listview de la pagina Principal)

            //Cierra las ventanas creadas y genera una nueva MenuPage
            Navigation.PopModalAsync();
            Navigation.PopModalAsync();
            Navigation.PushModalAsync(new MenuPage());
        }

        //Constructor
        public AgregarCuenta() => InitializeComponent();
    }
}