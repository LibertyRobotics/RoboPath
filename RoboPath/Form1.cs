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
    /// <summary>
    /// Tells the program what the possible current placement statues are
    /// </summary>
    public enum PlacementStatus
    {
        PLACING, REMOVING, NONE
    }

    public partial class Form1 : Form
    {
        //List of waypoints
        private List<Point> points = new List<Point>();
        
        //Current mousePosition variable
        private Point mousePosition;

        //Current placement status
        private PlacementStatus placementStatus = PlacementStatus.NONE;
       
        public Form1()
        {
            InitializeComponent();

            //Allows the form to see all keys pressed when form is in focous and assigns the file open and save to filter csv files
            this.KeyPreview = true;
            waypointSaveDirectory.Filter = "CSV Files (*.csv)|*.csv| All Files(*.*) | *.*";
            openFileDialog1.Filter = "CSV Files (*.csv)|*.csv| All Files(*.*) | *.*";
        }

        /// <summary>
        /// Displays the program about window when the about button in the menu strip is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About aboutBox = new About();
            aboutBox.ShowDialog();
        }

        /// <summary>
        /// Updated whenever the mouse is moved inside the picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            mousePosition = e.Location;
        }

        /// <summary>
        /// Called when a click is registered inside the pictureFrame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (((MouseEventArgs)e).Button == MouseButtons.Left)
            {
                //Adds points to the list when in placing mode
                if (placementStatus == PlacementStatus.PLACING)
                {
                    double angle = 0;
                    double distance = 0;
                    points.Add(mousePosition);


                    pictureBox1.Invalidate();
                }

                //Will remove clicked points when in removal mode
                else if (placementStatus == PlacementStatus.REMOVING)
                {
                    for (int i = 0; i < points.Count; i++)
                    {
                        if (points[i].X > mousePosition.X - 4 && points[i].X < mousePosition.X + 4)
                        {
                            if (points[i].Y > mousePosition.Y - 4 && points[i].Y < mousePosition.Y + 4)
                            {

                                points.RemoveAt(i);

                                pictureBox1.Invalidate();
                            }
                        }
                    }
                }
            }
            else if(((MouseEventArgs)e).Button == MouseButtons.Right && placementStatus == PlacementStatus.NONE)
            {

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

        /// <summary>
        /// Called when the place waypoints button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            placementStatus = PlacementStatus.PLACING;
            label1.Text = "Placing Waypoints, Press 'Esc' To Stop...";
        }

        /// <summary>
        /// Called when the remove waypoints button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            placementStatus = PlacementStatus.REMOVING;
            label1.Text = "Removing Waypoints, Press 'Esc' To Stop...";
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        /// <summary>
        /// Called when any key is pressed on the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
                if(e.KeyCode == Keys.Escape)
                {
                    placementStatus = PlacementStatus.NONE;
                    label1.Text = "";
                }

                if(e.Control && e.KeyCode == Keys.S)
                {
                    saveWaypoints();
                }
        }

        private void SavePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveWaypoints();
        }

        private void OpenPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openWaypoints();
        }

        /// <summary>
        /// Called when the user wishes to save a waypoint set
        /// </summary>
        public void saveWaypoints()
        {
            if (waypointSaveDirectory.FileName.Length <= 0)
            {
                if (waypointSaveDirectory.ShowDialog() == DialogResult.OK)
                {

                    CSV.write(waypointSaveDirectory.FileName, points);
                }
            }
            else
            {
                CSV.write(waypointSaveDirectory.FileName, points);
            }
        }

        /// <summary>
        /// Called when the user wants to open a waypoint file
        /// </summary>
        public void openWaypoints()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                points = CSV.read(openFileDialog1.FileName);
                waypointSaveDirectory.FileName = openFileDialog1.FileName;
                pictureBox1.Invalidate();
            }
        }
    }
}
