using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AmongUsToolbox.Windows.Properties;
using MetroFramework.Forms;

namespace AmongUsToolbox.Windows;

public partial class RegionEditorForm : MetroForm
{
    private readonly MainForm _parent;
    private RegionConfig _region;
    private readonly int _index;
    private readonly string _name;
    private readonly string _color;

    private readonly PictureBox _appIcon = new();

    public RegionEditorForm(MainForm parent, int index = -1, RegionConfig region = null, string name = "", string color = "")
    {
        _parent = parent;
        _index = index;
        _region = region;
        _name = name;
        _color = color;
        InitializeComponent();
        InitializeResources();
    }

    private void InitializeResources()
    {
        _appIcon.BackColor = Helpers.TransparentColor;
        _appIcon.BackgroundImage = Resources.AppIcon;
        _appIcon.BackgroundImageLayout = ImageLayout.Stretch;
        _appIcon.Size = new Size(18, 18);
        _appIcon.Location = new Point(2, 7);
        Controls.Add(_appIcon);
        
        nameLabel.Text = Resources.PrivateServerNameLabel;
        hostLabel.Text = Resources.HostLabel;
        disableSslCheckbox.Text = Resources.DisableSslLabel;
        colorButton.Text = Resources.ChooseColorButton;
        colorButton.BackColor = Helpers.HexColor("#ffffff");
        submitButton.Text = Resources.AddRegionButtonText;
        titleLabel.Text = Resources.AddRegionTitle + @" - " + Resources.AppName;
        nameInput.UseCustomForeColor = true;
        nameInput.ForeColor = colorButton.BackColor;
        if (_region != null)
        {
            titleLabel.Text = Resources.UpdateRegionTitle + @" - " + Resources.AppName;
            nameInput.Text = _name;
            colorPicker.Color = Helpers.HexColor(_color);
            colorButton.BackColor = Helpers.HexColor(_color);
            hostInput.Text = _region.PingServer;
            portInput.Text = _region.Servers[0].Port.ToString();
            disableSslCheckbox.Checked = !_region.Servers[0].Ip.StartsWith("https");
            submitButton.Text = Resources.UpdateRegionButtonText;
        }
    }

    private void AddRegionForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _parent.ClearAddRegionForm();
    }

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    private void titleLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        ReleaseCapture();
        SendMessage(Handle, Helpers.WM_NCLBUTTONDOWN, Helpers.HT_CAPTION, 0);
    }

    private void colorButton_Click(object sender, EventArgs e)
    {
        var result = colorPicker.ShowDialog();
        if (result == DialogResult.OK)
        {
            nameInput.ForeColor = colorPicker.Color;
            colorButton.BackColor = colorPicker.Color;
            colorButton.FlatAppearance.BorderColor = colorPicker.Color;
        }
    }

    private void submitButton_Click(object sender, EventArgs e)
    {
        nameInput.WithError = nameInput.Text == "";
        hostInput.WithError = hostInput.Text == "";
        portInput.WithError = portInput.Text == "";
        if (nameInput.WithError || hostInput.WithError || portInput.WithError) return;
        var region = new RegionConfig
        {
            Name = $"<color={Helpers.ColorToHex(colorButton.BackColor)}>{nameInput.Text}</color>",
            PingServer = hostInput.Text
        };
        region.Servers.Add(new RegionServer
        {
            Ip = disableSslCheckbox.Checked ? $"http://{region.PingServer}" : $"https://{region.PingServer}",
            Port = int.Parse(portInput.Text)
        });
        if (_region != null)
        {
            Config.Data.Regions.Regions[_index] = region;
        }
        else
        {
            Config.Data.Regions.Regions.Add(region);
        }
        
        Config.Data.UnsavedRegionsChanges = true;
        Config.Data.Save();
        _parent.ReloadRegions();
        Close();
    }
}