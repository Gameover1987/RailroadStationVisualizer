using RailroadStationVisualizer.App.Model;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// Фабрика для создания ViewModel-ей
    /// </summary>
    public sealed class ViewModelFactory : IViewModelFactory
    {
        /// <summary>
        /// Создает ViewModel ЖД пути
        /// </summary>
        /// <param name="railwayTrack"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IRailwayTrackViewModel CreateTrackViewModel(RailwayTrack railwayTrack) {
            if (railwayTrack == null) {
                throw new ArgumentNullException(nameof(railwayTrack));
            }

            return new RailwayTrackViewModel(this, railwayTrack);
        }

        /// <summary>
        /// Создает ViewModel отрезка ЖД пути
        /// </summary>
        /// <param name="railwaySection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IRailwaySectionViewModel CreateSectionViewModel(RailwaySection railwaySection) {
            if (railwaySection == null) {
                throw new ArgumentNullException(nameof(railwaySection));
            }

            return new RailwaySectionViewModel(railwaySection);
        }
    }
}