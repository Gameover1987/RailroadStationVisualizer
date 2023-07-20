using NUnit.Framework;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Model.Algorithms;
using System.Linq;

namespace RailroadStationVisualizer.Tests.Alogrithms
{
    /// <summary>
    /// Тесты на алгоритм поиска пути
    /// </summary>
    [TestFixture]
    public class DijkstraPathFinderTests
    {
        /// <summary>
        /// Должен построить кратчайший путь между двумя участками
        /// </summary>
        [TestCase("Маршрут 1")]
        public void ShouldFindShortestPath(string testName) {
            // Given
            var pathFinder = new DijkstraPathFinder();
            var testCase = TestCases.First(x => x.TestName == testName);

            // When
            var actualPath = pathFinder.GetPathBetweenTwoSections(testCase.SectionA, testCase.SectionB);

            // Then
            Assert.IsTrue(actualPath.SequenceEqual(testCase.ExpectedPath));
        }

        private PathFinderTestCase[] TestCases =>
            new[] {
                GetTestCase1(),
            };

        private PathFinderTestCase GetTestCase1() {
            var points = new RailwayPoint[] {
                new RailwayPoint(1, 0, 50),
                new RailwayPoint(2, 50, 50),
                new RailwayPoint(3, 60, 10),
                new RailwayPoint(4, 80, 10),
                new RailwayPoint(5, 100, 50),
                new RailwayPoint(6, 120, 50),
            };

            var sections = new RailwaySection[] {
                new RailwaySection(1, points[0], points[1], "A"),
                new RailwaySection(2, points[1], points[2], "B"),
                new RailwaySection(3, points[1], points[4], "F"),
                new RailwaySection(4, points[2], points[3], "C"),
                new RailwaySection(5, points[3], points[4], "D"),
                new RailwaySection(6, points[4], points[5], "E"),
            };

            var expectedPath = new RailwaySection[] {
                sections.First(x => x.Name == "A"),
                sections.First(x => x.Name == "F"),
                sections.First(x => x.Name == "E")
            };

            return new PathFinderTestCase {
                TestName = "Маршрут 1",
                SectionA = sections.First(x => x.Name == "A"),
                SectionB = sections.First(x => x.Name == "E"),
                ExpectedPath = expectedPath
            };
        }

        /// <summary>
        /// Тесткейс для алогритма поиска пути
        /// </summary>
        private class PathFinderTestCase
        {
            public string TestName { get; set; }

            public RailwaySection SectionA { get; set; }

            public RailwaySection SectionB { get; set; }

            public RailwaySection[] ExpectedPath { get; set; }
        }
    }
}
