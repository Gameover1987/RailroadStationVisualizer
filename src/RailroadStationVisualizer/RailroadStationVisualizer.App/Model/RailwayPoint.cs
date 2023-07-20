using System.Collections.Generic;
using System.Windows;

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Точка начала или окончания ЖД пути
    /// </summary>
    public class RailwayPoint
    {
        public RailwayPoint(int id, double x, double y, string name = "") {
            Id = id;
            X = x;
            Y = y;
            Name = name;
            Sections = new List<RailwaySection>();
        }

        public int Id { get; }

        public double X { get; }

        public double Y { get; }

        public string Name { get; }

        public List<RailwaySection> Sections { get; }

        public Point ToPoint() => new Point(X, Y);

        public override string ToString() {
            return $"X = {X}, Y = {Y}";
        }
    }
}