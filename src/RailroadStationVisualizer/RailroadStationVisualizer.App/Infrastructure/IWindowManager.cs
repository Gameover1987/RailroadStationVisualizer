using RailroadStationVisualizer.App.ViewModels;
using System.Windows;

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
        void ShowFindPathWindow(IFindPathViewModel findPathViewModel);

        /// <summary>
        /// Показать окно сс сообщением
        /// </summary>
        /// <param name="caption"></param>
        /// <param name="message"></param>
        MessageBoxResult ShowMessageBox(string caption, string message);
    }
}
