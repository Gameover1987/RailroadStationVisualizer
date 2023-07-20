using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.Views;

namespace RailroadStationVisualizer.App.Infrastructure
{
    /// <summary>
    /// Менеджер для управления окнами программы
    /// </summary>
    public sealed class WindowManager : IWindowManager
    {
        private readonly IFindPathViewModel findPathViewModel;

        public WindowManager(IFindPathViewModel findPathViewModel) {
            this.findPathViewModel = findPathViewModel;
        }

        /// <summary>
        /// Показать окно поиска пути между участками
        /// </summary>
        public void ShowFindPathWindow() {
            var window = new FindPathWindow();
            window.DataContext = findPathViewModel;
            window.Owner = System.Windows.Application.Current?.MainWindow;
            window.ShowDialog();
        }
    }
}