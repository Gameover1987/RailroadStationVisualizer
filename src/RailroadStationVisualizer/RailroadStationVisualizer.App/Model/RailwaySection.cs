using System.Windows;

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Отрезок ЖД пути
    /// </summary>
    public class RailwaySection
    {
        public RailwaySection(int id, RailwayPoint start, RailwayPoint end, string name = "") {
            Id = id;
            Start = start;
            End = end;
            Name = name;
        }

        public int Id { get; }

        public RailwayPoint Start { get; }

        public RailwayPoint End { get; }

        public string Name { get; }
    }
}