using RailroadStationVisualizer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IViewModelFactory
    {
        IParkViewModel CreateParkViewModel(RailwayPark railwayPark);
    }

    public sealed class ViewModelFactory : IViewModelFactory
    {
        public IParkViewModel CreateParkViewModel(RailwayPark railwayPark) {
            if (railwayPark == null) {
                throw new ArgumentNullException(nameof(railwayPark));
            }

            return new ParkViewModel(railwayPark);
        }
    }
}
