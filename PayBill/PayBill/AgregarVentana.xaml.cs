using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PayBill.PaginaPrincipal;

namespace PayBill
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarVentana : ContentPage
    {
        public static int i = 0;
        public static List<Usuarios> Usuario = new List<Usuarios>();//Instancia la clase de Usuarios princiapl

        //No realiza Accion se se ingresa el boton cancelar
        private void CancelarBoton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        //Guarda o no los datos ingresados
        private void AceptarBoton_Clicked(object sender, EventArgs e)
        {
            int count = 0;
            String NombreTemporal = NombreEntrada.Text;
   
            if (string.IsNullOrEmpty(NombreTemporal))
            {
                DisplayAlert("Error", "Agrega un Nombre", "Aceptar");//Alerta por si el nombre se encuentra vacía
            }
            else
            {

                //busca si el usuario ya existe
                for (int j = 0; j < Usuario.Count; j++)
                {
                    if (NombreTemporal == Usuario[j].Nombre)
                    {
                        count = 1;
                    }
                }
             if(count == 1)
                {
                    DisplayAlert("Error", "El usuario ya existe", "Aceptar");//Alerta por si el nombre de usuario ya existe
                }
                else {
                    String CuentaTemporal = CuentaEntrada.Text;
                    if (string.IsNullOrEmpty(CuentaTemporal))
                    {
                        CuentaTemporal = "0";//Si no se ingresan datos a la cuenta esta se inicia en 0
                    }
                    Usuarios Data = new Usuarios//Instancia una clase usuarios (temporal)
                    {
                        Nombre = NombreTemporal,
                        Cuenta = float.Parse(CuentaTemporal)
                    };
                    Usuario.Add(Data);//Se agrega a la Clase de usuario Principal

                    //Cierra las ventanas creadas y recarga una nueva MenuPage
                    Navigation.PopModalAsync();
                    Navigation.PopModalAsync();
                    Navigation.PushModalAsync(new MenuPage());
                }  
            }
        }

        //constructor
        public AgregarVentana() => InitializeComponent();
    }
}