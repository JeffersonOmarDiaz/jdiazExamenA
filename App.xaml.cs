namespace jdiazExamenA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Registro("Hola"));
        }
    }
}
