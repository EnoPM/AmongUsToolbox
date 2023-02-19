using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AmongUsToolbox.Components;
using AmongUsToolbox.Modules;
using AmongUsToolbox.Windows.Properties;
using Newtonsoft.Json;
using MetroFramework;

namespace AmongUsToolbox.Windows
{
    public partial class MainForm : MetroFramework.Forms.MetroForm
    {
        private ConfigForm _configForm;
        private RegionEditorForm _regionEditorForm;
        private ModInstallerForm _modInstallerForm;

        private readonly PictureBox _appIcon = new();

        public MainForm()
        {
            InitializeComponent();
            InitializeResources();
        }

        private void InitializeResources()
        {
            titleLabel.Text = Resources.AppName;
            titleLabel.UseCustomForeColor = true;

            _appIcon.BackColor = Helpers.TransparentColor;
            _appIcon.BackgroundImage = Resources.AppIcon;
            _appIcon.BackgroundImageLayout = ImageLayout.Stretch;
            _appIcon.Size = new Size(18, 18);
            _appIcon.Location = new Point(2, 7);
            Controls.Add(_appIcon);
            
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Helpers.HexColor("#2f3136");

            ForeColor = Helpers.HexColor("#b9bbbe");
            Text = Resources.AppName;
            
            modsPage.UseCustomBackColor = true;
            modsPage.BackColor = Helpers.HexColor("#2f3136");
            regionsPage.UseCustomBackColor = true;
            regionsPage.BackColor = Helpers.HexColor("#2f3136");

            settingsButton.Text = Resources.SettingsButton;
            settingsButton.Size = new Size(Helpers.AutoWidth(this, settingsButton) + 45, 31);
            settingsButton.Cursor = Cursors.Hand;

            modsPage.Text = Resources.ModsTitle;
            regionsPage.Text = Resources.RegionsTitle;

            applyRegionsButton.Text = Resources.ApplyRegionsChangesText;
            applyRegionsButton.Size = new Size(Helpers.AutoWidth(this, applyRegionsButton) + 45, 31);
            applyRegionsButton.Location = new Point(headerMenu.Width - applyRegionsButton.Width - 12, 7);
            applyRegionsButton.Visible = false;

            addPrivateServerButton.Text = Resources.AddPrivateServerButtonText;
            addPrivateServerButton.Cursor = Cursors.Hand;
            
            addModButton.Text = Resources.AddModButtonText;
            addModButton.Cursor = Cursors.Hand;

            //var panelTest = new PrivateServerPanel();
            //panelTest.Size = regionsPage.Size with { Height = 40 };
            //regionsPage.Controls.Add(panelTest);
        }

        public void ReloadMods()
        {
            if (Config.Data.Mods.Mods.Count == 0)
            {
                Config.Data.Mods.Mods.Add(ModConfig.GetVanilla());
                Config.Data.Save();
            }
            modsPage.Controls.Clear();
            modsPage.Controls.Add(addModButton);
            var mods = Config.Data.Mods.Mods;
            for (var i = 0; i < mods.Count; i++)
            {
                modsPage.Controls.Add(new ModPanel(mods[i], i, this));
            }
        }

        public void ReloadRegions()
        {
            if (Config.Data.Regions.Regions.Count == 0)
            {
                Config.Data.Regions = AmongUs.GetLocalRegions();
                Config.Data.Save();
            }
            regionsPage.Controls.Clear();
            regionsPage.Controls.Add(addPrivateServerButton);
            var regions = Config.Data.Regions.Regions;
            for (var i = 0; i < regions.Count; i++)
            {
                regionsPage.Controls.Add(new PrivateServerPanel(regions[i], i, this));
            }

            _renderApplyRegionsButton();
        }

        public void ClearConfigForm()
        {
            _configForm = null;
        }

        public void ClearAddRegionForm()
        {
            _regionEditorForm = null;
        }

        public void ClearModInstallerForm()
        {
            _modInstallerForm = null;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Config.Data.DebugMode)
            {
                AllocConsole();
            }

            ReloadRegions();
            ReloadMods();
            _renderTabAnimations();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AllocConsole();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void settingsButton_Click(object sender, EventArgs e)
        {
            if (_configForm != null) return;
            _configForm = new ConfigForm(this);
            _configForm.ShowDialog();
        }

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            ReleaseCapture();
            SendMessage(Handle, Helpers.WM_NCLBUTTONDOWN, Helpers.HT_CAPTION, 0);
        }

        private void mainTabControl_Selected(object sender, TabControlEventArgs e)
        {
            
            _renderApplyRegionsButton();
            _renderTabAnimations();
        }

        private void _renderTabAnimations()
        {
            var tab = mainTabControl.SelectedTab;
            if (tab.Name == modsPage.Name)
            {
                mainTabControl.Style = MetroColorStyle.Orange;
                titleLabel.ForeColor = Color.Orange;
            }
            else if (tab.Name == regionsPage.Name)
            {
                mainTabControl.Style = MetroColorStyle.Green;
                titleLabel.ForeColor = Color.LawnGreen;
            }
        }

        private void _renderApplyRegionsButton()
        {
            applyRegionsButton.Visible = mainTabControl.SelectedTab.Name == regionsPage.Name && Config.Data.UnsavedRegionsChanges;
        }

        private void applyRegionsButton_Click(object sender, EventArgs e)
        {
            if (!AmongUs.IsRunning())
            {
                File.WriteAllText(AmongUs.GetRegionInfoFilePath(), JsonConvert.SerializeObject(Config.Data.Regions));
                Config.Data.UnsavedRegionsChanges = false;
                Config.Data.Save();
                applyRegionsButton.Visible = false;
            }
        }

        private void addPrivateServerButton_Click(object sender, EventArgs e)
        {
            if (_regionEditorForm != null) return;
            _regionEditorForm = new RegionEditorForm(this);
            _regionEditorForm.ShowDialog();
        }

        private void addModButton_Click(object sender, EventArgs e)
        {
            if (_modInstallerForm != null) return;
            _modInstallerForm = new ModInstallerForm(this);
            _modInstallerForm.ShowDialog();
        }
    }
}