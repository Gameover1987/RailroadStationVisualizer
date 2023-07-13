using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwayTrackViewModel
    {
        string Name { get; }

        ObservableCollection<IRailwaySectionViewModel> Sections { get; }
    }
}