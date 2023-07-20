namespace RailroadStationVisualizer.App.Infrastructure
{
    /// <summary>
    /// Менеджер для управления окнами программы
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Показать окно поиска пути между участками
        /// </summary>
        void ShowFindPathWindow();
    }
}
