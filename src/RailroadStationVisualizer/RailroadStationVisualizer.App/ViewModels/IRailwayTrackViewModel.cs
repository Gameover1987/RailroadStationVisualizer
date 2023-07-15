using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwayTrackViewModel
    {
        string Park { get; }

        ObservableCollection<IRailwaySectionViewModel> Sections { get; }
    }
}