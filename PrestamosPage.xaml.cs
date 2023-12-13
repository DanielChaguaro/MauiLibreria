using MauiLibreria.Models;
using MauiLibreria.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MauiLibreria;

public partial class PrestamosPage : ContentPage
{
    private readonly consumo _ApiService;
    public PrestamosPage(consumo apiService)
    {
        InitializeComponent();
        _ApiService = apiService;
    }
    private async void OnClickRealizarPrestamo(object sender, EventArgs e)
    {
        int Id=Int32.Parse(IdLibro.Text);
        int Cant = Int32.Parse(Cantidad.Text);
        Libros libro = await _ApiService.GetLibro(Id);
        
        int PrecioUnitarioLibro = libro.Precio;
        if (Cant <= libro.Cantidad)
        {
            libro.Cantidad = libro.Cantidad - Cant;

            await _ApiService.PutLibro(libro.IdLibro, libro);
            Prestamo prestamoCreado = new Prestamo
            {
                IdPrestamo = 0,
                IdProducto = Id,
                Cantidad =Cant,
                PrecioUnitario = PrecioUnitarioLibro,
               
            };
            Prestamo prestamo = await _ApiService.PostPrestamo(prestamoCreado);
            await Navigation.PopAsync();
        }
        
        

    }
}