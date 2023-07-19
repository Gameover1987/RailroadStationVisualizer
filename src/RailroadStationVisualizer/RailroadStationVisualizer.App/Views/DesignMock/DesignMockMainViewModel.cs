using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.ViewModels.Colors;

namespace RailroadStationVisualizer.App.Views.DesignMock
{
    internal sealed class DesignMockMainViewModel : MainViewModel
    {
        public DesignMockMainViewModel() 
            : base(new StationSchemaProvider(), new ViewModelFactory(), new FillColorsProvider(), new DesignMockWindowManager())
        {
            Initialize();
        }
    }
}
