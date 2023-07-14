using RailroadStationVisualizer.App.Model;
using System;
using System.Windows;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IRailwaySectionViewModel
    {
       
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

        public RailwayPoint Start => section.Start;

        public RailwayPoint End => section.End;

        public string Name => section.Name;
    }
}