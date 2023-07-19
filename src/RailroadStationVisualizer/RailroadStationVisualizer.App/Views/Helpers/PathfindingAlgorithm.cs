using RailroadStationVisualizer.App.Model;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStationVisualizer.App.Views.Helpers
{
    public class PathfindingAlgorithm : IPathfindingAlgorithm
    {
        public RailwaySection[] GetPathBetweenTwoSections(RailwaySection beginSection, RailwaySection endSection) {

            var firstPathElement = new PathElement(beginSection, null);
            var connectedSections = GetConnectedPathElements(firstPathElement);
            var queue = new Queue<PathElement>(connectedSections);
            var shortestPath = double.MaxValue;

            PathElement shortestPathElement = null;

            while (queue.Count > 0) {
                var currentElement = queue.Dequeue();

                if (currentElement.Section.Id == endSection.Id) {

                    // Если нашли путь то запоминаем его длину
                    if (shortestPath > currentElement.Distance) {
                        shortestPath = currentElement.Distance;
                        shortestPathElement = new PathElement(endSection, currentElement);
                    }
                    continue;
                }

                if (currentElement.Distance > shortestPath) {
                    continue;
                }

                var connectedPathElements = GetConnectedPathElements(currentElement);
                foreach (var pathElement in connectedPathElements) {
                    queue.Enqueue(pathElement);
                }
            }

            if (shortestPathElement == null) {
                return new RailwaySection[0];
            }

            var resultPath = new List<PathElement>();
            var current = shortestPathElement;
            while (current != null) {
                resultPath.Add(current);
                current = current.Previous;
            }

            resultPath.Reverse();
            return resultPath.Select(x => x.Section).ToArray();
        }

        private static PathElement[] GetConnectedPathElements(PathElement pathElement) {
            var connectedSections = new List<PathElement>();

            var startPathElements = pathElement.Section.Start.Sections
                .Where(x => x.Id != pathElement.Section.Id && !pathElement.Ids.Contains(x.Id))
                .Select(x => new PathElement(x, pathElement));
            connectedSections.AddRange(startPathElements);

            var endPathElements = pathElement.Section.End.Sections
                .Where(x => x.Id != pathElement.Section.Id && !pathElement.Ids.Contains(x.Id))
                .Select(x => new PathElement(x, pathElement));
            connectedSections.AddRange(endPathElements);

            return connectedSections.ToArray();
        }

        private class PathElement
        {
            public PathElement(RailwaySection section, PathElement? previous) {
                Section = section;
                Section.IsVisisted = true;
                Previous = previous;
                if (previous != null) {
                    Ids = previous.Ids.Concat(new[] { section.Id }).ToArray();
                    Distance = previous.Distance + previous.Section.Distance;
                }
                else {
                    Ids = new[] { section.Id };
                    Distance = 0;
                }
            }

            public int[] Ids { get; set; }

            public RailwaySection Section { get; set; }

            public PathElement? Previous { get; set; }

            public double Distance { get; set; }
        }
    }
}