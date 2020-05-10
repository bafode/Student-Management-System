namespace teklogin
{
    partial class StaticsForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelTotalStudent = new System.Windows.Forms.Panel();
            this.panelTotalMale = new System.Windows.Forms.Panel();
            this.paneltotalFemale = new System.Windows.Forms.Panel();
            this.labelTotalStudent = new System.Windows.Forms.Label();
            this.labelTotalmale = new System.Windows.Forms.Label();
            this.labelTotalFemel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panelTotalStudent.SuspendLayout();
            this.panelTotalMale.SuspendLayout();
            this.paneltotalFemale.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.paneltotalFemale);
            this.panel1.Controls.Add(this.panelTotalMale);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 372);
            this.panel1.TabIndex = 0;
            // 
            // panelTotalStudent
            // 
            this.panelTotalStudent.BackColor = System.Drawing.Color.Red;
            this.panelTotalStudent.Controls.Add(this.labelTotalStudent);
            this.panelTotalStudent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTotalStudent.Location = new System.Drawing.Point(0, 0);
            this.panelTotalStudent.Name = "panelTotalStudent";
            this.panelTotalStudent.Size = new System.Drawing.Size(518, 162);
            this.panelTotalStudent.TabIndex = 1;
            // 
            // panelTotalMale
            // 
            this.panelTotalMale.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panelTotalMale.Controls.Add(this.labelTotalmale);
            this.panelTotalMale.Location = new System.Drawing.Point(0, 168);
            this.panelTotalMale.Name = "panelTotalMale";
            this.panelTotalMale.Size = new System.Drawing.Size(241, 204);
            this.panelTotalMale.TabIndex = 0;
            // 
            // paneltotalFemale
            // 
            this.paneltotalFemale.BackColor = System.Drawing.Color.Yellow;
            this.paneltotalFemale.Controls.Add(this.labelTotalFemel);
            this.paneltotalFemale.Location = new System.Drawing.Point(247, 168);
            this.paneltotalFemale.Name = "paneltotalFemale";
            this.paneltotalFemale.Size = new System.Drawing.Size(270, 203);
            this.paneltotalFemale.TabIndex = 1;
            // 
            // labelTotalStudent
            // 
            this.labelTotalStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalStudent.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalStudent.ForeColor = System.Drawing.Color.White;
            this.labelTotalStudent.Location = new System.Drawing.Point(0, 0);
            this.labelTotalStudent.Name = "labelTotalStudent";
            this.labelTotalStudent.Size = new System.Drawing.Size(518, 162);
            this.labelTotalStudent.TabIndex = 0;
            this.labelTotalStudent.Text = "Total Student:100";
            this.labelTotalStudent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTotalStudent.MouseEnter += new System.EventHandler(this.labelTotalStudent_MouseEnter);
            this.labelTotalStudent.MouseLeave += new System.EventHandler(this.labelTotalStudent_MouseLeave);
            // 
            // labelTotalmale
            // 
            this.labelTotalmale.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalmale.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalmale.ForeColor = System.Drawing.Color.White;
            this.labelTotalmale.Location = new System.Drawing.Point(0, 0);
            this.labelTotalmale.Name = "labelTotalmale";
            this.labelTotalmale.Size = new System.Drawing.Size(241, 204);
            this.labelTotalmale.TabIndex = 0;
            this.labelTotalmale.Text = "Total Male:50";
            this.labelTotalmale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTotalmale.MouseEnter += new System.EventHandler(this.labelTotalmale_MouseEnter);
            this.labelTotalmale.MouseLeave += new System.EventHandler(this.labelTotalmale_MouseLeave);
            // 
            // labelTotalFemel
            // 
            this.labelTotalFemel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelTotalFemel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelTotalFemel.ForeColor = System.Drawing.Color.White;
            this.labelTotalFemel.Location = new System.Drawing.Point(0, 0);
            this.labelTotalFemel.Name = "labelTotalFemel";
            this.labelTotalFemel.Size = new System.Drawing.Size(270, 203);
            this.labelTotalFemel.TabIndex = 1;
            this.labelTotalFemel.Text = "Total Female :50";
            this.labelTotalFemel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelTotalFemel.MouseEnter += new System.EventHandler(this.labelTotalFemel_MouseEnter);
            this.labelTotalFemel.MouseLeave += new System.EventHandler(this.labelTotalFemel_MouseLeave);
            // 
            // StaticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 372);
            this.Controls.Add(this.panelTotalStudent);
            this.Controls.Add(this.panel1);
            this.Name = "StaticsForm";
            this.Text = "StaticsForm";
            this.Load += new System.EventHandler(this.StaticsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panelTotalStudent.ResumeLayout(false);
            this.panelTotalMale.ResumeLayout(false);
            this.paneltotalFemale.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel paneltotalFemale;
        private System.Windows.Forms.Label labelTotalFemel;
        private System.Windows.Forms.Panel panelTotalMale;
        private System.Windows.Forms.Label labelTotalmale;
        private System.Windows.Forms.Panel panelTotalStudent;
        private System.Windows.Forms.Label labelTotalStudent;
    }
}