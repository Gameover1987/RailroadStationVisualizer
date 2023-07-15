using System;
using System.Collections.Generic;
using System.Linq;

namespace RailroadStationVisualizer.App.Model
{
    public class StationSchemaProvider : IStationSchemaProvider
    {
        public StationSchema GetStationSchema() {
            var points = GetRailwayPoints();
            var tracks = GetRailwayTracks(points);

            return new StationSchema {
                StationName = "Кукуево",
                Sections = tracks.SelectMany(x => x.Sections).ToArray()
            };
        }

        private static RailwayPoint[] GetRailwayPoints() {
            int index = 1;
            var railwayPoints = new List<RailwayPoint>();
            // Way 1
            railwayPoints.Add(new RailwayPoint(index++, 161, 119));
            railwayPoints.Add(new RailwayPoint(index++, 232, 119));
            railwayPoints.Add(new RailwayPoint(index++, 300, 119));
            railwayPoints.Add(new RailwayPoint(index++, 316, 106));
            railwayPoints.Add(new RailwayPoint(index++, 461, 106));
            railwayPoints.Add(new RailwayPoint(index++, 477, 119));
            // Way 2
            railwayPoints.Add(new RailwayPoint(index++, 493, 119));
            // Way 3
            railwayPoints.Add(new RailwayPoint(index++, 127, 132));
            railwayPoints.Add(new RailwayPoint(index++, 190, 132));
            railwayPoints.Add(new RailwayPoint(index++, 217, 132));
            // Way 4
            railwayPoints.Add(new RailwayPoint(index++, 243, 132));
            railwayPoints.Add(new RailwayPoint(index++, 256, 123));
            // Way 5
            railwayPoints.Add(new RailwayPoint(index++, 268, 132));
            // Way 6
            railwayPoints.Add(new RailwayPoint(index++, 537, 132));
            // Way 7
            railwayPoints.Add(new RailwayPoint(index++, 571, 132));
            railwayPoints.Add(new RailwayPoint(index++, 588, 145));

            // Way 8
            railwayPoints.Add(new RailwayPoint(index++, 70, 158));
            railwayPoints.Add(new RailwayPoint(index++, 98, 158));
            railwayPoints.Add(new RailwayPoint(index++, 130, 158));
            railwayPoints.Add(new RailwayPoint(index++, 140, 158));
            railwayPoints.Add(new RailwayPoint(index++, 165, 158));
            railwayPoints.Add(new RailwayPoint(index++, 359, 158));

            // Way9
            railwayPoints.Add(new RailwayPoint(index++, 158, 145));
            railwayPoints.Add(new RailwayPoint(index++, 228, 145));

            // Way 10
            railwayPoints.Add(new RailwayPoint(index++, 503, 158));
            railwayPoints.Add(new RailwayPoint(index++, 605, 158));

            // Way 12
            railwayPoints.Add(new RailwayPoint(index++, 0, 171));
            railwayPoints.Add(new RailwayPoint(index++, 116, 171));
            railwayPoints.Add(new RailwayPoint(index++, 143, 171));
            railwayPoints.Add(new RailwayPoint(index++, 585, 171));
            railwayPoints.Add(new RailwayPoint(index++, 622, 171));
            railwayPoints.Add(new RailwayPoint(index++, 700, 171));

            // Way 14
            railwayPoints.Add(new RailwayPoint(index++, 0, 184));
            railwayPoints.Add(new RailwayPoint(index++, 22, 184));
            railwayPoints.Add(new RailwayPoint(index++, 55, 184));
            railwayPoints.Add(new RailwayPoint(index++, 585, 184));
            railwayPoints.Add(new RailwayPoint(index++, 627, 184));
            railwayPoints.Add(new RailwayPoint(index++, 700, 184));

            // Way 15
            railwayPoints.Add(new RailwayPoint(index++, 29, 190));
            railwayPoints.Add(new RailwayPoint(index++, 87, 190));
            railwayPoints.Add(new RailwayPoint(index++, 156, 210));
            railwayPoints.Add(new RailwayPoint(index++, 576, 210));
            railwayPoints.Add(new RailwayPoint(index++, 593, 210));
            railwayPoints.Add(new RailwayPoint(index++, 610, 197));

            railwayPoints.Add(new RailwayPoint(index++, 39, 197));
            railwayPoints.Add(new RailwayPoint(index++, 82, 197));
            railwayPoints.Add(new RailwayPoint(index++, 576, 197));

            return railwayPoints.ToArray();
        }

