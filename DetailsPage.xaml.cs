using MauiLibreria.Models;
using MauiLibreria.Services;
namespace MauiLibreria;

public partial class DetailsPage : ContentPage
{
    public Libros _libro;
    private readonly consumo _ApiService;
    public DetailsPage(consumo apiService)
    {
        InitializeComponent();
        _ApiService = apiService;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _libro = BindingContext as Libros;
        Nombre.Text = _libro.Nombre;
        Autor.Text = _libro.Autor;
        Cantidad.Text = _libro.Cantidad.ToString();
        Precio.Text = _libro.Precio.ToString();
    }
    private async void OnClickRegresarMain(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}