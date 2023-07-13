using RailroadStationVisualizer.App.Model;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class MainViewModel : IMainViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;

        public MainViewModel(IStationSchemaProvider stationSchemaProvider) {
            this.stationSchemaProvider = stationSchemaProvider ?? throw new ArgumentNullException(nameof(stationSchemaProvider));

        }

        public void Initialize() {

        }
    }
}
