using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using AmongUsToolbox.Modules;
using AmongUsToolbox.Windows;
using AmongUsToolbox.Windows.Properties;
using MetroFramework;
using MetroFramework.Controls;

namespace AmongUsToolbox.Components
{
    public class ModPanel : MetroPanel
    {
        private MetroLabel _modNameLabel;
        private MetroLabel _modReposirotyLabel;
        private PanelButton _updateButtonComponent;
        private PanelButton _deleteButtonComponent;
        private PictureBox _pictureBox;

        private readonly ModConfig _mod;
        private readonly string _namePrefix;

        public readonly int Index;
        private readonly MainForm _parent;

        public ModPanel(ModConfig mod, int index, MainForm parent)
        {
            Index = index;
            _mod = mod;
            _namePrefix = Helpers.GetRandomString();
            _parent = parent;
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            var y = Index * 50 + 40;

            _modNameLabel = new MetroLabel();
            _modReposirotyLabel = new MetroLabel();
            _updateButtonComponent = new PanelButton();
            _deleteButtonComponent = new PanelButton();
            _pictureBox = new PictureBox();

            _pictureBox.Size = new Size(30, 30);
            _pictureBox.Location = new Point(8, 8);
            _pictureBox.BackgroundImage = Resources.ModIcon;
            _pictureBox.BackColor = Helpers.TransparentColor;

            Controls.Add(_pictureBox);
            Controls.Add(_modNameLabel);
            Controls.Add(_modReposirotyLabel);
            if (_mod.Id != 0)
            {
                Controls.Add(_updateButtonComponent);
                Controls.Add(_deleteButtonComponent);
            }

            Location = new Point(0, y);
            Size = new Size(382, 46);
            HorizontalScrollbarBarColor = false;
            Theme = MetroThemeStyle.Dark;
            VerticalScrollbarBarColor = false;
            UseCustomBackColor = true;
            Name = _namePrefix + "Panel";
            Margin = new Padding(0);
            Padding = new Padding(0);
            BorderStyle = BorderStyle.None;
            Style = MetroColorStyle.Black;
            BackColor = Config.Data.Mods.CurrentModIdx == _mod.Id ? Helpers.RgbaColor(255, 255, 255, 50) : Helpers.HexColor("#393c42");
            Click += OnClick;

            _modNameLabel.Theme = MetroThemeStyle.Dark;
            _modNameLabel.Location = new Point(46, 3);
            _modNameLabel.Size = new Size(204, 20);
            _modNameLabel.UseCustomBackColor = true;
            _modNameLabel.BackColor = Helpers.TransparentColor;
            _modNameLabel.FontWeight = MetroLabelWeight.Bold;
            _modNameLabel.Name = _namePrefix + "NameLabel";
            _modNameLabel.Text = _mod.Repository;
            _modNameLabel.Click += OnClick;

            _modReposirotyLabel.Location = new Point(46, 23);
            _modReposirotyLabel.Size = new Size(204, 20);
            _modReposirotyLabel.Theme = MetroThemeStyle.Dark;
            _modReposirotyLabel.UseCustomBackColor = true;
            _modReposirotyLabel.BackColor = Helpers.TransparentColor;
            _modReposirotyLabel.Name = _namePrefix + "UrlLabel";
            _modReposirotyLabel.Text = $@"{_mod.Owner}/{_mod.Repository}";
            _modReposirotyLabel.Click += OnClick;

            _updateButtonComponent.Location = new Point(306, 5);
            _updateButtonComponent.BackgroundImage = Resources.UpdateIcon;
            _updateButtonComponent.Click += UpdateButtonComponent_Click;

            _deleteButtonComponent.Location = new Point(344, 5);
            _deleteButtonComponent.BackgroundImage = Resources.RemoveIcon;
            _deleteButtonComponent.Click += DeleteButtonComponent_Click;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (_mod.Id == null) return;
            if (Config.Data.Mods.CurrentModIdx == _mod.Id) return;
            if (Config.Data.AmongUsFolderPath == null) return;
            
            Console.WriteLine(AmongUs.IsRunning());
            if (AmongUs.IsRunning())
            {
                MetroMessageBox.Show(_parent, string.Format(Resources.InstallErrorGameRunning),
                    Resources.InstallErrorGameRunningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            AmongUs.InstallMod((int)_mod.Id);
            Console.WriteLine(Config.Data.Mods.CurrentModIdx);
            _parent.ReloadMods();
        }

        private void UpdateButtonComponent_Click(object sender, EventArgs e)
        {
            if (Config.Data.Mods.CurrentModIdx == _mod.Id)
            {
                if (AmongUs.IsRunning())
                {
                    MetroMessageBox.Show(_parent, string.Format(Resources.ModDeletionErrorGameRunning),
                        Resources.ModDeletionErrorGameRunningTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                AmongUs.UninstallMod();
                _parent.ReloadMods();
            }
            
            //TODO Update mod
            var form = new ModInstallerForm(_parent, _mod);
            form.ShowDialog();
        }

        private void DeleteButtonComponent_Click(object sender, EventArgs e)
        {
            if (Config.Data.Mods.CurrentModIdx == _mod.Id)
            {
                if (AmongUs.IsRunning())
                {
                    MetroMessageBox.Show(_parent, string.Format(Resources.ModDeletionErrorGameRunning),
                        Resources.ModDeletionErrorGameRunningTitle,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AmongUs.UninstallMod();
                _parent.ReloadMods();
            }

            var modPath = Path.Combine("mods", _mod.Owner.ToLower(), _mod.Repository.ToLower());
            var ownerPath = new DirectoryInfo(Path.Combine("mods", _mod.Owner.ToLower()));
            Console.WriteLine(modPath);
            Directory.Delete(modPath, true);
            if (ownerPath.GetDirectories().Length == 0 && ownerPath.GetFiles().Length == 0)
            {
                Directory.Delete(ownerPath.FullName);
            }
            Config.Data.Mods.Mods.RemoveAt(Index);
            Config.Data.Save();
            _parent.ReloadMods();
        }
    }
}