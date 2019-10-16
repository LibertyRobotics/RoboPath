using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoboPath
{
    class OutputToCSV
    {
        private const double Px2InchConversion = 0.17;
        public static void write(string filePath, List<Point> points, List<double> angles, List<double> distances)
        {
            string[] lines = new string[points.Count];
            int i = 0;
            foreach(Point point in points)
            {
                try
                {
                    lines[i] = string.Format("{0},{1},{2},{3}", point.X * Px2InchConversion, point.Y * Px2InchConversion, angles[i], distances[i] * Px2InchConversion);
                }
                catch(Exception e)
                {
                    lines[i] = string.Format("{0},{1},{2},{3}", point.X * Px2InchConversion, point.Y * Px2InchConversion, 0, 0);
                }
                i++;
            }

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}
