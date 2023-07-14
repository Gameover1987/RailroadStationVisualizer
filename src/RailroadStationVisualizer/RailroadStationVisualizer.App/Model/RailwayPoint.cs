using System;
using System.Text;

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
        }

        public int Id { get; }

        public double X { get; }

        public double Y { get; }

        public string Name { get; }

        // TODO: подумать
        public RailwaySection[] Sections { get; set; }
    }
}