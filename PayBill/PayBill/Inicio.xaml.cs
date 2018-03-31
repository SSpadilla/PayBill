using System;
using Xamarin.Forms;

namespace PayBill
{
    public partial class Inicio : ContentPage
    {
        //Pregunta si desea salir al presionar el boton atras
        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await this.DisplayAlert("Alerta", "¿Deseas salir?", "Si", "No");//Guarda la informacion de la alerta
                if (result) Android.OS.Process.KillProcess(Android.OS.Process.MyPid());//Si es positiva cierra el proceso
            });
            return true;//sino se selcciona nada, el programa no se cierra
        }

        //Inicia una MenuPage al pulsar boton
        private void InicioBoton_Clicked(object sender, EventArgs e) => Navigation.PushModalAsync(new MenuPage());

        //Constructor
        public Inicio() => InitializeComponent();
    }
}
