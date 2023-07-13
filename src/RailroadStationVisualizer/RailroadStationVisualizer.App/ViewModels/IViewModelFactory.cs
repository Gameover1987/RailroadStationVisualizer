using RailroadStationVisualizer.App.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IViewModelFactory
    {
        IParkViewModel CreateParkViewModel(RailwayPark railwayPark);

        IRailwayTrackViewModel CreateTrackViewModel(RailwayTrack railwayTrack);

        IRailwaySectionViewModel CreateSectionViewModel(RailwaySection railwaySection);
    }
}
