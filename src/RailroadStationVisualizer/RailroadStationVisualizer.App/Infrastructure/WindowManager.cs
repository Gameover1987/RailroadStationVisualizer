using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.Views;

namespace RailroadStationVisualizer.App.Infrastructure
{
    public sealed class WindowManager : IWindowManager
    {
        private readonly IFindPathViewModel findPathViewModel;

        public WindowManager(IFindPathViewModel findPathViewModel) {
            this.findPathViewModel = findPathViewModel;
        }

        public void ShowFindPathWindow() {
            var window = new FindPathWindow();
            window.DataContext = findPathViewModel;
            window.Owner = System.Windows.Application.Current?.MainWindow;
            window.ShowDialog();
        }
    }
}