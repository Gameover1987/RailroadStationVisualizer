namespace RailroadStationVisualizer.App.Model.Algorithms
{
    /// <summary>
    /// Визуализатор набора путей принадлежащих заданному парку
    /// </summary>
    public interface IRailwayParkVisualizer
    {
        /// <summary>
        /// Возвращает массив точек для построения фигуры для заливки парка
        /// </summary>
        /// <param name="park"></param>
        /// <param name="sections"></param>
        /// <returns></returns>
        RailwayPoint[] GetParkPoints(string park, RailwaySection[] sections);
    }
}