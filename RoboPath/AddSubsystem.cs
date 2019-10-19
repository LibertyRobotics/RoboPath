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
    public partial class AddSubsystem : Form
    {
        Form1 frm;

        public AddSubsystem(Form1 frm)
        {
            this.frm = frm;
            InitializeComponent();
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            addAction();
        }

        /// <summary>
        /// Method used to acutally add the name to the list
        /// </summary>
        private void addAction()
        {
            if (txt_SystemName.TextLength > 0)
            {
                frm.addItem(txt_SystemName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Input A Name", "Error");
            }
        }

        /// <summary>
        /// Allows enter to submit the name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_SystemName_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                addAction();
            }
        }
    }
}
