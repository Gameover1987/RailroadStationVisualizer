using RailroadStationVisualizer.App.ViewModels;
using System.Windows;

namespace RailroadStationVisualizer.App.Views
{
    /// <summary>
    /// Interaction logic for FindPathWindow.xaml
    /// </summary>
    public partial class FindPathWindow : Window
    {
        public FindPathWindow() {
            InitializeComponent();

            DataContextChanged += OnDataContextChanged;
        }

        private void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e) {
            var findPathViewModel = (IFindPathViewModel) e.NewValue;
            findPathViewModel.Initialize();
        }
    }
}