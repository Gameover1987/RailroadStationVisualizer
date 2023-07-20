using Moq;
using NUnit.Framework;
using RailroadStationVisualizer.App.Infrastructure;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.App.ViewModels.Colors;
using RailroadStationVisualizer.Tests.Utils;

namespace RailroadStationVisualizer.Tests.ViewModels
{
    /// <summary>
    /// Тесты для <see cref="MainViewModel">MainViewModel</see>
    /// </summary>
    [TestFixture]
    public class MainViewModelTests : AutoMockerTestsBase<MainViewModel>
    {
        private readonly string[] railwayParks = new[] {
            "Парк 1","Парк 2"
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

        /// <summary>
        /// Должен вызвать метод отображения окна с поиском пути при выполнении соответствующей команды
        /// </summary>
        [Test]
        public void ShouldShowFindPathWindowWhenExecAppropriateCommand() {
            // Given

            // When
            Target.FindWayCommand.TryExecute();

            // Then
            GetMock<IWindowManager>().Verify(x => x.ShowFindPathWindow(), Times.Once);
        }

        private StationSchema GetStationSchema() {
            var point1 = new RailwayPoint(1, 0, 0);
            var point2 = new RailwayPoint(2, 50, 0);
            var point3 = new RailwayPoint(3, 100, 0);
            var point4 = new RailwayPoint(4, 100, 0);
            var point5 = new RailwayPoint(5, 100, 0);
            var point6 = new RailwayPoint(6, 100, 0);

            return new StationSchema {
                StationName = "Кукуево",
                Tracks = new[]{
                    new RailwayTrack(new[] {
                        new RailwaySection(1, point1, point2),
                        new RailwaySection(2, point2, point3),
                    }, railwayParks[0]),
                    new RailwayTrack(new[] {
                        new RailwaySection(3, point4, point5),
                        new RailwaySection(4, point5, point6),
                    }, railwayParks[1])
                }
            };
        }
    }
}