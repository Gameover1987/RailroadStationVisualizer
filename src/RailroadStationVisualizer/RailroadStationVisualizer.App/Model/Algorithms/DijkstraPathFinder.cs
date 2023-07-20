using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStationVisualizer.App.Model.Algorithms
{
    /// <summary>
    /// Алгоритм поиска пути, с некоторыми оговорками почти что Дейкстра ))
    /// </summary>
    public class DijkstraPathFinder : IPathFinder
    {
        public RailwaySection[] GetPathBetweenTwoSections(RailwaySection beginSection, RailwaySection endSection) {

            var firstPathElement = new PathElement(beginSection, null);
            var queue = new Queue<PathElement>(new[] { firstPathElement });

            var shortestPath = double.MaxValue;
            PathElement? shortestPathElement = null;

            while (queue.Count > 0) {

                var currentElement = queue.Dequeue();

                if (currentElement.Distance > shortestPath) {
                    continue;
                }

                var linkedPathElements = GetLinkedPathElements(currentElement);
                var endPathElement = linkedPathElements.FirstOrDefault(x => x.Section.Id == endSection.Id);
                if (endPathElement != null) {
                    if (shortestPath > currentElement.Distance) {
                        shortestPath = currentElement.Distance;
                        shortestPathElement = new PathElement(endSection, endPathElement);
                    }
                    continue;
                }

                foreach (var pathElement in linkedPathElements) {
                    queue.Enqueue(pathElement);
                }
            }

            if (shortestPathElement == null) {
                return Array.Empty<RailwaySection>();
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
                    .Where(x => x.Id != pathElement.Section.Id && !pathElement.IsCircleCheck(x.Id))
                    .Select(x => new PathElement(x, pathElement));
                connectedSections.AddRange(startPathElements);
            }

            if (pathElement.FromPointId == null || pathElement.FromPointId != pathElement.Section.End.Id) {
                var endPathElements = pathElement.Section.End.Sections
                    .Where(x => x.Id != pathElement.Section.Id && !pathElement.IsCircleCheck(x.Id))
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

                if (previous == null) {
                    return;
                }

                Distance = previous.Distance + previous.Section.Distance;
                var sectionPointIds = new[] { section.Start.Id, section.End.Id };
                var previousPoints = new[] { previous.Section.Start.Id, previous.Section.End.Id };
                foreach (var sectionPointId in sectionPointIds) {
                    if (previousPoints.All(x => x != sectionPointId)) {
                        continue;
                    }

                    FromPointId = sectionPointId;
                    break;
                }
            }

            public int? FromPointId { get; }

            public RailwaySection Section { get; }

            public PathElement? Previous { get; }

            public double Distance { get; }

            public bool IsCircleCheck(int id) {
                if (Previous == null) {
                    return false;
                }

                if (Section.Id == id) {
                    return true;
                }

                return Previous.IsCircleCheck(id);
            }
        }
    }
}