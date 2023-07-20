using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStationVisualizer.App.Model.Algorithms
{
    /// <summary>
    /// Вспомогатльный класс инкапсулирующий в себе логику по построению фигуры для заливки парка
    /// </summary>
    public class RailwayParkVisualizer : IRailwayParkVisualizer
    {
        /// <summary>
        /// Возращает контур в виде коллекции точек из  набора секций для определенного парка
        /// </summary>
        public RailwayPoint[] GetParkPoints(string park, RailwaySection[] sections) {
            var sectionsByPark = sections.Where(x => x.Track.Park == park).ToArray();
            var parkPoints = sectionsByPark
                .SelectMany(x => new[] { x.Start, x.End })
                .Distinct()
                .ToArray();
            var parkPointsByX = parkPoints
                .OrderBy(x => x.X)
                .ThenBy(x => x.Y)
                .ToArray();
            var parkPointsByY = parkPoints
                .OrderBy(x => x.Y)
                .ThenBy(x => x.X)
                .ToArray();

            var topPoint = parkPointsByY.First();
            var rightPoint = parkPointsByX.Last();

            var resultPoints = new List<RailwayPoint>();
            resultPoints.Add(topPoint);

            // 2
            var borderPoints = parkPoints
                .Where(p => p.Y <= rightPoint.Y && p.X >= topPoint.X)
                .Where(p => p.Id != topPoint.Id && p.Id != rightPoint.Id);

            var mainTg = (rightPoint.Y - topPoint.Y) / (rightPoint.X - topPoint.X);
            foreach (var nextPoint in borderPoints) {
                var tg = (rightPoint.Y - nextPoint.Y) / (rightPoint.X - nextPoint.X);
                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                resultPoints.Add(nextPoint);
            }

            resultPoints.Add(rightPoint);

            var bottomRightPoint = parkPointsByY.Last();
            var bottomPoint = parkPointsByY
                .First(t => Math.Abs(t.Y - bottomRightPoint.Y) < double.Epsilon);

            //3
            borderPoints = parkPoints
                .Where(p => p.X >= bottomPoint.X && p.Y >= rightPoint.Y)
                .Where(p => p.Id != rightPoint.Id && p.Id != bottomPoint.Id)
                .OrderByDescending(p => p.X)
                .ThenBy(p => p.Y)
                .ToArray();

            mainTg = (rightPoint.X - bottomPoint.X) / (bottomPoint.Y - rightPoint.Y);
            foreach (var nextPoint in borderPoints) {
                var tg = (nextPoint.X - bottomPoint.X) / (bottomPoint.Y - nextPoint.Y);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                resultPoints.Add(nextPoint);
            }
            resultPoints.Add(bottomPoint);

            var leftPoint = parkPointsByX.First();

            //4
            borderPoints = parkPoints
                .Where(p => p.X <= bottomPoint.X && p.Y >= leftPoint.Y)
                .Where(p => p.Id != bottomPoint.Id && p.Id != leftPoint.Id)
                .OrderByDescending(p => p.Y)
                .ThenByDescending(p => p.X);

            mainTg = (bottomPoint.X - leftPoint.X) / (bottomPoint.Y - leftPoint.Y);
            foreach (var nextPoint in borderPoints) {
                var tg = (bottomPoint.X - nextPoint.X) / (bottomPoint.Y - nextPoint.Y);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                resultPoints.Add(nextPoint);
            }

            resultPoints.Add(leftPoint);

            //1
            borderPoints = parkPoints
                .Where(p => p.X <= topPoint.X && p.Y <= leftPoint.Y)
                .Where(p => p.Id != leftPoint.Id && p.Id != topPoint.Id)
                .OrderBy(p => p.X)
                .ThenByDescending(p => p.Y)
                .ToArray();

            mainTg = (leftPoint.Y - topPoint.Y) / (topPoint.X - leftPoint.X);
            foreach (var nextPoint in borderPoints.Skip(1)) {
                var tg = (leftPoint.Y - nextPoint.Y) / (nextPoint.X - leftPoint.X);

                if (tg < mainTg) {
                    continue;
                }

                mainTg = tg;
                resultPoints.Add(nextPoint);
            }

            return resultPoints.ToArray();
        }
    }
}
