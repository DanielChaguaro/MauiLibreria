using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using MauiLibreria.Models;
using MauiLibreria.Services;

namespace MauiLibreria;

public partial class CrearUsuarioPage : ContentPage
{
    private readonly consumo _ApiService;
    public CrearUsuarioPage(consumo apiService)
	{
		InitializeComponent();
		_ApiService = apiService;
	}
    private async void OnClickCrearUsuario(object sender, EventArgs e)
    {
        List<Usuario> usuarios = await _ApiService.GetUsuarios();
        string usuario = Usuario.Text;
        bool credencialesValidas = usuarios.Any(u => u.UsuarioP == usuario);
        if (credencialesValidas)
        {
            var toast = Toast.Make("Usuario ya fue creado, ingrese otro usuario", ToastDuration.Short, 14);
            await toast.Show();
        }
        else
        {
            var toast = Toast.Make("Usuario creado", ToastDuration.Short, 14);
            await toast.Show();
            Usuario usuarioCreado = new Usuario
            {
                IdUsuario = 0,
                Nombre = Nombre.Text,
                Apellido = Apellido.Text,
                Perfil="cliente",
                UsuarioP = Usuario.Text,
                Contrasena = Contrasena.Text,
            };
            await _ApiService.PostUsuario(usuarioCreado);

            await Navigation.PushAsync(new MainPage(_ApiService));
        }

    }
}