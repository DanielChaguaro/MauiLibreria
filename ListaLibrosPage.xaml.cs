using MauiLibreria.Models;
using MauiLibreria.Services;
using System.Collections.ObjectModel;

namespace MauiLibreria;

public partial class ListaLibrosPage : ContentPage
{
    ObservableCollection<Libros> libros;
    private readonly consumo _ApiService;
    public ListaLibrosPage(consumo apiService)
    {
        InitializeComponent();
        _ApiService = apiService;
    }
    protected async override void OnAppearing()
    {
        base.OnAppearing();
        List<Libros> ListaLibros = await _ApiService.GetLibros();
        libros = new ObservableCollection<Libros>(ListaLibros);
        listaLibros.ItemsSource = libros;
    }
    private async void OnClickShowDetail(object sender, SelectedItemChangedEventArgs e)
    {
        Libros libro = e.SelectedItem as Libros;
        await Navigation.PushAsync(new DetailsPage(_ApiService)
        {
            BindingContext = libro,
        });
    }
    private async void OnClickPrestamo(object sender, SelectedItemChangedEventArgs e)
    {
        await Navigation.PushAsync(new PrestamosPage(_ApiService));
    }
}