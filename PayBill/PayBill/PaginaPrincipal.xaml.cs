using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PayBill.AgregarVentana;
namespace PayBill
{
   
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaPrincipal : ContentPage
    {
        //instancia de clase total
        public Total Suma { get; set; } = new Total();

        //clase para el total de cuenta
        public class Total
        {
            public float TotalCuenta { get; set; }

        }

        //clase de los usuarios ingresados
        public class Usuarios
        {
            public String Nombre { set; get; }
            public float Cuenta { set; get; }

        }
 
        //opciones al clickear a un miembro de la lista
        private void PrincipalListaX_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var usuario = e.SelectedItem as Usuarios;
            if (usuario != null)
            {
                for (int j = 0; j < Usuario.Count; j++)
                {
                    if (usuario.Nombre == Usuario[j].Nombre)//Busca al usuario seleccionado
                    {
                        AgregarCuenta.j = j;//Declara el valor de la variable J (El numero del usuario)
                        Navigation.PushModalAsync(new AgregarCuenta()); //llama a la pantalla agregar cuenta
                        ((ListView)sender).SelectedItem = null;//Para que no meustre seleccion
                    }                    
                }
            }
        }

        //Al clicar el boton Agregar avre una nueva venta de agregar
        private void AgregarBoton_Clicked(object sender, EventArgs e) => Navigation.PushModalAsync(new AgregarVentana());

        //Constructor
        public PaginaPrincipal()
        {
            float sumatoria = 0;
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false); //elimina la barra del menu
            PrincipalListaX.ItemsSource = Usuario; //brinda el contexto para el data bindig de los usuarios

            //Brinda la información y el contexto para la suma del total
            for (int j = 0; j < Usuario.Count; j++)
            {
                sumatoria += Usuario[j].Cuenta;
            }
            Suma.TotalCuenta = sumatoria; //declara el total de la suma
            BindingContext = Suma;//brinda la fuente de la suma total
        }
    }
}