using RailroadStationVisualizer.App.Model;
using System.Windows;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwaySectionViewModel
    {
        int Id { get; }

        string Park { get; }

        RailwayPoint Start { get; }

        RailwayPoint End { get; }

        string DisplayName { get; }

        RailwaySection Model { get; }

        bool IsSelected { get; set; }

        bool IsVisited { get; }

        void Refresh();
    }
}