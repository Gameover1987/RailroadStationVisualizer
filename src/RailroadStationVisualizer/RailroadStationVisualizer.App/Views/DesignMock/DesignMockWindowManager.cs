using RailroadStationVisualizer.App.Infrastructure;
using RailroadStationVisualizer.App.ViewModels;
using System.Windows;

namespace RailroadStationVisualizer.App.Views.DesignMock
{
    internal sealed class DesignMockWindowManager : IWindowManager {
        public void ShowFindPathWindow(IFindPathViewModel findPathViewModel) => throw new System.NotImplementedException();
        public MessageBoxResult ShowMessageBox(string caption, string message) => throw new System.NotImplementedException();
    }
}