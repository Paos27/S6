using S6.Views;

namespace S6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.vEstudiante();
        }
    }
}
