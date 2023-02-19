using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using AmongUsToolbox.Windows;
using AmongUsToolbox.Windows.Properties;
using MetroFramework;
using MetroFramework.Controls;

namespace AmongUsToolbox.Components
{
    public class PrivateServerPanel : MetroPanel
    {
        private MetroLabel RegionNameComponent;
        private MetroLabel RegionUrlComponent;
        private PanelButton EditButtonComponent;
        private PanelButton DeleteButtonComponent;

        private RegionConfig _region;
        private string _namePrefix;

        private string _nameColor;
        private string _name;

        public readonly int Index;
        private readonly MainForm _parent;
        
        public PrivateServerPanel(RegionConfig region, int index, MainForm parent)
        {
            Index = index;
            _region = region;
            _namePrefix = Helpers.GetRandomString();
            _parent = parent;
            _parseName();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            int y = Index * 50 + 40;
            
            RegionNameComponent = new MetroLabel();
            RegionUrlComponent = new MetroLabel();
            EditButtonComponent = new PanelButton();
            DeleteButtonComponent = new PanelButton();
            
            Controls.Add(RegionNameComponent);
            Controls.Add(RegionUrlComponent);
            if (!(_region.PingServer.EndsWith("among.us") && Index < 3))
            {
                Controls.Add(EditButtonComponent);
                Controls.Add(DeleteButtonComponent);
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
            BackColor = Helpers.RgbaColor(255, 255, 255, Config.Data.Regions.CurrentRegionIdx == Index ? 100 : 50);
            Click += OnClick;

            RegionNameComponent.Theme = MetroThemeStyle.Dark;
            RegionNameComponent.Location = new Point(0, 3);
            RegionNameComponent.Size = new Size(250, 20);
            RegionNameComponent.UseCustomBackColor = true;
            RegionNameComponent.BackColor = Helpers.TransparentColor;
            RegionNameComponent.UseCustomForeColor = true;
            RegionNameComponent.ForeColor = Helpers.HexColor(_nameColor);
            RegionNameComponent.FontWeight = MetroLabelWeight.Bold;
            RegionNameComponent.Name = _namePrefix + "NameLabel";
            RegionNameComponent.Text = _name;
            RegionNameComponent.Click += OnClick;

            RegionUrlComponent.Location = new Point(0, 23);
            RegionUrlComponent.Size = new Size(250, 20);
            RegionUrlComponent.Theme = MetroThemeStyle.Dark;
            RegionUrlComponent.UseCustomBackColor = true;
            RegionUrlComponent.BackColor = Helpers.TransparentColor;
            RegionUrlComponent.Name = _namePrefix + "UrlLabel";
            RegionUrlComponent.Text = _region.PingServer;
            RegionUrlComponent.Click += OnClick;
            
            EditButtonComponent.Location = new Point(306, 5);
            EditButtonComponent.BackgroundImage = Resources.EditIcon;
            EditButtonComponent.Click += EditButtonComponent_Click;
            
            DeleteButtonComponent.Location = new Point(344, 5);
            DeleteButtonComponent.BackgroundImage = Resources.RemoveIcon;
            DeleteButtonComponent.Click += DeleteButtonComponent_Click;
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (Config.Data.Regions.CurrentRegionIdx == Index) return;
            Config.Data.Regions.CurrentRegionIdx = Index;
            Config.Data.UnsavedRegionsChanges = true;
            Config.Data.Save();
            _parent.ReloadRegions();
        }

        private void EditButtonComponent_Click(object sender, EventArgs e)
        {
            var form = new RegionEditorForm(_parent, Index, _region, _name, _nameColor);
            form.ShowDialog();
        }

        private void DeleteButtonComponent_Click(object sender, EventArgs e)
        {
            var result = MetroMessageBox.Show(_parent, string.Format(Resources.RegionDeletionMessage, _name), Resources.RegionDeletionTitle,
                MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result != DialogResult.Yes) return;
            Config.Data.Regions.Regions.RemoveAt(Index);
            Config.Data.UnsavedRegionsChanges = true;
            if (Config.Data.Regions.CurrentRegionIdx == Index)
            {
                Config.Data.Regions.CurrentRegionIdx = 0;
            }
            Config.Data.Save();
            _parent.ReloadRegions();
        }

        private void _parseName()
        {
            Regex regex = new Regex(@"^<color=(#[a-f0-9]+)>(.*)<\/color>$", RegexOptions.IgnoreCase);
            Match match = regex.Match(_region.Name);
            if (match.Success)
            {
                _name = match.Groups[2].Value;
                _nameColor = match.Groups[1].Value;
            }
            else
            {
                _name = _region.Name;
                _nameColor = "#ffffff";
            }
        }
    }
}
