using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RoboPath
{
    /// <summary>
    /// Class created to output Java class files instead of CSVs so we can use pregenerated paths on the robot
    /// </summary>
    class OutputJava
    {
        private const double Px2InchConversion = 0.17;

        /// <summary>
        /// Method used to write a Java class that contatins the necessary path information
        /// </summary>
        /// <param name="filePath"></param> the save path
        /// <param name="points"></param> the waypoints list
        /// <param name="actions"></param> the actions taken at given waypoints
        public static void write(string filePath, List<Point> points, List<string> actions)
        {
            string[] lines = new string[7];
            string x = "";
            string y = "";
            string distance = "";
            string angle = "";
            string actionStr = "";

            lines[0] = "public class "+ Path.GetFileNameWithoutExtension(filePath)+ " {";

            int i = 0;
            foreach(Point point in points)
            {
                x += ((point.X * Px2InchConversion) + ",");
                y += ((point.Y * Px2InchConversion) + ",");

                try
                {
                    angle += "" + (Math.Atan2((points[i + 1].Y - points[i].Y), (points[i + 1].X - points[i].X)) * 180 / Math.PI) + ",";
                    distance += "" + Math.Sqrt((Math.Pow(Math.Abs(points[i + 1].X - points[i].X), 2)) + (Math.Pow(Math.Abs(points[i + 1].Y - points[i].Y), 2))) + ",";

                }
                catch(ArgumentOutOfRangeException e)
                {

                }

                i++;
            }

            foreach(string action in actions)
            {
                actionStr += "\"" + action + "\",";
            }
            actionStr =  actionStr.Remove(actionStr.Length-1);
            x = x.Remove(x.Length-1);
            y=y.Remove(y.Length-1);
            angle=angle.Remove(angle.Length-1);
            distance=distance.Remove(distance.Length-1);


            lines[1] = "static double[] x = {" + x + "};";
            lines[2] = "static double[] y = {" + y + "};";
            lines[3] = "static double[] angle = {"+ angle + "};";
            lines[4] = "static double[] distance = {" + distance +"};";
            lines[5] = "static String[] actions = {" + actionStr + "};";
            lines[6] = "}";



            //Write array to file
            File.WriteAllLines(filePath, lines);
        }

        /// <summary>
        /// Reads the java file back into the progarm
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static List<Point> read(string filePath)
        {
            string[] lines = System.IO.File.ReadAllLines(filePath);
            List<Point> waypoints = new List<Point>();

            //Variables to store the list
            string x = "";
            string y = "";

            for (int i = 0; i < lines.Length; i++)
            {
                if (i == 1)
                {
                    string tempX = lines[1].Remove(0, 21);
                    tempX = tempX.Remove(tempX.Length - 2);
                    x = tempX;
                }
                if (i == 2)
                {
                    string tempX = lines[2].Remove(0, 21);
                    tempX = tempX.Remove(tempX.Length - 2);
                    y = tempX;
                }
            }

            string[] xArray = x.Split(',');
            string[] yArray = y.Split(',');

            for (int c = 0; c < xArray.Length; c++)
            {
                waypoints.Add(new Point( (int)(double.Parse(xArray[c]) / Px2InchConversion), (int)(double.Parse(yArray[c]) / Px2InchConversion)));
            }
            return waypoints;
        }

       
    }
}
