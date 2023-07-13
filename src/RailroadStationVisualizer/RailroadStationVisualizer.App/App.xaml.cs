using Microsoft.Extensions.DependencyInjection;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
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

        private void MainWindowOnClosed(object sender, EventArgs e) {
            serviceProvider.Dispose();

            App.Current.Shutdown(0);
        }

        private ServiceProvider RegisterDependencies() {
            IServiceCollection serviceCollection = new ServiceCollection();

            serviceCollection
                .AddSingleton<IStationSchemaProvider, StationSchemaProvider>()
                .AddSingleton<IMainViewModel, MainViewModel>();

            return serviceCollection.BuildServiceProvider();
        }

        private void CommandException(object? sender, ExceptionEventArgs e) {
            Console.WriteLine(e.Exception);
        }
    }
}
