using Moq;
using NUnit.Framework;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.Model;
using RailroadStationVisualizer.Tests.Utils;
using System.Linq;

namespace RailroadStationVisualizer.Tests
{
    [TestFixture]
    public class MainViewModelTests : AutoMockerTestsBase<MainViewModel>
    {
        private readonly RailwayPark[] railwayParks = new[] {
            new RailwayPark() { Name = "Парк 1" },
            new RailwayPark() { Name = "Парк 2" },
            new RailwayPark() { Name = "Парк 3" }
        };

        /// <summary>
        /// Должен произвести инициализацию без ошибок
        /// </summary>
        [Test]
        public void ShouldInitializeWithoutErrors() {
            // Given
            GetMock<IStationSchemaProvider>()
                .Setup(x => x.GetStationSchema())
                .Returns(GetStationSchema);
            GetMock<IViewModelFactory>()
                .Setup(x => x.CreateParkViewModel(It.IsAny<RailwayPark>()))
                .Returns(new ParkViewModel(new RailwayPark()));
    
            // When
            Target.Initialize();

            // Then
            Assert.AreEqual(railwayParks.Length, Target.Parks.Count);
        }

        private StationSchema GetStationSchema() {
            return new StationSchema { Parks = railwayParks };
        }
    }
}