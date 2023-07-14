using RailroadStationVisualizer.App.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RailroadStationVisualizer.App.Views.Controls
{
    /// <summary>
    ///     Interaction logic for RailroadStationVisualizerControl.xaml
    /// </summary>
    public partial class RailroadStationVisualizerControl : UserControl
    {
        public static readonly DependencyProperty SectionsProperty = DependencyProperty.Register(
            "Sections", typeof(ObservableCollection<IRailwaySectionViewModel>), typeof(RailroadStationVisualizerControl), new PropertyMetadata(new ObservableCollection<IRailwaySectionViewModel>()));

        public RailroadStationVisualizerControl() {
            InitializeComponent();
        }

        public ObservableCollection<IRailwaySectionViewModel> Sections {
            get { return (ObservableCollection<IRailwaySectionViewModel>) GetValue(SectionsProperty); }
            set { SetValue(SectionsProperty, value); }
        }

        private void StationSchemaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            
        }
    }
}