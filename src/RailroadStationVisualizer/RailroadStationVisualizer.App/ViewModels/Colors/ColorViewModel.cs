using System.Windows.Media;

namespace RailroadStationVisualizer.App.ViewModels.Colors
{
    /// <summary>
    /// ViewModel для цвета, дабы показывать человеческие названия цветов, например
    /// </summary>
    public class ColorViewModel
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Цвет
        /// </summary>
        public Color Color { get; set; }
    }
}