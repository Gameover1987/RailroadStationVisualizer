using RailroadStationVisualizer.Model;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IParkViewModel
    {
        string Name { get; }
    }

    public class ParkViewModel : IParkViewModel
    {
        private readonly RailwayPark railwayPark;

        public ParkViewModel(RailwayPark railwayPark) {
            this.railwayPark = railwayPark ?? throw new ArgumentNullException(nameof(railwayPark));
        }

        public string Name => railwayPark.Name;
    }
}