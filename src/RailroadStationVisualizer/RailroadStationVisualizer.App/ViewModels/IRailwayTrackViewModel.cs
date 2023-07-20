using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// ViewModel ЖД пути
    /// </summary>
    public interface IRailwayTrackViewModel
    {
        /// <summary>
        /// Парк
        /// </summary>
        string Park { get; }

        /// <summary>
        /// Набор отреззков
        /// </summary>
        ObservableCollection<IRailwaySectionViewModel> Sections { get; }
    }
}