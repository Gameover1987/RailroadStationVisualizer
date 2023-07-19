using RailroadStationVisualizer.App.Model;
using System.Windows;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwaySectionViewModel
    {
        string Park { get; }

        RailwayPoint Start { get; }

        RailwayPoint End { get; }

        string DisplayName { get; }

        RailwaySection ToModel();

        bool IsSelected { get; set; }
    }
}