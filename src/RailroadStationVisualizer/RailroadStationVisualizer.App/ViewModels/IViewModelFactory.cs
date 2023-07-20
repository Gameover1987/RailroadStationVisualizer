using RailroadStationVisualizer.App.Model;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IViewModelFactory
    {
        IRailwayTrackViewModel CreateTrackViewModel(RailwayTrack railwayTrack);

        IRailwaySectionViewModel CreateSectionViewModel(RailwaySection railwaySection);
    }
}
