using Microsoft.Extensions.DependencyInjection;
using RailroadStationVisualizer.App.Model.Algorithms;
using RailroadStationVisualizer.App.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace RailroadStationVisualizer.App.Views.Controls
{
    /// <summary>
    /// Контрол для отображения схемы ЖД станции
    /// </summary>
    public partial class RailroadStationVisualizerControl
    {
        public static readonly DependencyProperty SectionsProperty = DependencyProperty.Register(
            "Sections", typeof(ObservableCollection<IRailwaySectionViewModel>), typeof(RailroadStationVisualizerControl), new PropertyMetadata(new ObservableCollection<IRailwaySectionViewModel>()));

        public static readonly DependencyProperty ParkProperty = DependencyProperty.Register(
            "Park", typeof(string), typeof(RailroadStationVisualizerControl), new FrameworkPropertyMetadata(default(string)) { AffectsRender = true });

        public static readonly DependencyProperty FillColorProperty = DependencyProperty.Register(
            "FillColor", typeof(Color), typeof(RailroadStationVisualizerControl), new FrameworkPropertyMetadata(default(Color)) { AffectsRender = true });

        public static readonly DependencyProperty HighlightSectionsInParkProperty = DependencyProperty.Register(
            "HighlightSectionsInPark", typeof(bool), typeof(RailroadStationVisualizerControl), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty HightlightVisitedSectionsProperty = DependencyProperty.Register(
            "HightlightVisitedSections", typeof(bool), typeof(RailroadStationVisualizerControl), new PropertyMetadata(default(bool)));

        public RailroadStationVisualizerControl() {
            InitializeComponent();
        }

        /// <summary>
        /// Отрезки ЖД путей
        /// </summary>
        public ObservableCollection<IRailwaySectionViewModel>? Sections {
            get => (ObservableCollection<IRailwaySectionViewModel>) GetValue(SectionsProperty);
            set => SetValue(SectionsProperty, value);
        }

        /// <summary>
        /// Выбранный парк
        /// </summary>
        public string? Park {
            get => (string) GetValue(ParkProperty);
            set => SetValue(ParkProperty, value);
        }

        /// <summary>
        /// Цвет для заливки
        /// </summary>
        public Color? FillColor {
            get => (Color) GetValue(FillColorProperty);
            set => SetValue(FillColorProperty, value);
        }

        /// <summary>
        /// Выделять ли цвветом отрезки путей которые принадлежат какому-нибудь парку (для отладки)
        /// </summary>
        public bool HighlightSectionsInPark {
            get => (bool) GetValue(HighlightSectionsInParkProperty);
            set => SetValue(HighlightSectionsInParkProperty, value);
        }

        /// <summary>
        /// Выделять ли цветом отрезки затронутые алгоритмом поиска пути
        /// </summary>
        public bool HightlightVisitedSections {
            get => (bool) GetValue(HightlightVisitedSectionsProperty);
            set => SetValue(HightlightVisitedSectionsProperty, value);
        }

        protected override void OnRender(DrawingContext drawingContext) {
            base.OnRender(drawingContext);

            if (!IsParkRenderingAvailable()) {
                return;
            }

            var parkVisualizer = App.ServiceProvider.GetService<IRailwayParkVisualizer>();
            if (parkVisualizer == null) {
                throw new ArgumentException("Не найдена реализация для алгоритма заливки");
            }
            var parkPoints = parkVisualizer.GetParkPoints(Park, Sections.Select(x => x.Model).ToArray());

            var geometry = new PathGeometry();
            var figure = new PathFigure();
            figure.StartPoint = parkPoints.First().ToPoint();

            foreach (var railwayPoint in parkPoints.Skip(1)) {
                figure.Segments.Add(new LineSegment(railwayPoint.ToPoint(), true));
            }
            geometry.Figures.Add(figure);
            var brush = new SolidColorBrush(FillColor.Value);

            drawingContext.DrawGeometry(brush, new Pen(brush, 5), geometry);
        }

        private bool IsParkRenderingAvailable() {
            if (Sections == null || Sections.Count == 0 || Park == null || FillColor == null) {
                return false;
            }

            return true;
        }
    }
}