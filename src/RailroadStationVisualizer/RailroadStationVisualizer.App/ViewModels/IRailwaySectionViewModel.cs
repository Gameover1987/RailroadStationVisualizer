using RailroadStationVisualizer.App.Model;
using System;
using System.Windows;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwaySectionViewModel
    {
        Point Start { get; set; }

        Point End { get; set; }

        string Name { get; set; }
    }

    public class RailwaySectionViewModel : IRailwaySectionViewModel
    {
        public RailwaySectionViewModel(RailwaySection section) {
            if (section == null) {
                throw new ArgumentNullException(nameof(section));
            }

            Start = section.Start;
            End = section.End;
            Name = section.Name;
        }

        public Point Start { get; set; }
        public Point End { get; set; }
        public string Name { get; set; }
    }
}