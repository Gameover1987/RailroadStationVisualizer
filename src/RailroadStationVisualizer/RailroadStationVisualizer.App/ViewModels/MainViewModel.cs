using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels.Colors;
using RailroadStationVisualizer.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IFillColorsProvider fillColorsProvider;
        private string selectedPark;
        private ColorViewModel selectedColor;

        public MainViewModel(IStationSchemaProvider stationSchemaProvider,
            IViewModelFactory viewModelFactory,
            IFillColorsProvider fillColorsProvider) {
            this.stationSchemaProvider = stationSchemaProvider ?? throw new ArgumentNullException(nameof(stationSchemaProvider));
            this.viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            this.fillColorsProvider = fillColorsProvider ?? throw new ArgumentNullException(nameof(fillColorsProvider));
        }

        public string Title { get; private set; }

        public ObservableCollection<string> Parks { get; } = new ObservableCollection<string>();

        public string SelectedPark {
            get => selectedPark;
            set {
                if (selectedPark == value)
                    return;
                selectedPark = value;
                OnPropertyChanged(() => SelectedPark);

                SelectedSections.Clear();
                if (selectedPark != null) {
                    var sectionsByPark = Sections.Where(x => !string.IsNullOrWhiteSpace(x.Park)).ToArray();
                    foreach (var sectionViewModel in sectionsByPark) {
                        SelectedSections.Add(sectionViewModel);
                    }
                }
            }
        }

        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();

        public ObservableCollection<IRailwaySectionViewModel> SelectedSections { get; } = new ObservableCollection<IRailwaySectionViewModel>();

        public ObservableCollection<ColorViewModel> FillColors { get; } = new ObservableCollection<ColorViewModel>();

        public ColorViewModel SelectedColor {
            get => selectedColor;
            set {
                if (selectedColor == value)
                    return;
                selectedColor = value;
                OnPropertyChanged(() => SelectedColor);
            }
        }

        public void Initialize() {
            var schema = stationSchemaProvider.GetStationSchema();

            Title = $"Схема ЖД станции «{schema.StationName}»";

            Sections.Clear();
            var sections = schema.Tracks.SelectMany(x => x.Sections).ToArray();
            foreach (var railwaySection in sections) {
                var sectionViewModel = viewModelFactory.CreateSectionViewModel(railwaySection);
                Sections.Add(sectionViewModel);
            }

            var parks = schema.Tracks
                .Where(x => !string.IsNullOrWhiteSpace(x.Park))
                .Select(x => x.Park)
                .Distinct()
                .ToArray();
            Parks.Clear();
            foreach (var park in parks) {
                Parks.Add(park);
            }

            FillColors.Clear();
            var colors = fillColorsProvider.GetColors();
            foreach (var colorViewModel in colors) {
                FillColors.Add(colorViewModel);
            }

            OnPropertyChanged();
        }
    }
}
