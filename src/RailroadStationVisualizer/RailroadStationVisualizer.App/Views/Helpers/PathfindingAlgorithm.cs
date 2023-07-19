using RailroadStationVisualizer.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStationVisualizer.App.Views.Helpers
{
    public class PathfindingAlgorithm : IPathfindingAlgorithm
    {
        public RailwaySection[] GetPathBetweenTwoSections(RailwaySection beginSection, RailwaySection endSection) {

            var firstPathElement = new PathElement(beginSection, null);
            var linkedPathElements = GetLinkedPathElements(firstPathElement);
            var queue = new Queue<PathElement>(linkedPathElements);
            var shortestPath = double.MaxValue;

            var dictionary = new Dictionary<int, Element>();

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

                var connectedPathElements = GetLinkedPathElements(currentElement);
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

        private static PathElement[] GetLinkedPathElements(PathElement pathElement) {
            var connectedSections = new List<PathElement>();

            if (pathElement.FromPointId == null || pathElement.FromPointId != pathElement.Section.Start.Id) {
                var startPathElements = pathElement.Section.Start.Sections
                    .Where(x => x.Id != pathElement.Section.Id && !pathElement.Ids.Contains(x.Id))
                    .Select(x => new PathElement(x, pathElement));
                connectedSections.AddRange(startPathElements);
            }

            if (pathElement.FromPointId == null || pathElement.FromPointId != pathElement.Section.End.Id) {
                var endPathElements = pathElement.Section.End.Sections
                    .Where(x => x.Id != pathElement.Section.Id && !pathElement.Ids.Contains(x.Id))
                    .Select(x => new PathElement(x, pathElement));
                connectedSections.AddRange(endPathElements);
            }

            return connectedSections.ToArray();
        }

        private class PathElement
        {
            public PathElement(RailwaySection section, PathElement? previous) {
                Section = section;
                Section.IsVisited = true;
                Previous = previous;
                if (previous != null) {
                    Distance = previous.Distance + previous.Section.Distance;
                    Ids = previous.Ids.Concat(new[] { section.Id }).ToArray();
                    var sectionPointIds = new [] { section.Start.Id, section.End.Id };
                    var previousPoints = new[] { previous.Section.Start.Id, previous.Section.End.Id };
                    foreach (var sectionPointId in sectionPointIds) {
                        if (previousPoints.All(x => x != sectionPointId)) {
                            continue;
                        }

                        FromPointId = sectionPointId;
                        break;
                    }
                }
                else {
                    Distance = 0;
                    Ids = Array.Empty<int>();
                }
            }

            public int? FromPointId { get; set; }

            public int[] Ids { get; set; }

            public RailwaySection Section { get; set; }

            public PathElement? Previous { get; set; }

            public double Distance { get; set; }
        }

        private class Element
        {
            public int Id { get; set; }
            public double Distance { get; set; }
        }
    }
}