using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BlitzPatch
{
    public partial class Gui : Form
    {
        private const string DefaultStatus = "Select your Blitzkrieg 3 directory to continue.";

        public Gui()
        {
            InitializeComponent();
        }

        private void Gui_Load(object sender, EventArgs e)
        {
            LoadSavedGameDirectory();
            ShowPanel(landingPanel);
        }

        private void landingStartButton_Click(object sender, EventArgs e)
        {
            if (!IsValidGameDirectory(textBox1.Text, out var reason))
            {
                SetStatus(reason);
                return;
            }

            SaveGameDirectory(textBox1.Text);
            SetStatus("Opening unit editor...");
            ShowPanel(unitPanel);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            SetStatus(DefaultStatus);
            ShowPanel(landingPanel);
        }

        private void ShowPanel(Panel panelToShow)
        {
            landingPanel.Visible = false;
            unitPanel.Visible = false;

            panelToShow.Visible = true;
            panelToShow.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BrowseForGameDirectory();
        }

        private void BrowseForGameDirectory()
        {
            using (var dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select your Blitzkrieg 3 install directory";
                dialog.ShowNewFolderButton = false;

                if (!string.IsNullOrWhiteSpace(textBox1.Text) && Directory.Exists(textBox1.Text))
                {
                    dialog.SelectedPath = textBox1.Text;
                }

                var result = dialog.ShowDialog(this);
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
                {
                    if (IsValidGameDirectory(dialog.SelectedPath, out var reason))
                    {
                        textBox1.Text = dialog.SelectedPath;
                        SaveGameDirectory(dialog.SelectedPath);
                        SetStatus($"Selected directory: {dialog.SelectedPath}");
                    }
                    else
                    {
                        textBox1.Text = dialog.SelectedPath;
                        SetStatus($"Invalid directory: {reason}");
                    }
                }
                else
                {
                    SetStatus("Browse canceled.");
                }
            }
        }

        private bool IsValidGameDirectory(string path, out string reason)
        {
            reason = DefaultStatus;

            if (string.IsNullOrWhiteSpace(path))
            {
                reason = "Please enter or browse to your Blitzkrieg 3 directory.";
                return false;
            }

            if (!Directory.Exists(path))
            {
                reason = "Directory does not exist.";
                return false;
            }

            var launcherPath = Path.Combine(path, "Launcher.exe");
            if (!File.Exists(launcherPath))
            {
                reason = "Launcher.exe not found in the selected directory.";
                return false;
            }

            var dataPath = Path.Combine(path, "Data");
            if (!Directory.Exists(dataPath))
            {
                reason = "Data folder not found in the selected directory.";
                return false;
            }

            var userFolderExists = Directory.EnumerateDirectories(dataPath, "User_*", SearchOption.TopDirectoryOnly).Any();
            if (!userFolderExists)
            {
                reason = "No Data/User_* folder found.";
                return false;
            }

            reason = "Directory looks good.";
            return true;
        }

        private void SetStatus(string message)
        {
            label1.Text = message;
        }

        private void LoadSavedGameDirectory()
        {
            var saved = Db.LoadGameDirectory();
            if (!string.IsNullOrWhiteSpace(saved) && Directory.Exists(saved))
            {
                textBox1.Text = saved;
                SetStatus($"Loaded saved directory: {saved}");
            }
            else
            {
                SetStatus(DefaultStatus);
            }
        }

        private void SaveGameDirectory(string path)
        {
            Db.SaveGameDirectory(path);
        }
    }
}
