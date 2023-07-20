using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IFindPathViewModel
    {
        IRailwaySectionViewModel SectionA { get; set; }

        IRailwaySectionViewModel SectionB { get; set; }

        void Initialize();
    }
}