using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.UI.ViewModels;
using System;
using System.Collections.ObjectModel;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        private readonly IStationSchemaProvider stationSchemaProvider;
        private readonly IViewModelFactory viewModelFactory;
        private IParkViewModel selectedPark;

        public MainViewModel(IStationSchemaProvider stationSchemaProvider, IViewModelFactory viewModelFactory) {
            this.stationSchemaProvider = stationSchemaProvider ?? throw new ArgumentNullException(nameof(stationSchemaProvider));
            this.viewModelFactory = viewModelFactory;
        }

        public ObservableCollection<IParkViewModel> Parks { get; } = new ObservableCollection<IParkViewModel>();

        public IParkViewModel SelectedPark {
            get => selectedPark;
            set {
                if (selectedPark == value)
                    return;
                selectedPark = value;
                OnPropertyChanged(() => SelectedPark);
            }
        }

        public void Initialize() {
            var schema = stationSchemaProvider.GetStationSchema();
            Parks.Clear();
            foreach (var railwayPark in schema.Parks) {
                var parkViewModel = viewModelFactory.CreateParkViewModel(railwayPark);
                Parks.Add(parkViewModel);
            }
        }
    }
}
