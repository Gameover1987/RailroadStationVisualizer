namespace RailroadStationVisualizer.App.ViewModels.Colors
{
    /// <summary>
    /// Поставщик цветов для заливки
    /// </summary>
    public class FillColorsProvider : IFillColorsProvider
    {
        /// <summary>
        /// Возвращает коллекцию цветов для заливки
        /// </summary>
        /// <returns></returns>
        public ColorViewModel[] GetColors() {
            return new[] {
                new ColorViewModel { Color = System.Windows.Media.Colors.Red, Name = "Красный" },
                new ColorViewModel { Color = System.Windows.Media.Colors.Orange, Name = "Оранжевый" },
                new ColorViewModel { Color = System.Windows.Media.Colors.Yellow, Name = "Желтый" },
                new ColorViewModel { Color = System.Windows.Media.Colors.Green, Name = "Зеленый" },
                new ColorViewModel { Color = System.Windows.Media.Colors.LightBlue, Name = "Голубой" },
                new ColorViewModel { Color = System.Windows.Media.Colors.Blue, Name = "Синий" },
                new ColorViewModel { Color = System.Windows.Media.Colors.Violet, Name = "Фиолетовый" }
            };
        }
    }
}