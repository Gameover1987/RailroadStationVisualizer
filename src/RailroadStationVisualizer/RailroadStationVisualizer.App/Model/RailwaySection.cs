using System.Windows;

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Отрезок ЖД пути
    /// </summary>
    public class RailwaySection
    {
        public Point Start { get; set; }

        public Point End { get; set; }

        public string Name { get; set; }
    }
}