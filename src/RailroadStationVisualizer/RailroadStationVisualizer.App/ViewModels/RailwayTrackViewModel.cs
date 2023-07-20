using RailroadStationVisualizer.App.Model;
using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// ViewModel ЖД пути
    /// </summary>
    public class RailwayTrackViewModel : IRailwayTrackViewModel
    {
        public RailwayTrackViewModel(IViewModelFactory viewModelFactory, RailwayTrack railwayTrack) {
            Park = railwayTrack.Park;

            foreach (var section in railwayTrack.Sections) {
                Sections.Add(viewModelFactory.CreateSectionViewModel(section));
            }
        }

        /// <summary>
        /// Парк
        /// </summary>
        public string Park { get; }

        /// <summary>
        /// Набор отрезков
        /// </summary>
        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();
    }
}