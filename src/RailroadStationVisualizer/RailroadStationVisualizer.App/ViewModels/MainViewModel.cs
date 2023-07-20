using RailroadStationVisualizer.App.Infrastructure;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels.Colors;
using RailroadStationVisualizer.UI.Commands;
using RailroadStationVisualizer.UI.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// ViewModel главного окна
    /// </summary>
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IFillColorsProvider fillColorsProvider;
        private readonly IWindowManager windowManager;
        private readonly IFindPathViewModel findPathViewModel;

        private string? selectedPark;
        private ColorViewModel? selectedColor;

        public MainViewModel(IStationSchemaProvider stationSchemaProvider,
            IViewModelFactory viewModelFactory,
            IFillColorsProvider fillColorsProvider, 
            IWindowManager windowManager,
            IFindPathViewModel findPathViewModel) {
            this.stationSchemaProvider = stationSchemaProvider ?? throw new ArgumentNullException(nameof(stationSchemaProvider));
            this.viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            this.fillColorsProvider = fillColorsProvider ?? throw new ArgumentNullException(nameof(fillColorsProvider));
            this.windowManager = windowManager;
            this.findPathViewModel = findPathViewModel;

            FindWayCommand = new DelegateCommand(FindWayCommandHandler);
        }

        /// <summary>
        /// Заголовок окна
        /// </summary>
        public string? Title { get; private set; }

        /// <summary>
        /// Коллекция парков
        /// </summary>
        public ObservableCollection<string> Parks { get; } = new ObservableCollection<string>();

        /// <summary>
        /// Выбранный парк
        /// </summary>
        public string SelectedPark {
            get => selectedPark;
            set {
                if (selectedPark == value) {
                    return;
                }

                selectedPark = value;
                OnPropertyChanged(() => SelectedPark);
            }
        }

        /// <summary>
        /// Коллекция отрезков ЖД путей (так называемых секций) 
        /// </summary>
        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();

        /// <summary>
        /// Коллекция цветов для заливки
        /// </summary>
        public ObservableCollection<ColorViewModel> FillColors { get; } = new ObservableCollection<ColorViewModel>();

        /// <summary>
        /// Выбранный цвет для заливки
        /// </summary>
        public ColorViewModel? SelectedColor {
            get => selectedColor;
            set {
                if (selectedColor == value) {
                    return;
                }

                selectedColor = value;
                OnPropertyChanged(() => SelectedColor);
            }
        }

        /// <summary>
        /// Команда для открытия окна поиска пути
        /// </summary>
        public IDelegateCommand FindWayCommand { get; }

        /// <summary>
        /// Инициализирует модель представления загружая в нее схему станции
        /// </summary>
        public void Initialize() {
            var schema = stationSchemaProvider.GetStationSchema();

            Title = string.Format(Strings.WindowTitle_Main, schema.StationName);

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

        private void FindWayCommandHandler() {
           windowManager.ShowFindPathWindow(findPathViewModel);
        }
    }
}
