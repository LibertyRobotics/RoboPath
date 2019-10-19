namespace RoboPath
{
    partial class AddSubsystem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_name = new System.Windows.Forms.Label();
            this.txt_SystemName = new System.Windows.Forms.TextBox();
            this.btn_Add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_name
            // 
            this.lb_name.AutoSize = true;
            this.lb_name.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_name.Location = new System.Drawing.Point(12, 10);
            this.lb_name.Name = "lb_name";
            this.lb_name.Size = new System.Drawing.Size(112, 15);
            this.lb_name.TabIndex = 0;
            this.lb_name.Text = "Subsystem Name:";
            // 
            // txt_SystemName
            // 
            this.txt_SystemName.Location = new System.Drawing.Point(130, 8);
            this.txt_SystemName.Name = "txt_SystemName";
            this.txt_SystemName.Size = new System.Drawing.Size(168, 20);
            this.txt_SystemName.TabIndex = 1;
            this.txt_SystemName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Txt_SystemName_KeyUp);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(304, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 2;
            this.btn_Add.Text = "Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.Btn_Add_Click);
            // 
            // AddSubsystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 35);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.txt_SystemName);
            this.Controls.Add(this.lb_name);
            this.Name = "AddSubsystem";
            this.Text = "Add Subsystem";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_name;
        private System.Windows.Forms.TextBox txt_SystemName;
        private System.Windows.Forms.Button btn_Add;
    }
}