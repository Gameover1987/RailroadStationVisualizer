using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Model.Algorithms;
using RailroadStationVisualizer.App.ViewModels;

namespace RailroadStationVisualizer.App.Views.DesignMock
{
    internal class DesignMockFindPathViewModel : FindPathViewModel
    {
        public DesignMockFindPathViewModel()
            : base(new StationSchemaProvider(), new ViewModelFactory(), new DijkstraPathFinder(), new DesignMockWindowManager())
        {
            Initialize();
        }
    }
}