        private static RailwayTrack[] GetRailwayTracks(RailwayPoint[] points) {
            var index = 1;

            var railwayTrack1 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[0], points[1]),
                    new RailwaySection(index++, points[1], points[2]),
                    new RailwaySection(index++, points[2], points[3]),
                    new RailwaySection(index++, points[3], points[4]),
                    new RailwaySection(index++, points[4], points[5]),
                    new RailwaySection(index++, points[5], points[6])
                }
            };

            var railwayTrack2 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[2], points[5])
                }
            };

            var railwayTrack3 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[7], points[8]),
                    new RailwaySection(index++, points[8], points[9]),
                    new RailwaySection(index++, points[9], points[1])
                }
            };

            var railwayTrack4 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[9], points[10]),
                    new RailwaySection(index++, points[10], points[11]),
                }
            };

            var railwayTrack5 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[10], points[12]),
                }
            };

            var railwayTrack6 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[12], points[13]),
                }
            };

            var railwayTrack7 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[13], points[14]),
                    new RailwaySection(index++, points[14], points[15]),
                }
            };

            var railwayTrack8 = new RailwayTrack {
                Sections = new [] {
                    new RailwaySection(index++, points[16], points[17]),
                    new RailwaySection(index++, points[17], points[18]),
                    new RailwaySection(index++, points[18], points[19]),
                    new RailwaySection(index++, points[19], points[20]),
                    new RailwaySection(index++, points[20], points[21]),
                }
            };

            var railwayTrack9 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[23], points[10]),
                }
            };

            var railwayTrack10 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[19], points[22]),
                    new RailwaySection(index++, points[22], points[23]),
                    new RailwaySection(index++, points[22], points[23]),
                    new RailwaySection(index++, points[23], points[15]),
                    new RailwaySection(index++, points[15], points[25]),
                }
            };

            var railwayTrack11 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[24], points[25]),
                    new RailwaySection(index++, points[25], points[30]),
                }
            };

            var railwayTrack12 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[26], points[27]),
                    new RailwaySection(index++, points[27], points[28]),
                    new RailwaySection(index++, points[27], points[18]),
                }
            };

            var railwayTrack13 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[27], points[28]),
                    new RailwaySection(index++, points[28], points[29]),
                }
            };


            var railwayTrack14 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[29], points[30]),
                    new RailwaySection(index++, points[30], points[31]),
                }
            };

            var railwayTrack15 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[32], points[33]),
                    new RailwaySection(index++, points[33], points[34]),
                }
            };

            var railwayTrack16 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[34], points[35]),
                }
            };
            
            var railwayTrack17 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[34], points[35]),
                }
            };

            var railwayTrack18 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[35], points[36]),
                    new RailwaySection(index++, points[36], points[37]),
                }
            };

            var railwayTrack19 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[33], points[38]),
                    new RailwaySection(index++, points[38], points[39]),
                    new RailwaySection(index++, points[39], points[40]),
                }
            };

            var railwayTrack20 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[40], points[41]),
                }
            };

            var railwayTrack21 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[41], points[42]),
                    new RailwaySection(index++, points[42], points[43]),
                    new RailwaySection(index++, points[43], points[36]),
                }
            };

            var railwayTrack22 = new RailwayTrack {
                Sections = new[] {
                    new RailwaySection(index++, points[38], points[44]),
                    new RailwaySection(index++, points[44], points[45]),
                    new RailwaySection(index++, points[45], points[46]),
                    new RailwaySection(index++, points[46], points[43]),
                }
            };

            return new[] {
                railwayTrack1,
                railwayTrack2,
                railwayTrack3,
                railwayTrack4,
                railwayTrack5,
                railwayTrack6,
                railwayTrack7,
                railwayTrack8,
                railwayTrack9,
                railwayTrack10,
                railwayTrack11,
                railwayTrack12,
                railwayTrack13,
                railwayTrack14,
                railwayTrack15,
                railwayTrack16,
                railwayTrack17,
                railwayTrack18,
                railwayTrack19,
                railwayTrack20,
                railwayTrack21,
                railwayTrack22,
            };
        }

        /// <summary>
        /// Для тестирования производительности
        /// </summary>
        private static RailwayPoint[] GetRandomRailwayPoints() {
            var points = new List<RailwayPoint>();
            var index = 1;
            var rnd = new Random();
            for (int i = 0; i < 10000; i++) {
                var point = new RailwayPoint(index++, rnd.Next(5, 995), rnd.Next(5, 540));
                points.Add(point);
            }
            return points.ToArray();
        }

        /// <summary>
        /// Для тестирования производительности
        /// </summary>
        private static RailwaySection[] GetRandomRailwaySections(RailwayPoint[] points) {
            var index = 1;
            var sections = new List<RailwaySection>();
            var rnd = new Random();
            for (int i = 0; i < 3000; i++) {
                var section = new RailwaySection(index++, points[rnd.Next(10000)], points[rnd.Next(10000)]);
                sections.Add(section);
            }

            return sections.ToArray();
        }
    }
}