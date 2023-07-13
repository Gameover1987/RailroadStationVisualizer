using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IParkViewModel
    {
        string Name { get; }

        ObservableCollection<IRailwayTrackViewModel> Tracks { get; }
    }
}