using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

namespace RailroadStationVisualizer.App.Model
{
    /// <summary>
    /// Точка начала или окончания отрезка ЖД пути
    /// </summary>
    [DebuggerDisplay("ID={Id}, X={X}, Y={Y}")]
    public class RailwayPoint
    {
        public RailwayPoint(int id, double x, double y, string name = "") {
            Id = id;
            X = x;
            Y = y;
            Name = name;
            Sections = new List<RailwaySection>();
        }

        // TODO: В будущем можно запилиить что нибудь более сложное, например GUID, для импорта\экспорта между системами
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// X is X :-))
        /// </summary>
        public double X { get; }

        /// <summary>
        /// Y is Y :-))
        /// </summary>
        public double Y { get; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Связаанные отрезки
        /// </summary>
        public List<RailwaySection> Sections { get; }

        /// <summary>
        /// Преобразуем в ссистемную точку
        /// </summary>
        /// <returns></returns>
        public Point ToPoint() => new Point(X, Y);
    }
}