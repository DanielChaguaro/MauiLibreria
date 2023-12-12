using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiLibreria.Models;
using MauiLibreria.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiLibreria
{
    public partial class MainPage : ContentPage
    {
        private readonly consumo _ApiService;

        public MainPage(consumo apiService)
        {
            InitializeComponent();
            _ApiService = apiService;
        }

        private async void OnClickIniciarSesion(object sender, EventArgs e)
        {
            List<Usuario> usuarios = await _ApiService.GetUsuarios();
            string usuario =Usuario.Text;
            string contrasena = Contrasena.Text;
            bool credencialesValidas = usuarios.Any(u => u.UsuarioP == usuario && u.Contrasena == contrasena);

            if (credencialesValidas)
            {
                await Navigation.PushAsync(new ListaLibrosPage(_ApiService));

            }
            else
            {
                var toast = Toast.Make("Usuario o contrasena incorrectos", ToastDuration.Short, 14);
                await toast.Show();
            }
        }
        private async void OnClickCrearSesion(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CrearUsuarioPage(_ApiService));
        }
    }
}