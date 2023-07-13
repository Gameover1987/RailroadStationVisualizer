using RailroadStationVisualizer.App.Model;
using System;
using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class ParkViewModel : IParkViewModel
    {
        private readonly RailwayPark railwayPark;

        public ParkViewModel(IViewModelFactory viewModelFactory, RailwayPark railwayPark) {
            this.railwayPark = railwayPark ?? throw new ArgumentNullException(nameof(railwayPark));

            foreach (var track in railwayPark.Tracks) {
                Tracks.Add(viewModelFactory.CreateTrackViewModel(track));
            }
        }

        public string Name => railwayPark.Name;

        public ObservableCollection<IRailwayTrackViewModel> Tracks { get; } = new ObservableCollection<IRailwayTrackViewModel>();
    }
}