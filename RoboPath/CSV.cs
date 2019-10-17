using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace RoboPath
{
    class CSV
    {
        private const double Px2InchConversion = 0.17;

        /// <summary>
        /// Used to write waypoints to CSV file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="points"></param>
        public static void write(string filePath, List<Point> points)
        {
            string[] lines = new string[points.Count+1];
            lines[0] = "X,Y,Angle,Distance,Action";
            int lineNumber = 1;
            int i = 0;
            foreach(Point point in points)
            {
                try
               {
                    //Calculate Angle and distance
                    double angle = ((Math.Atan2((points[i + 1].Y - points[i].Y), (points[i+1].X - points[i].X)) * 180) / Math.PI);
                    double distance = Math.Sqrt((Math.Pow(Math.Abs(points[i+1].X - points[i].X), 2)) + (Math.Pow(Math.Abs(points[i+1].Y - points[i].Y), 2)));
                
                    //Add all data to a new line in the array
                    lines[lineNumber] = string.Format("{0},{1},{2},{3}", point.X * Px2InchConversion, point.Y * Px2InchConversion, angle, distance * Px2InchConversion);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    //If angle and distance cannot be calculated its the last point in the path set both to zero
                    lines[lineNumber] = string.Format("{0},{1},{2},{3}", point.X * Px2InchConversion, point.Y * Px2InchConversion, 0, 0);
                }
                lineNumber++;
                i++;
            }

            //Write array to file
            System.IO.File.WriteAllLines(filePath, lines);
        }
        
        /// <summary>
        /// Read a CSV file containing waypoints
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Point> read(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Point> waypoints = new List<Point>();

            for(int i=0; i < lines.Length; i++)
            {
                if (i > 0)
                {
                    string[] splitLine = lines[i].Split(',');
                    int x = ((int)(double.Parse(splitLine[0]) / Px2InchConversion));
                    int y = ((int)(double.Parse(splitLine[1]) / Px2InchConversion));
                    waypoints.Add(new Point(x,y));

                }
            }

            return waypoints;
           
               
        }
    }

    
}
