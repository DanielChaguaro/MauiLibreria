using MauiLibreria.Services;

namespace MauiLibreria
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            consumo apiService = new consumo();
            MainPage = new NavigationPage(new MainPage(apiService));
            
        }
    }
}