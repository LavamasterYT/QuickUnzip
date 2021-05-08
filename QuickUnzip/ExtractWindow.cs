using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickUnzip
{
    public partial class ExtractWindow : Form
    {
        ArchiveFile file;

        public ExtractWindow(string file)
        {
            InitializeComponent();

            // Set the window startup location to a area a little above the center of the screen
            int x = Screen.PrimaryScreen.WorkingArea.Width / 2 - Width / 2;
            int y = Screen.PrimaryScreen.WorkingArea.Height / 2 - Height / 2;

            Left = x;
            Top = y / 2;

            try
            {
                this.file = new ArchiveFile(file);
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to open file.\n\n" + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            this.Text = "Extracting: " + Path.GetFileName(this.file.ArchivePath);
            lblStatus.Text = "Creating directories and files...";
            lblItemsCount.Text = $"(0/{this.file.ArchiveContentsCount})";
            prgExtraction.Minimum = 0;
            prgExtraction.Value = 0;
            prgExtraction.Maximum = this.file.ArchiveContentsCount;

            this.file.EntryExtracting += File_EntryExtracting;
        }

        private void File_EntryExtracting(object sender, ZipProgressArgs e)
        {
            if (e.Execution == ZipProgressArgsType.Extracting)
            {
                lblItemsCount.Text = $"({e.Index + 1}/{file.ArchiveContentsCount})";
                lblStatus.Text = $"Extracting {file.GetEntry(e.Index)}";
            }
            prgExtraction.Value = e.Index + 1;
        }

        private void ExtractWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            file?.Dispose();
        }
        
        private async void ExtractWindow_Shown(object sender, EventArgs e)
        {
            Exception exl = new Exception();

            await Task.Run(() =>
            {
                try
                {
                    file.Extract();
                }
                catch (Exception ex)
                {
                    exl = ex;
                    MessageBox.Show("Failed to extract file.\n\n" + Convert.ToString(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            });
            Clipboard.SetText(Convert.ToString(exl));
            this.Close();
        }
    }
}
