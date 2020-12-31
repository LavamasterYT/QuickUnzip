
namespace QuickUnzip
{
    partial class ExtractWindow
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
            this.lblStatus = new System.Windows.Forms.Label();
            this.prgExtraction = new System.Windows.Forms.ProgressBar();
            this.lblItemsCount = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 9);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(88, 15);
            this.lblStatus.TabIndex = 0;
            this.lblStatus.Text = "Creating files....";
            // 
            // prgExtraction
            // 
            this.prgExtraction.Location = new System.Drawing.Point(12, 28);
            this.prgExtraction.Name = "prgExtraction";
            this.prgExtraction.Size = new System.Drawing.Size(419, 23);
            this.prgExtraction.TabIndex = 1;
            // 
            // lblItemsCount
            // 
            this.lblItemsCount.Location = new System.Drawing.Point(12, 54);
            this.lblItemsCount.Name = "lblItemsCount";
            this.lblItemsCount.Size = new System.Drawing.Size(419, 23);
            this.lblItemsCount.TabIndex = 2;
            this.lblItemsCount.Text = "(0/0)";
            this.lblItemsCount.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ExtractWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 87);
            this.Controls.Add(this.lblItemsCount);
            this.Controls.Add(this.prgExtraction);
            this.Controls.Add(this.lblStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ExtractWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ExtractWindow_FormClosing);
            this.Shown += new System.EventHandler(this.ExtractWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar prgExtraction;
        private System.Windows.Forms.Label lblItemsCount;
    }
}

