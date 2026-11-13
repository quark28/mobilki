namespace Lab2_Team
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
            InitializeComponent();

            // Подписка на выбор пункта меню (как в задаче 2)
            flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;

            // На Windows меню выезжает поверх страницы (как в задаче 2)
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                FlyoutLayoutBehavior = FlyoutLayoutBehavior.Popover;
            }
        }

        // Выбран пункт меню: создаём его страницу и показываем справа (свойство Detail)
        void OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is FlyoutPageItem item)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType)!)
                {
                    BarBackgroundColor = Color.FromArgb("#1A237E"),
                    BarTextColor = Colors.White
                };

                // Сбрасываем выделение, чтобы тот же пункт можно было выбрать снова
                flyoutPage.collectionView.SelectedItem = null;

                // Закрываем меню, показываем выбранную страницу
                IsPresented = false;
            }
        }
    }
}
