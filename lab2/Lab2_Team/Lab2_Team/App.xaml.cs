namespace Lab2_Team
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        // Как в задаче 2: окно сразу открывает MainPage (это FlyoutPage), AppShell не нужен
        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage());
        }
    }
}
