namespace teklogin
{
    partial class PrintScoreForm
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
            this.labelAverage = new System.Windows.Forms.Label();
            this.PrintScore = new System.Windows.Forms.Button();
            this.dataGridViewStudentList = new System.Windows.Forms.DataGridView();
            this.dataGridViewScoreList = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReset = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxCourseList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScoreList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.labelAverage);
            this.panel1.Controls.Add(this.PrintScore);
            this.panel1.Controls.Add(this.dataGridViewStudentList);
            this.panel1.Controls.Add(this.dataGridViewScoreList);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.labelReset);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.listBoxCourseList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 450);
            this.panel1.TabIndex = 0;
            // 
            // labelAverage
            // 
            this.labelAverage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelAverage.ForeColor = System.Drawing.Color.White;
            this.labelAverage.Location = new System.Drawing.Point(231, 374);
            this.labelAverage.Name = "labelAverage";
            this.labelAverage.Size = new System.Drawing.Size(204, 23);
            this.labelAverage.TabIndex = 12;
            this.labelAverage.Text = "Average: 00.00";
            // 
            // PrintScore
            // 
            this.PrintScore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.PrintScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.PrintScore.ForeColor = System.Drawing.Color.White;
            this.PrintScore.Location = new System.Drawing.Point(6, 400);
            this.PrintScore.Name = "PrintScore";
            this.PrintScore.Size = new System.Drawing.Size(861, 47);
            this.PrintScore.TabIndex = 11;
            this.PrintScore.Text = "Print To Text File";
            this.PrintScore.UseVisualStyleBackColor = false;
            this.PrintScore.Click += new System.EventHandler(this.PrintScore_Click);
            // 
            // dataGridViewStudentList
            // 
            this.dataGridViewStudentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewStudentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStudentList.Location = new System.Drawing.Point(628, 56);
            this.dataGridViewStudentList.Name = "dataGridViewStudentList";
            this.dataGridViewStudentList.Size = new System.Drawing.Size(236, 315);
            this.dataGridViewStudentList.TabIndex = 3;
            this.dataGridViewStudentList.Click += new System.EventHandler(this.dataGridViewStudentList_Click);
            // 
            // dataGridViewScoreList
            // 
            this.dataGridViewScoreList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewScoreList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewScoreList.Location = new System.Drawing.Point(235, 56);
            this.dataGridViewScoreList.Name = "dataGridViewScoreList";
            this.dataGridViewScoreList.Size = new System.Drawing.Size(387, 315);
            this.dataGridViewScoreList.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(628, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Student List";
            // 
            // labelReset
            // 
            this.labelReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelReset.ForeColor = System.Drawing.Color.Yellow;
            this.labelReset.Location = new System.Drawing.Point(553, 18);
            this.labelReset.Name = "labelReset";
            this.labelReset.Size = new System.Drawing.Size(69, 23);
            this.labelReset.TabIndex = 1;
            this.labelReset.Text = "Reset";
            this.labelReset.Click += new System.EventHandler(this.labelReset_Click);
            this.labelReset.MouseEnter += new System.EventHandler(this.labelReset_MouseEnter);
            this.labelReset.MouseLeave += new System.EventHandler(this.labelReset_MouseLeave);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(241, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Scores List";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Courses List";
            // 
            // listBoxCourseList
            // 
            this.listBoxCourseList.FormattingEnabled = true;
            this.listBoxCourseList.Location = new System.Drawing.Point(3, 59);
            this.listBoxCourseList.Name = "listBoxCourseList";
            this.listBoxCourseList.Size = new System.Drawing.Size(226, 303);
            this.listBoxCourseList.TabIndex = 0;
            this.listBoxCourseList.Click += new System.EventHandler(this.listBoxCourseList_Click);
            // 
            // PrintScoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(867, 450);
            this.Controls.Add(this.panel1);
            this.Name = "PrintScoreForm";
            this.Text = "PrintScoreForm";
            this.Load += new System.EventHandler(this.PrintScoreForm_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStudentList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewScoreList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridViewScoreList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxCourseList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewStudentList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button PrintScore;
        private System.Windows.Forms.Label labelReset;
        private System.Windows.Forms.Label labelAverage;
    }
}