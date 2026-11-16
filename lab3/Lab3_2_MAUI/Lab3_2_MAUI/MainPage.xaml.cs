namespace Lab3_2_MAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // CheckedChanged срабатывает дважды: у кнопки, которую выбрали (e.Value = true),
        // и у кнопки, с которой выбор сняли (e.Value = false). Реагируем только на первую.
        void OnColorChanged(object? sender, CheckedChangedEventArgs e)
        {
            if (e.Value && sender is RadioButton button)
            {
                colorLabel.Text = $"Ваш любимый цвет: {button.Content}";
            }
        }

        void OnFruitChanged(object? sender, CheckedChangedEventArgs e)
        {
            if (e.Value && sender is RadioButton button)
            {
                fruitLabel.Text = $"Ваш любимый фрукт: {button.Content}";
            }
        }
    }
}
