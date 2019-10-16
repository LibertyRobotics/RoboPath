using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoboPath
{

    public enum PlacementStatus
    {
        PLACING, REMOVING, NONE
    }

    public partial class Form1 : Form
    {

        private List<Point> points = new List<Point>();
        private List<double> angles = new List<double>();
        private List<double> distances = new List<double>();

        private Point mousePosition;

        private PlacementStatus placementStatus = PlacementStatus.NONE;
       
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.ShowDialog();
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = e.Location;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            //Adds points to the list when in placing mode
            if (placementStatus == PlacementStatus.PLACING)
            {
                double angle = 0;
                double distance = 0;
                points.Add(mousePosition);
                try
                {
                    angle = ((Math.Atan2((mousePosition.Y - points[points.Count - 2].Y), (mousePosition.X - points[points.Count - 2].X)) * 180) / Math.PI);
                    distance = Math.Sqrt((Math.Pow(Math.Abs(mousePosition.X - points[points.Count - 2].X), 2)) + (Math.Pow(Math.Abs(mousePosition.Y - points[points.Count - 2].Y), 2)));
                    angles.Add(angle);
                    distances.Add(distance);
                }
                catch (Exception er)
                {

                }
               
                pictureBox1.Invalidate();
            }

            //Removes the points when not in placing mode
            else if(placementStatus == PlacementStatus.REMOVING)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].X > mousePosition.X - 4 && points[i].X < mousePosition.X + 4)
                    {
                        if (points[i].Y > mousePosition.Y - 4 && points[i].Y < mousePosition.Y + 4)
                        {

                            points.RemoveAt(i);
                            angles.RemoveAt(i);
                            distances.RemoveAt(i);
                            pictureBox1.Invalidate();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Adds visible points to the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int i = 0;
            Graphics g = e.Graphics;

            foreach(Point point in points){
                //Draw a box at the waypoint as well as a number to signify 
                g.DrawString(i.ToString(), new Font("Arial", 7), new SolidBrush(Color.Black), point.X + 5, point.Y - 6);
                g.DrawRectangle(Pens.Red, new Rectangle(point, new Size(3, 3)));
                try
                {
                    g.DrawLine(Pens.Black, point, points[i + 1]);
                }
                catch (Exception)
                {

                }
                i++;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            placementStatus = PlacementStatus.PLACING;
            label1.Text = "Placing Waypoints, Press 'Esc' To Stop...";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            placementStatus = PlacementStatus.REMOVING;
            label1.Text = "Removing Waypoints, Press 'Esc' To Stop...";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                if(e.KeyCode == Keys.Escape)
                {
                    placementStatus = PlacementStatus.NONE;
                    label1.Text = "";
                }
        }

        private void SavePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "CSV (*.csv) | *csv | All Files(*.*) | *.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                OutputToCSV.write(saveFileDialog1.FileName, points, angles, distances);
            }
        }
    }
}
