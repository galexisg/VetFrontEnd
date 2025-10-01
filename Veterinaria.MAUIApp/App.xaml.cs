namespace Veterinaria.MAUIApp
{
    public partial class App : Application
    {
        public static string Token { get; set; } = string.Empty;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}
