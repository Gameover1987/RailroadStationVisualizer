using RailroadStationVisualizer.App.Model;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    public sealed class ViewModelFactory : IViewModelFactory
    {
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