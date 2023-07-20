using RailroadStationVisualizer.App.Model;

namespace RailroadStationVisualizer.App.Model.Algorithms
{
    /// <summary>
    /// Алгоритм поиска пути
    /// </summary>
    public interface IPathFinder
    {
        /// <summary>
        /// Возвращает набор участков кратчайшего пути между двумя отрезками
        /// </summary>
        /// <param name="beginSection"></param>
        /// <param name="endSection"></param>
        /// <returns></returns>
        RailwaySection[] GetPathBetweenTwoSections(RailwaySection beginSection, RailwaySection endSection);
    }
}
