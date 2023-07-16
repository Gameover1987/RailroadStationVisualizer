using RailroadStationVisualizer.App.ViewModels;
using System;
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
            var parkPoints = sectionsByPark
                .SelectMany(x => new[] { x.Start, x.End })
                .Distinct()
                .ToArray();
            var parkPointsByX = parkPoints
                .OrderBy(x => x.X)
                .ThenBy(x => x.Y)
                .ToArray();
            var parkPointsByY = parkPoints
                .OrderBy(x => x.Y)
                .ThenBy(x => x.X)
                .ToArray();

            var topPoint = parkPointsByY.First();
            var rightPoint = parkPointsByX.Last();

            var geometry = new PathGeometry();
            var figure = new PathFigure();
            figure.StartPoint = topPoint.ToPoint();

            //2
            var borderPoints = parkPoints
                .Where(p => p.Y <= rightPoint.Y && p.X >= topPoint.X)
                .Where(p => p.Id != topPoint.Id && p.Id != rightPoint.Id);

            var mainTg = (rightPoint.Y - topPoint.Y) / (rightPoint.X - topPoint.X);
            foreach (var nextPoint in borderPoints) {
                var tg = (rightPoint.Y - nextPoint.Y) / (rightPoint.X - nextPoint.X);
                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                figure.Segments.Add(new LineSegment(nextPoint.ToPoint(), true));
            }

            figure.Segments.Add(new LineSegment(rightPoint.ToPoint(), true));

            var bottomRightPoint = parkPointsByY.Last();
            var bottomPoint = parkPointsByY
                .First(t => Math.Abs(t.Y - bottomRightPoint.Y) < double.Epsilon);

            //3
            borderPoints = parkPoints
                .Where(p => p.X >= bottomPoint.X && p.Y >= rightPoint.Y)
                .Where(p => p.Id != rightPoint.Id && p.Id != bottomPoint.Id)
                .OrderByDescending(p => p.X)
                .ThenBy(p => p.Y)
                .ToArray();

            mainTg = (rightPoint.X - bottomPoint.X) / (bottomPoint.Y - rightPoint.Y);
            foreach (var nextPoint in borderPoints) {
                var tg = (nextPoint.X - bottomPoint.X) / (bottomPoint.Y - nextPoint.Y);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                figure.Segments.Add(new LineSegment(nextPoint.ToPoint(), true));
            }

            figure.Segments.Add(new LineSegment(bottomPoint.ToPoint(), true));

            var leftPoint = parkPointsByX.First();

            //4
            borderPoints = parkPoints
                .Where(p => p.X <= bottomPoint.X && p.Y >= leftPoint.Y)
                .Where(p => p.Id != bottomPoint.Id && p.Id != leftPoint.Id)
                .OrderByDescending(p => p.Y)
                .ThenByDescending(p => p.X);

            mainTg = (bottomPoint.X - leftPoint.X) / (bottomPoint.Y - leftPoint.Y);
            foreach (var nextPoint in borderPoints) {
                var tg = (bottomPoint.X - nextPoint.X) / (bottomPoint.Y - nextPoint.Y);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                figure.Segments.Add(new LineSegment(nextPoint.ToPoint(), true));
            }

            figure.Segments.Add(new LineSegment(leftPoint.ToPoint(), true));

            //1
            borderPoints = parkPoints
                .Where(p => p.X <= topPoint.X && p.Y <= leftPoint.Y)
                .Where(p => p.Id != leftPoint.Id && p.Id != topPoint.Id)
                .OrderBy(p => p.X)
                .ThenByDescending(p => p.Y)
                .ToArray();

            mainTg = (leftPoint.Y - topPoint.Y) / (topPoint.X - leftPoint.X);
            foreach (var nextPoint in borderPoints.Skip(1)) {
                var tg = (leftPoint.Y - nextPoint.Y) / (nextPoint.X - leftPoint.X);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                figure.Segments.Add(new LineSegment(nextPoint.ToPoint(), true));
            }

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