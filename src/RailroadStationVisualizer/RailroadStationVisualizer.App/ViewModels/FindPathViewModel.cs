using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Views.Helpers;
using RailroadStationVisualizer.UI.Commands;
using RailroadStationVisualizer.UI.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class FindPathViewModel : ViewModelBase, IFindPathViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private readonly IPathfindingAlgorithm pathfindingAlgorithm;
        private IRailwaySectionViewModel sectionA;
        private IRailwaySectionViewModel sectionB;

        private StationSchema schema;

        public FindPathViewModel(IStationSchemaProvider stationSchemaProvider,
            IViewModelFactory viewModelFactory,
            IPathfindingAlgorithm pathfindingAlgorithm) {
            this.stationSchemaProvider = stationSchemaProvider;
            this.viewModelFactory = viewModelFactory;
            this.pathfindingAlgorithm = pathfindingAlgorithm;

            PerformPathFindCommand = new DelegateCommand(PerformPathFindCommandHandler, CanPerformPathFindCommandHandler);
        }

        /// <summary>
        /// Все отрезки всех путей
        /// </summary>
        public ObservableCollection<IRailwaySectionViewModel> Sections { get; } = new ObservableCollection<IRailwaySectionViewModel>();

        /// <summary>
        /// Начальный участок пути
        /// </summary>
        public IRailwaySectionViewModel SectionA {
            get { return sectionA; }
            set {
                if (sectionA == value)
                    return;
                
                if (sectionA != null)
                    sectionA.IsSelected = false;

                sectionA = value;
                if (sectionA != null)
                    sectionA.IsSelected = true;
                OnPropertyChanged(() => SectionA);

                ResetFindedPath();
            }
        }

        /// <summary>
        /// Конечный участок пути
        /// </summary>
        public IRailwaySectionViewModel SectionB {
            get { return sectionB; }
            set {
                if (sectionB == value)
                    return;

                if (sectionB != null)
                    sectionB.IsSelected = false;

                sectionB = value;
                if (sectionB != null)
                    sectionB.IsSelected = true;
                OnPropertyChanged(() => SectionB);

                ResetFindedPath();
            }
        }

        public IDelegateCommand PerformPathFindCommand { get; }

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
            return SectionA != null && SectionB != null;
        }

        private void PerformPathFindCommandHandler() {
            var sections = pathfindingAlgorithm.GetPathBetweenTwoSections(SectionA.Model, SectionB.Model);

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