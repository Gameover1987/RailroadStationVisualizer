using RailroadStationVisualizer.App.Model;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    public sealed class ViewModelFactory : IViewModelFactory
    {
        public IParkViewModel CreateParkViewModel(RailwayPark railwayPark) {
            if (railwayPark == null) {
                throw new ArgumentNullException(nameof(railwayPark));
            }

            return new ParkViewModel(this, railwayPark);
        }

        public IRailwayTrackViewModel CreateTrackViewModel(RailwayTrack railwayTrack) {
            if (railwayTrack == null) {
                throw new ArgumentNullException(nameof(railwayTrack));
            }

            return new RailwayTrackViewModel(this, railwayTrack);
        }

        public IRailwaySectionViewModel CreateSectionViewModel(RailwaySection railwaySection) {
            if (railwaySection == null) {
                throw new ArgumentNullException(nameof(railwaySection));
            }

            return new RailwaySectionViewModel(railwaySection);
        }
    }
}