using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStationVisualizer.App.Views.DesignMock
{
    internal class DesignMockFindPathViewModel : FindPathViewModel
    {
        public DesignMockFindPathViewModel()
            : base(new StationSchemaProvider(), new ViewModelFactory())
        {
            Initialize();
        }
    }
}
