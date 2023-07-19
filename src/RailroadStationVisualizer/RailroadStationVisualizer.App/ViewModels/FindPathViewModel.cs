using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.UI.ViewModels;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class FindPathViewModel : ViewModelBase, IFindPathViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private IRailwaySectionViewModel sectionA;
        private IRailwaySectionViewModel sectionB;

        private StationSchema schema;

        public FindPathViewModel(IStationSchemaProvider stationSchemaProvider, IViewModelFactory viewModelFactory) {
            this.stationSchemaProvider = stationSchemaProvider;
            this.viewModelFactory = viewModelFactory;
        }

        private bool FilterSectionsB(object obj) {
            if (SectionA == null)
                return true;

            var section = (IRailwaySectionViewModel) obj;
            return section != SectionA;
        }

        private bool FilterSectionsA(object obj) {
            if (SectionB == null)
                return true;

            var section = (IRailwaySectionViewModel) obj;
            return section != SectionB;
        }

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
            }
        }

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
    }
}