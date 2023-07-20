using RailroadStationVisualizer.App.Model;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// ViewModel отрезка ЖД пути
    /// </summary>
    public interface IRailwaySectionViewModel
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        int Id { get; }

        /// <summary>
        /// Название
        /// </summary>
        string DisplayName { get; }

        /// <summary>
        /// Модель отрезка
        /// </summary>
        RailwaySection Model { get; }

        /// <summary>
        /// Флаг выбора
        /// </summary>
        bool IsSelected { get; set; }

        /// <summary>
        /// Флаг посещаемости (используется для отладки алгоритма поиска пути)
        /// </summary>
        bool IsVisited { get; }

        /// <summary>
        /// Сообщает об изменении значений всех свойств 
        /// </summary>
        void Refresh();
    }
}