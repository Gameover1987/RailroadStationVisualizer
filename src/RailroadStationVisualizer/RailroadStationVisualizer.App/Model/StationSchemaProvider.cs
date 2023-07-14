using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace RailroadStationVisualizer.App.Model
{
    public class StationSchemaProvider : IStationSchemaProvider
    {
        public StationSchema GetStationSchema() {
            var points = GetRailwayPoints();

            var sections = GetRailwaySections(points);

            return new StationSchema { StationName = "Кукуево", Sections = sections };
        }

        private static RailwayPoint[] GetRailwayPoints() {
            int index = 1;
            var totalPoints = new List<RailwayPoint>();
            var northPoints = GetNorthRailwayPoints(ref index);
            totalPoints.AddRange(northPoints);
            return totalPoints.ToArray();
        }

        private static RailwayPoint[] GetNorthRailwayPoints(ref int index) {
            var railwayPoints = new List<RailwayPoint>();
            railwayPoints.Add(new RailwayPoint(index++, 161, 119));
            railwayPoints.Add(new RailwayPoint(index++, 232, 119));
            railwayPoints.Add(new RailwayPoint(index++, 300, 119));
            railwayPoints.Add(new RailwayPoint(index++, 316, 106));
            railwayPoints.Add(new RailwayPoint(index++, 461, 106));
            railwayPoints.Add(new RailwayPoint(index++, 477, 119));
            railwayPoints.Add(new RailwayPoint(index++, 493, 119));
            return railwayPoints.ToArray();
        }

        private static RailwaySection[] GetRailwaySections(RailwayPoint[] points) {
            var index = 1;
            var sections = new List<RailwaySection>();
            sections.Add(new RailwaySection(index++, points[0], points[1]));
            sections.Add(new RailwaySection(index++, points[1], points[2]));
            sections.Add(new RailwaySection(index++, points[2], points[3]));
            sections.Add(new RailwaySection(index++, points[3], points[4]));
            sections.Add(new RailwaySection(index++, points[4], points[5]));
            sections.Add(new RailwaySection(index++, points[5], points[6]));
            sections.Add(new RailwaySection(index++, points[2], points[5]));
            return sections.ToArray();
        }
    }
}