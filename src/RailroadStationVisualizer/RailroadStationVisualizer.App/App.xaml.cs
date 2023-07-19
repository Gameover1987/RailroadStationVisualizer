using Microsoft.Extensions.DependencyInjection;
using RailroadStationVisualizer.App.Infrastructure;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.ViewModels.Colors;
using RailroadStationVisualizer.App.Views;
using RailroadStationVisualizer.App.Views.Helpers;
using RailroadStationVisualizer.UI.Commands;
using System;
using System.Windows;

namespace RailroadStationVisualizer.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static ServiceProvider serviceProvider;

        private void App_OnStartup(object sender, StartupEventArgs e) {
            serviceProvider = RegisterDependencies();

            MainWindow = new MainWindow();
            MainWindow.Closed += MainWindowOnClosed;
            DelegateCommand.CommandException += CommandException;
            MainWindow.DataContext = serviceProvider.GetService<IMainViewModel>();
            MainWindow.Show();
        }

        public static ServiceProvider ServiceProvider => serviceProvider;

        private void MainWindowOnClosed(object sender, EventArgs e) {
            serviceProvider.Dispose();

            Current.Shutdown(0);
        }

        private ServiceProvider RegisterDependencies() {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<IStationSchemaProvider, StationSchemaProvider>()
                .AddSingleton<IViewModelFactory, ViewModelFactory>()
                .AddSingleton<IWindowManager, WindowManager>()
                .AddSingleton<IFillColorsProvider, FillColorsProvider>()
                .AddSingleton<IRailwayParkVisualizer, RailwayParkVisualizer>()
                .AddSingleton<IMainViewModel, MainViewModel>()
                .AddSingleton<IFindPathViewModel, FindPathViewModel>();

            return serviceCollection.BuildServiceProvider();
        }

        private void CommandException(object? sender, ExceptionEventArgs e) {
            Console.WriteLine(e.Exception);
        }
    }
}
