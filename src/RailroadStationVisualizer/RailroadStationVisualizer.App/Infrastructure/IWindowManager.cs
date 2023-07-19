using RailroadStationVisualizer.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailroadStationVisualizer.App.Infrastructure
{
    /// <summary>
    /// Менеджер для управления окнами программы
    /// </summary>
    public interface IWindowManager
    {
        /// <summary>
        /// Показать окно поиска пути между участками
        /// </summary>
        void ShowFindPathWindow();
    }
}
