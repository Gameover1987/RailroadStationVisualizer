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
        public static readonly DependencyProperty ParksProperty = DependencyProperty.Register(
            "Parks", typeof(ObservableCollection<IParkViewModel>), typeof(RailroadStationVisualizerControl), new PropertyMetadata(default(ObservableCollection<IParkViewModel>), PropertyChangedCallback));

        public static readonly DependencyProperty SectionsProperty = DependencyProperty.Register(
            "Sections", typeof(ObservableCollection<IRailwaySectionViewModel>), typeof(RailroadStationVisualizerControl), new PropertyMetadata(new ObservableCollection<IRailwaySectionViewModel>()));

        private static void PropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e) {
            ObservableCollection<IParkViewModel> parksCollection = null;
            if (e.OldValue != null) {
                parksCollection = e.OldValue as ObservableCollection<IParkViewModel>;
                parksCollection.CollectionChanged -= ParksCollectionOnCollectionChanged;
            }

            if (e.NewValue != null) {
                parksCollection = e.NewValue as ObservableCollection<IParkViewModel>;
                parksCollection.CollectionChanged += ParksCollectionOnCollectionChanged;
            }

            var visualizer = dependencyObject as RailroadStationVisualizerControl;
            visualizer?.Draw();
        }

        public RailroadStationVisualizerControl() {
            InitializeComponent();
        }

        public ObservableCollection<IParkViewModel> Parks {
            get { return (ObservableCollection<IParkViewModel>) GetValue(ParksProperty); }
            set { SetValue(ParksProperty, value); }
        }

        protected ObservableCollection<IRailwaySectionViewModel> Sections {
            get { return (ObservableCollection<IRailwaySectionViewModel>) GetValue(SectionsProperty); }
            set { SetValue(SectionsProperty, value); }
        }

        private static void ParksCollectionOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e) {
            var visualizer = sender as RailroadStationVisualizerControl;
            visualizer?.Draw();
        }

        private void Draw() {
            Sections.Clear();
            foreach (var section in Parks.SelectMany(x => x.Tracks.SelectMany(y => y.Sections))) {
                Sections.Add(section);
            }
        }

        private void StationSchemaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            
        }
    }
}