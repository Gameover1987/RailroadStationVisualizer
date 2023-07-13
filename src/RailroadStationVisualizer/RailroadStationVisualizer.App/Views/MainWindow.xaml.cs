using RailroadStationVisualizer.App.ViewModels;
using System.Windows;

namespace RailroadStationVisualizer.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IMainViewModel mainViewModel;

        public MainWindow() {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
            mainViewModel = (IMainViewModel) e.NewValue;
            mainViewModel.Initialize();
        }
    }
}
