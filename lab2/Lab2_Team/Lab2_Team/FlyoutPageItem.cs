namespace Lab2_Team
{
    // Пункт меню (как в задаче 2): название, иконка и страница, которую надо открыть
    public class FlyoutPageItem
    {
        public string Title { get; set; } = string.Empty;
        public string IconSource { get; set; } = string.Empty;
        public Type TargetType { get; set; } = typeof(Page);
    }
}
