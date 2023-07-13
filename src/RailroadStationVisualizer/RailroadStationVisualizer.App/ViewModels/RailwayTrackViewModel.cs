using RailroadStationVisualizer.App.Model;
using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class RailwayTrackViewModel : IRailwayTrackViewModel
    {
        public RailwayTrackViewModel(IViewModelFactory viewModelFactory, RailwayTrack railwayTrack) {
            Name = railwayTrack.Name;

            foreach (var section in railwayTrack.Sections) {
                Sections.Add(viewModelFactory.CreateSectionViewModel(section));
            }
        }

        public string Name { get; }

        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();
    }
}