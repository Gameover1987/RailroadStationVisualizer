using NUnit.Framework;
using RailroadStationVisualizer.App.Model;
using RailroadStationVisualizer.App.Model.Algorithms;
using System.Linq;

namespace RailroadStationVisualizer.Tests.Alogrithms
{
    /// <summary>
    /// Тесты на заливку <see cref="RailwayParkVisualizer">RailwayParkVisualizer</see>
    /// </summary>
    [TestFixture]
    public class RailwayParkVisualizerTests
    {
        /// <summary>
        /// Должен построить фигуру для заливки
        /// </summary>
        /// <param name="testName"></param>
        [TestCase("Фигура для заливки 1")]
        [TestCase("Фигура для заливки 2")]
        public void ShouldMakeFigureForFilling(string testName) {
            // Given
            var parkVisualizer = new RailwayParkVisualizer();

            var testCase = TestCases.First(x => x.TestName == testName);

            // When
            var actualPoints = parkVisualizer.GetParkPoints(testCase.Tracks.First().Park, testCase.Tracks.SelectMany(x => x.Sections).ToArray());

            // Then
            Assert.IsTrue(actualPoints.SequenceEqual(testCase.ExpectedPoints));
        }

        private FillingFigureTestCase[] TestCases =>
            new[] {
                GetTestCase1(),
                GetTestCase2()
            };

        private static FillingFigureTestCase GetTestCase1() {
            var points = new[]
            {
                new RailwayPoint(1, 0, 0),
                new RailwayPoint(2, 100, 0),
                new RailwayPoint(3, 0, 100),
                new RailwayPoint(4, 100, 100),
                new RailwayPoint(5, 0, 200),
                new RailwayPoint(6, 100, 200),
            };

            var sections = new[]
            {
                new RailwaySection(1, points[0], points[1]),
                new RailwaySection(2, points[2], points[3]),
                new RailwaySection(3, points[4], points[5])
            };

            var testCase = new FillingFigureTestCase();
            testCase.TestName = "Фигура для заливки 1";
            testCase.Tracks = new[] {
                new RailwayTrack(new[] { sections[0] }, "Park 1"),
                new RailwayTrack(new[] { sections[1] }, "Park 1"),
                new RailwayTrack(new[] { sections[2] }, "Park 1"),
            };
            testCase.ExpectedPoints = new[] { points[0], points[1], points[3], points[5], points[4], points[2] };
            return testCase;
        }

        private static FillingFigureTestCase GetTestCase2() {
            var points = new[]
            {
                new RailwayPoint(1, 50, 0),
                new RailwayPoint(2, 100, 0),

                new RailwayPoint(3, 0, 50),
                new RailwayPoint(4, 75, 50),
                new RailwayPoint(5, 150, 50),

                new RailwayPoint(6, 50, 100),
                new RailwayPoint(7, 100, 100),
            };

            var sections = new[]
            {
                new RailwaySection(1, points[0], points[1]),
                new RailwaySection(2, points[2], points[3]),
                new RailwaySection(3, points[3], points[4]),
                new RailwaySection(4, points[5], points[6])
            };

            var testCase = new FillingFigureTestCase();
            testCase.TestName = "Фигура для заливки 2";
            testCase.Tracks = new[] {
                new RailwayTrack(new[] { sections[0] }, "Park 2"),
                new RailwayTrack(new[] { sections[1], sections[2] }, "Park 2"),
                new RailwayTrack(new[] { sections[3] }, "Park 2"),
            };
            testCase.ExpectedPoints = new[] { points[0], points[1], points[4], points[6], points[5], points[2] };
            return testCase;
        }

        /// <summary>
        /// Тесткейс для проверки алгоритма заливки
        /// </summary>
        private class FillingFigureTestCase
        {
            /// <summary>
            /// Название
            /// </summary>
            public string? TestName { get; set; }

            /// <summary>
            /// Набор путей
            /// </summary>
            public RailwayTrack[]? Tracks { get; set; }

            /// <summary>
            /// Ожидаемый набор точек для построения фигуры для заливки
            /// </summary>
            public RailwayPoint[]? ExpectedPoints { get; set; }
        }
    }
}
