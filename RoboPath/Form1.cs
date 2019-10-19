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
        private List<string> actions = new List<string>();
        
        //Current mousePosition variable
        private Point mousePosition;

        private int selectedWaypoint = -1;

        //Current placement status
        private PlacementStatus placementStatus = PlacementStatus.NONE;
       
        public Form1()
        {
            this.MaximizeBox = false;
            InitializeComponent();

            try
            {
                foreach (string item in Properties.Settings.Default.SavedActions)
                {
                    runnableSubsytemsList.Items.Add(item);
                    runSubsystemToolStripMenuItem.DropDownItems.Add(item);
                }
            }
            catch(NullReferenceException e)
            {

            }

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
                //Reset selected waypoint
                selectedWaypoint = -1;

                //Adds points to the list when in placing mode
                if (placementStatus == PlacementStatus.PLACING)
                {
                    double angle = 0;
                    double distance = 0;
                    points.Add(mousePosition);
                    actions.Add("Normal");
                    

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

            //Open a context menu to add allow addition of running subsytems to waypoints
            else if(((MouseEventArgs)e).Button == MouseButtons.Right && placementStatus == PlacementStatus.NONE)
            {
                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i].X > mousePosition.X - 4 && points[i].X < mousePosition.X + 4)
                    {
                        if (points[i].Y > mousePosition.Y - 4 && points[i].Y < mousePosition.Y + 4)
                        {
                            waypointOptions.Show(pictureBox1, mousePosition);
                            selectedWaypoint = i;
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

        /// <summary>
        /// Called when the user wants to save a waypoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SavePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(points.Count>0)
                saveWaypoints();
            else
                MessageBox.Show("No Points Plotted", "Error");
        }

        /// <summary>
        /// Called when the user wants to open a waypoints file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                    CSV.write(waypointSaveDirectory.FileName, points, actions);
                }
            }
            else
            {
                CSV.write(waypointSaveDirectory.FileName, points, actions);
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


        /// <summary>
        /// Add a subsytem to the add subsystems window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TestAddSubystem_Click(object sender, EventArgs e)
        {
            AddSubsystem addSubsystem = new AddSubsystem(this);
            addSubsystem.ShowDialog();
            
        }

        /// <summary>
        /// Method used to add an item to the list box
        /// </summary>
        /// <param name="name"></param>
        public void addItem(string name)
        {
            runnableSubsytemsList.Items.Add(name);
            runSubsystemToolStripMenuItem.DropDownItems.Add(name);
            Properties.Settings.Default.SavedActions.Add(name);
            Properties.Settings.Default.Save();
        }


        /// <summary>
        /// Removes selected values from list, and removes value for persistant storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_RemoveSubsystem_Click(object sender, EventArgs e)
        {
            if (runnableSubsytemsList.SelectedItems.Count > 0)
            {
                runnableSubsytemsList.Items.RemoveAt(runnableSubsytemsList.SelectedIndex);
                Properties.Settings.Default.SavedActions.Clear();
                
                runSubsystemToolStripMenuItem.DropDownItems.Clear();
                foreach(string action in runnableSubsytemsList.Items)
                {
                    runSubsystemToolStripMenuItem.DropDownItems.Add(action);
                    Properties.Settings.Default.SavedActions.Add(action);
                }
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// Called when one of the actions is selected to be added to the current waypoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunSubsystemToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (selectedWaypoint > 0)
                actions[selectedWaypoint] = e.ClickedItem.Text;
            else
                actions[selectedWaypoint] = e.ClickedItem.Text;
        }

        /// <summary>
        /// Clear the current path and make a new one, make sure changes are saved first
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewPathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (checkSave() || points.Count <= 0)
            {
                points.Clear();
                pictureBox1.Invalidate();
            }
            else
            {
                if(MessageBox.Show("You may have unsaved changes are you sure you wish to proceed?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    points.Clear();
                    pictureBox1.Invalidate();
                }
            }
        }

        /// <summary>
        /// Checks if the current path has been saved, and return true or false accordingly 
        /// </summary>
        private bool checkSave()
        {
            if(waypointSaveDirectory.FileName.Length <= 0)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Added A Save Changes checker on closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkSave() == false && points.Count > 0)
            {
                if (MessageBox.Show("You may have unsaved changes are you sure you wish to proceed?", "Save Changes", MessageBoxButtons.YesNo) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
            {
               
            }
        }

        /// <summary>
        /// Exit button, self explanatory 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
