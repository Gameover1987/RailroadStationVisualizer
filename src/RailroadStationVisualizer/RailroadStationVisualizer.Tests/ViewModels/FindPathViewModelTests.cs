using Moq;
using NUnit.Framework;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Model.Algorithms;
using RailroadStationVisualizer.App.ViewModels;
using RailroadStationVisualizer.Tests.Utils;
using System.Linq;

namespace RailroadStationVisualizer.Tests.ViewModels
{
    /// <summary>
    /// Тесты для <see cref="FindPathViewModel">FindPathViewModel</see>
    /// </summary>
    [TestFixture]
    public class FindPathViewModelTests : AutoMockerTestsBase<FindPathViewModel>
    {
        public override void SetUp() {
            base.SetUp();

            Use<IViewModelFactory>(new ViewModelFactory());
        }

        /// <summary>
        /// Должен произвести инициализацию без ошибок
        /// </summary>
        [Test]
        public void ShouldInitializeWithoutErrors() {
            // Given
            GetMock<IStationSchemaProvider>()
                .Setup(x => x.GetStationSchema())
                .Returns(GetStationSchema);

            // When
            Target.Initialize();

            // Then
            var expectedSectionsCount = GetStationSchema().Tracks.SelectMany(x => x.Sections).Count();
            Assert.AreEqual(expectedSectionsCount, Target.Sections.Count);
        }

        [TestCase(null, null, false, "Начало и конец не выбраны")]
        [TestCase(0, null, false, "Конец не выбран")]
        [TestCase(null, 0, false, "Начало не выбрано")]
        [TestCase(0, 0, false, "Начало и конец не совпадают")]
        [TestCase(0, 1, true, "Начало и конец выбраны, и не совпадают")]
        public void ShouldPerformPathFindCommandBeEnabledOrDisabled(int? sectionAIndex, int? sectionBIndex, bool expectedIsEnabled, string description) {
            // Given
            GetMock<IStationSchemaProvider>()
                .Setup(x => x.GetStationSchema())
                .Returns(GetStationSchema);

            // When
            Target.Initialize();
            Target.SectionA = null;
            Target.SectionB = null;

            if (sectionAIndex != null) {
                Target.SectionA = Target.Sections[sectionAIndex.Value];
            }

            if (sectionBIndex != null) {
                Target.SectionB = Target.Sections[sectionBIndex.Value];
            }

            var actualIsEnabled = Target.PerformPathFindCommand.CanExecute();

            // Then
            Assert.AreEqual(expectedIsEnabled, actualIsEnabled);
        }

        /// <summary>
        /// Должен вызвать алгоритм поиска пути
        /// </summary>
        [Test]
        public void ShouldRunPathFinder() {
            // Given
            GetMock<IStationSchemaProvider>()
                .Setup(x => x.GetStationSchema())
                .Returns(GetStationSchema);

            // When
            Target.Initialize();
            Target.SectionA = Target.Sections[0];
            Target.SectionB = Target.Sections[1];
            Target.PerformPathFindCommand.TryExecute();

            // Then
            GetMock<IPathFinder>().Verify(x => x.GetPathBetweenTwoSections(Target.SectionA.Model, Target.SectionB.Model), Times.Once);
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
                    }),
                    new RailwayTrack(new[] {
                        new RailwaySection(3, point4, point5),
                        new RailwaySection(4, point5, point6),
                    })
                }
            };
        }
    }
}
