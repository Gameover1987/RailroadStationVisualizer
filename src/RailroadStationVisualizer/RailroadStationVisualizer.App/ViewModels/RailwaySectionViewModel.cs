using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.UI.ViewModels;
using System;

namespace RailroadStationVisualizer.App.ViewModels
{
    public class RailwaySectionViewModel : ViewModelBase, IRailwaySectionViewModel
    {
        private readonly RailwaySection section;
        private bool isSelected;

        public RailwaySectionViewModel(RailwaySection section) {
            if (section == null) {
                throw new ArgumentNullException(nameof(section));
            }

            this.section = section;
        }

        public string Park => section?.Track?.Park;

        public RailwayPoint Start => section.Start;

        public RailwayPoint End => section.End;

        public string DisplayName {
            get {
                if (string.IsNullOrWhiteSpace(Park))
                    return $"ID: {section.Id}";

                return $"ID: {section.Id} - {Park}";
            }
        }

        public RailwaySection ToModel() => section;

        public bool IsSelected {
            get { return isSelected; }
            set {
                if (isSelected == value)
                    return;
                isSelected = value;
                OnPropertyChanged(() => IsSelected);
            }
        }

        public string Name => section.Name;

        public bool HasPark => !string.IsNullOrEmpty(Park);
    }
}