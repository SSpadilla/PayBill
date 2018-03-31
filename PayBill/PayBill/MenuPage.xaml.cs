using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static PayBill.AgregarVentana;

namespace PayBill
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        //metodo que da la funciona de salida
        public void Salir(bool resultado)
        {
            if (resultado == true)
            {
                Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
            }

        }

        //Da funcion a las opciones del menu al ser seleccionadas
        private void MenuListaX_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ((ListView)sender).SelectedItem = null;
            var menu = e.SelectedItem as MenuCelda;
            if (menu != null)
            {
                switch (menu.MenuTitulo)
                {
                    case "Eliminar Cuentas":
                        Usuario.Clear();
                        Navigation.PopModalAsync();
                        Navigation.PushModalAsync(new MenuPage());
                        break;
                    case "Salir":
                        bool resultado = true;

                        //Pregunta si desea salir al pulsar el boton
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var resultadoTemporal = await this.DisplayAlert("Alerta", "Realmente deseas salir", "Si", "no");
                            if (resultadoTemporal)
                            {
                                Salir(resultado);//llama al metodo de salida
                            }

                        });
                        break;
                    case "Acerca de":
                        Navigation.PushModalAsync(new AcercaDe());
                        break;
                }

            }
        }

        //Clase que se utiliza para definir las opciones del menu
        public class MenuCelda
        {
            public string MenuTitulo { get; set; }
            public string MenuDetalle { get; set; }
        }

        //Genera los datos para las opciones del menu
        void MenuInicio()
        {
            List<MenuCelda> MenuLista = new List<MenuCelda>() {
                new MenuCelda{MenuTitulo = "Eliminar Cuentas", MenuDetalle="Elimina todos los datos ingresados"},
                new MenuCelda{MenuTitulo = "Salir", MenuDetalle="Cierra la aplicacion"},
                new MenuCelda{MenuTitulo = "Acerca de", MenuDetalle="Info. del desarrollador"}
            };
            MenuListaX.ItemsSource = MenuLista; //Establece la fuente de las opciones
            Detail = new NavigationPage(new PaginaPrincipal()) { BarTextColor = Color.White, }; //establece PaginaPrincipal como el Detail de la page
        }

        //constructor
        public MenuPage()
        {
            InitializeComponent();
            MenuInicio();
        }
        
    }
}