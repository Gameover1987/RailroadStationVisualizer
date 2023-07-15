using RailroadStationVisualizer.App.Model;
using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class RailwayTrackViewModel : IRailwayTrackViewModel
    {
        public RailwayTrackViewModel(IViewModelFactory viewModelFactory, RailwayTrack railwayTrack) {
            Park = railwayTrack.Park;

            foreach (var section in railwayTrack.Sections) {
                Sections.Add(viewModelFactory.CreateSectionViewModel(section));
            }
        }

        public string Park { get; }

        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();
    }
}