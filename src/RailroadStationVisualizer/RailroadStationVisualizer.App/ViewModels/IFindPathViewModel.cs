namespace RailroadStationVisualizer.App.ViewModels
{
    public interface IFindPathViewModel
    {
        IRailwaySectionViewModel SectionA { get; set; }

        IRailwaySectionViewModel SectionB { get; set; }

        void Initialize();
    }
}