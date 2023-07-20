using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Model.Algorithms;
using RailroadStationVisualizer.UI.Commands;
using RailroadStationVisualizer.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace RailroadStationVisualizer.App.ViewModels
{
    /// <summary>
    /// ViewModel для поиска пути
    /// </summary>
    public class FindPathViewModel : ViewModelBase, IFindPathViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IPathFinder pathFindingAlgorithm;

        private IRailwaySectionViewModel? sectionA;
        private IRailwaySectionViewModel? sectionB;

        private StationSchema? schema;

        public FindPathViewModel(IStationSchemaProvider stationSchemaProvider,
            IViewModelFactory viewModelFactory,
            IPathFinder pathFindingAlgorithm) {
            this.stationSchemaProvider = stationSchemaProvider;
            this.viewModelFactory = viewModelFactory;
            this.pathFindingAlgorithm = pathFindingAlgorithm;

            PerformPathFindCommand = new DelegateCommand(PerformPathFindCommandHandler, CanPerformPathFindCommandHandler);
        }

        /// <summary>
        /// Все отрезки всех путей
        /// </summary>
        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();

        /// <summary>
        /// Начальный участок пути
        /// </summary>
        public IRailwaySectionViewModel? SectionA {
            get => sectionA;
            set {
                if (sectionA == value) {
                    return;
                }

                if (sectionA != null) {
                    sectionA.IsSelected = false;
                }

                sectionA = value;
                if (sectionA != null) {
                    sectionA.IsSelected = true;
                }

                OnPropertyChanged(() => SectionA);

                ResetFindedPath();
            }
        }

        /// <summary>
        /// Конечный участок пути
        /// </summary>
        public IRailwaySectionViewModel? SectionB {
            get => sectionB;
            set {
                if (sectionB == value) {
                    return;
                }

                if (sectionB != null) {
                    sectionB.IsSelected = false;
                }

                sectionB = value;
                if (sectionB != null) {
                    sectionB.IsSelected = true;
                }

                OnPropertyChanged(() => SectionB);

                ResetFindedPath();
            }
        }

        /// <summary>
        /// Команда для запуска поиска пути
        /// </summary>
        public IDelegateCommand PerformPathFindCommand { get; }

        /// <summary>
        /// Инициализирует модель представления загружая в нее схему станции
        /// </summary>
        public void Initialize() {
            schema = stationSchemaProvider.GetStationSchema();

            var sections = schema.Tracks
                 .SelectMany(x => x.Sections)
                 .Select(x => viewModelFactory.CreateSectionViewModel(x))
                 .ToArray();

            Sections.Clear();
            foreach (var railwaySectionViewModel in sections) {
                Sections.Add(railwaySectionViewModel);
            }
        }

        private bool CanPerformPathFindCommandHandler() {
            if (SectionA == null) {
                return false;
            }

            if (SectionB == null) {
                return false;
            }

            return SectionA != SectionB;
        }

        private void PerformPathFindCommandHandler() {
            var sections = pathFindingAlgorithm.GetPathBetweenTwoSections(SectionA.Model, SectionB.Model);

            var ids = sections.Select(x => x.Id).ToArray();
            foreach (var railwaySectionViewModel in Sections) {
                railwaySectionViewModel.IsSelected = ids.Contains(railwaySectionViewModel.Id);
                railwaySectionViewModel.Refresh();
            }
        }

        private void ResetFindedPath() {
            foreach (var railwaySectionViewModel in Sections.Except(new []{SectionA, SectionB})) {
                railwaySectionViewModel.Model.IsVisited = false;
                railwaySectionViewModel.IsSelected = false;
                railwaySectionViewModel.Refresh();
            }
        }
    }
}