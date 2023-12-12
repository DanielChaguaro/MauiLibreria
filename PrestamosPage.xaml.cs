using MauiLibreria.Services;

namespace MauiLibreria;

public partial class PrestamosPage : ContentPage
{
    private readonly consumo _ApiService;
    public PrestamosPage(consumo apiService)
    {
        InitializeComponent();
        _ApiService = apiService;
    }
}