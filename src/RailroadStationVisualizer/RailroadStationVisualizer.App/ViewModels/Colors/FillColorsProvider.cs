namespace RailroadStationVisualizer.App.ViewModels.Colors
{
    public class FillColorsProvider : IFillColorsProvider
    {
        public ColorViewModel[] GetColors() {
            return new ColorViewModel[] {
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