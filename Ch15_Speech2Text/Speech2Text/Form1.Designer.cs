namespace Speech2Text
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.btnConvert = new System.Windows.Forms.Button();
            this.openFileDialog4 = new System.Windows.Forms.OpenFileDialog();
            this.lblWMVFile = new System.Windows.Forms.Label();
            this.txtWMVFile = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog3";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(829, 324);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(188, 58);
            this.btnConvert.TabIndex = 0;
            this.btnConvert.Text = "Convert";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // openFileDialog4
            // 
            this.openFileDialog4.FileName = "openFileDialog4";
            // 
            // lblWMVFile
            // 
            this.lblWMVFile.AutoSize = true;
            this.lblWMVFile.Location = new System.Drawing.Point(131, 224);
            this.lblWMVFile.Name = "lblWMVFile";
            this.lblWMVFile.Size = new System.Drawing.Size(253, 41);
            this.lblWMVFile.TabIndex = 1;
            this.lblWMVFile.Text = "Provide WMV File";
            // 
            // txtWMVFile
            // 
            this.txtWMVFile.Location = new System.Drawing.Point(429, 221);
            this.txtWMVFile.Name = "txtWMVFile";
            this.txtWMVFile.Size = new System.Drawing.Size(588, 47);
            this.txtWMVFile.TabIndex = 2;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(131, 444);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(94, 41);
            this.lblOutput.TabIndex = 3;
            this.lblOutput.Text = "Text : ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(17F, 41F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1130, 585);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtWMVFile);
            this.Controls.Add(this.lblWMVFile);
            this.Controls.Add(this.btnConvert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private OpenFileDialog openFileDialog3;
        private Button btnConvert;
        private OpenFileDialog openFileDialog4;
        private Label lblWMVFile;
        private TextBox txtWMVFile;
        private Label lblOutput;
    }
}