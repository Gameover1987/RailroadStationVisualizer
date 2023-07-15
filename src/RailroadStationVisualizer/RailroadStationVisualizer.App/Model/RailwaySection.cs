using System;

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Отрезок ЖД пути
    /// </summary>
    public class RailwaySection
    {
        private const int Precision = 2;

        public RailwaySection(int id, RailwayPoint start, RailwayPoint end, string name = "") {
            Id = id;
            Start = start;
            End = end;
            Name = name;

            var distanceRaw = Math.Sqrt(Math.Pow(Start.X - End.X, 2) + Math.Pow(Start.Y - End.Y, 2));
            Distance = Math.Round(distanceRaw, Precision);

            Start.Sections.Add(this);
            End.Sections.Add(this);
        }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Начало отрезка
        /// </summary>
        public RailwayPoint Start { get; }

        /// <summary>
        /// Конец отрезка
        /// </summary>
        public RailwayPoint End { get; }
        
        /// <summary>
        /// Длина отрезка
        /// </summary>
        public double Distance { get; }

        /// <summary>
        /// Название отрезка
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Путь
        /// </summary>
        public RailwayTrack Track { get; set; }
    }
}