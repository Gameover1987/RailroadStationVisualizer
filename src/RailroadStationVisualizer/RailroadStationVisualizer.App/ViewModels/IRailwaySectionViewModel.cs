using RailroadStationVisualizer.App.Model;
using System;
using System.Windows;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwaySectionViewModel
    {
       string Park { get; }

       RailwayPoint Start { get; }

       RailwayPoint End { get; }
    }

    public class RailwaySectionViewModel : IRailwaySectionViewModel
    {
        private readonly RailwaySection section;

        public RailwaySectionViewModel(RailwaySection section) {
            if (section == null) {
                throw new ArgumentNullException(nameof(section));
            }

            this.section = section;
        }

        public string Park => section?.Track?.Park;

        public RailwayPoint Start => section.Start;

        public RailwayPoint End => section.End;

        public string Name => section.Name;

        public bool HasPark => !string.IsNullOrEmpty(Park);
    }
}