namespace TraceHogger.UI
{
    partial class MainForm
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
            this.clbTableList = new System.Windows.Forms.CheckedListBox();
            this.btnGetTables = new System.Windows.Forms.Button();
            this.rtbAnalysisResults = new System.Windows.Forms.RichTextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.nudNumberOfRows = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCopyMetrics = new System.Windows.Forms.Button();
            this.btnCopyRows = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRows)).BeginInit();
            this.SuspendLayout();
            // 
            // clbTableList
            // 
            this.clbTableList.CheckOnClick = true;
            this.clbTableList.FormattingEnabled = true;
            this.clbTableList.Location = new System.Drawing.Point(12, 41);
            this.clbTableList.Name = "clbTableList";
            this.clbTableList.Size = new System.Drawing.Size(305, 484);
            this.clbTableList.TabIndex = 0;
            // 
            // btnGetTables
            // 
            this.btnGetTables.Location = new System.Drawing.Point(12, 12);
            this.btnGetTables.Name = "btnGetTables";
            this.btnGetTables.Size = new System.Drawing.Size(305, 23);
            this.btnGetTables.TabIndex = 1;
            this.btnGetTables.Text = "get tables";
            this.btnGetTables.UseVisualStyleBackColor = true;
            this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
            // 
            // rtbAnalysisResults
            // 
            this.rtbAnalysisResults.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbAnalysisResults.Location = new System.Drawing.Point(323, 41);
            this.rtbAnalysisResults.Name = "rtbAnalysisResults";
            this.rtbAnalysisResults.Size = new System.Drawing.Size(931, 484);
            this.rtbAnalysisResults.TabIndex = 2;
            this.rtbAnalysisResults.Text = "";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(323, 12);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(269, 23);
            this.btnAnalyze.TabIndex = 3;
            this.btnAnalyze.Text = "analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // nudNumberOfRows
            // 
            this.nudNumberOfRows.Location = new System.Drawing.Point(1134, 15);
            this.nudNumberOfRows.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudNumberOfRows.Name = "nudNumberOfRows";
            this.nudNumberOfRows.Size = new System.Drawing.Size(120, 20);
            this.nudNumberOfRows.TabIndex = 4;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(598, 12);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(146, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCopyMetrics
            // 
            this.btnCopyMetrics.Location = new System.Drawing.Point(750, 12);
            this.btnCopyMetrics.Name = "btnCopyMetrics";
            this.btnCopyMetrics.Size = new System.Drawing.Size(146, 23);
            this.btnCopyMetrics.TabIndex = 6;
            this.btnCopyMetrics.Text = "copy metrics";
            this.btnCopyMetrics.UseVisualStyleBackColor = true;
            this.btnCopyMetrics.Click += new System.EventHandler(this.btnCopyMetrics_Click);
            // 
            // btnCopyRows
            // 
            this.btnCopyRows.Location = new System.Drawing.Point(902, 12);
            this.btnCopyRows.Name = "btnCopyRows";
            this.btnCopyRows.Size = new System.Drawing.Size(146, 23);
            this.btnCopyRows.TabIndex = 7;
            this.btnCopyRows.Text = "copy rows";
            this.btnCopyRows.UseVisualStyleBackColor = true;
            this.btnCopyRows.Click += new System.EventHandler(this.btnCopyRows_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 540);
            this.Controls.Add(this.btnCopyRows);
            this.Controls.Add(this.btnCopyMetrics);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.nudNumberOfRows);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.rtbAnalysisResults);
            this.Controls.Add(this.btnGetTables);
            this.Controls.Add(this.clbTableList);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nudNumberOfRows)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clbTableList;
        private System.Windows.Forms.Button btnGetTables;
        private System.Windows.Forms.RichTextBox rtbAnalysisResults;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.NumericUpDown nudNumberOfRows;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCopyMetrics;
        private System.Windows.Forms.Button btnCopyRows;
    }
}

