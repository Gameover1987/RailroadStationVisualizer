using RailroadStationVisualizer.App.ViewModels;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace RailroadStationVisualizer.App.Views.Controls
{
    /// <summary>
    ///     Interaction logic for RailroadStationVisualizerControl.xaml
    /// </summary>
    public partial class RailroadStationVisualizerControl : UserControl
    {
        public static readonly DependencyProperty SectionsProperty = DependencyProperty.Register(
            "Sections", typeof(ObservableCollection<IRailwaySectionViewModel>), typeof(RailroadStationVisualizerControl), new PropertyMetadata(new ObservableCollection<IRailwaySectionViewModel>()));

        public static readonly DependencyProperty ParkProperty = DependencyProperty.Register(
            "Park", typeof(string), typeof(RailroadStationVisualizerControl), new FrameworkPropertyMetadata(default(string)) { AffectsRender = true });

        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(
            "FillColor", typeof(Color), typeof(RailroadStationVisualizerControl), new FrameworkPropertyMetadata(default(Color)) { AffectsRender = true });

        public Color FillColor {
            get { return (Color) GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public RailroadStationVisualizerControl() {
            InitializeComponent();
        }

        public ObservableCollection<IRailwaySectionViewModel> Sections {
            get { return (ObservableCollection<IRailwaySectionViewModel>) GetValue(SectionsProperty); }
            set { SetValue(SectionsProperty, value); }
        }

        public string Park {
            get { return (string) GetValue(ParkProperty); }
            set { SetValue(ParkProperty, value); }
        }

        protected override void OnRender(DrawingContext drawingContext) {
            base.OnRender(drawingContext);

            if (!IsParkRenderingAvailable())
                return;

            var sectionsByPark = Sections.Where(x => x.Park == Park).ToArray();

            var geometry = new PathGeometry();
            var figure = new PathFigure();
            figure.StartPoint = sectionsByPark.First().Start.ToPoint();
            for (int i = 0; i < sectionsByPark.Length - 1; i++) {
                var section = sectionsByPark[i];
                var nextSection = sectionsByPark[i + 1];
                figure.Segments.Add(new LineSegment(section.End.ToPoint(), true));
                figure.Segments.Add(new LineSegment(nextSection.Start.ToPoint(), true));
            }
            figure.Segments.Add(new LineSegment(sectionsByPark.Last().End.ToPoint(), true));
            geometry.Figures.Add(figure);

            var brush = new SolidColorBrush(FillColor);

            drawingContext.DrawGeometry(brush, new Pen(brush, 5), geometry);
        }

        private bool IsParkRenderingAvailable() {
            if (Sections == null || Sections.Count == 0 || Park == null || FillColor == null)
                return false;

            return true;
        }

        private void StationSchemaElement_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
           
        }
    }
}