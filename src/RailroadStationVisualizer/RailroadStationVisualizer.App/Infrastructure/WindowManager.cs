using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.Views;
using System.Windows;

namespace RailroadStationVisualizer.App.Infrastructure
{
    /// <summary>
    /// Менеджер для управления окнами программы
    /// </summary>
    public sealed class WindowManager : IWindowManager
    {
        /// <summary>
        /// Показать окно поиска пути между участками
        /// </summary>
        public void ShowFindPathWindow(IFindPathViewModel findPathViewModel) {
            var window = new FindPathWindow();
            window.DataContext = findPathViewModel;
            window.Owner = Application.Current?.MainWindow;
            window.ShowDialog();
        }

        /// <summary>
        /// Показать окно сс сообщением
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        public MessageBoxResult ShowMessageBox(string caption, string message) {
            return MessageBox.Show(App.Current.MainWindow, message, caption, MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }
}