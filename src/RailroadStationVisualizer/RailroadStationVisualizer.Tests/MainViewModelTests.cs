using Moq;
using NUnit.Framework;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.ViewModels.Colors;
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

        private readonly ColorViewModel[] fillColors = new ColorViewModel[] {
            new ColorViewModel { Color = System.Windows.Media.Colors.Red, Name = "Красный" },
            new ColorViewModel { Color = System.Windows.Media.Colors.Orange, Name = "Оранжевый" },
            new ColorViewModel { Color = System.Windows.Media.Colors.Yellow, Name = "Желтый" },
            new ColorViewModel { Color = System.Windows.Media.Colors.Green, Name = "Зеленый" },
            new ColorViewModel { Color = System.Windows.Media.Colors.LightBlue, Name = "Голубой" },
            new ColorViewModel { Color = System.Windows.Media.Colors.Blue, Name = "Синий" },
            new ColorViewModel { Color = System.Windows.Media.Colors.Violet, Name = "Фиолетовый" }
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
            GetMock<IFillColorsProvider>()
                .Setup(x => x.GetColors())
                .Returns(fillColors);
        
            // When
            Target.Initialize();

            // Then
            Assert.AreEqual("Схема ЖД станции «Кукуево»", Target.Title);
            Assert.AreEqual(railwayParks.Length, Target.Parks.Count);
            Assert.AreEqual(fillColors.Length, Target.FillColors.Count);
        }

        private StationSchema GetStationSchema() {
            return new StationSchema {
                StationName = "Кукуево",
                //Parks = railwayParks
            };
        }
    }
}