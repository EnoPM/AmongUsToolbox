using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using AmongUsToolbox.Windows.Properties;
using MetroFramework;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AmongUsToolbox.Windows;

public partial class ConfigForm : MetroFramework.Forms.MetroForm
{
    private CommonOpenFileDialog FolderSelector;
    private readonly MainForm _parent;

    private readonly PictureBox _appIcon = new();

    public ConfigForm(MainForm parent)
    {
        _parent = parent;
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
        
        BackColor = _parent.BackColor;
        ForeColor = _parent.ForeColor;
        FormBorderStyle = _parent.FormBorderStyle;
        AutoScaleMode = _parent.AutoScaleMode;
        MaximizeBox = _parent.MaximizeBox;
        titleLabel.Text = Resources.Settings + @" - " + _parent.Text;

        folderSelectorButton.Text = Resources.SelectAmongUsFolder;
        RefreshAmongUsFolderValue();

        debugModeCheckbox.Text = Resources.EnableDebugMode;
        debugModeCheckbox.Checked = Config.Data.DebugMode;
        selectFolderLabel.Text = Resources.SelectFolderLabel;
        debugModeCheckbox.Visible = false;
    }

    private void RefreshAmongUsFolderValue()
    {
        amongUsFolderValue.Text = Config.Data.AmongUsFolderPath;
    }

    private void debugModeCheckbox_CheckedChanged(object sender, EventArgs e)
    {
        Config.Data.DebugMode = debugModeCheckbox.Checked;
        Config.Data.Save();
    }

    private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        _parent.ClearConfigForm();
    }

    private void folderSelectorButton_Click(object sender, EventArgs e)
    {
        FolderSelector = new CommonOpenFileDialog();
        FolderSelector.IsFolderPicker = true;
        FolderSelector.Multiselect = false;
        CommonFileDialogResult result = FolderSelector.ShowDialog();
        FocusMe();
        if (result != CommonFileDialogResult.Ok) return;
        var filePath = FolderSelector.FileName;
        if (!Helpers.IsDirectoryWritable(filePath))
        {
            MetroMessageBox.Show(this, string.Format(Resources.DirectoryNotWritableMessage, filePath),
                Resources.DirectoryNotWritableTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Config.Data.AmongUsFolderPath = filePath;
        Config.Data.Save();
        RefreshAmongUsFolderValue();
    }

    private void titleLabel_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;
        ReleaseCapture();
        SendMessage(Handle, Helpers.WM_NCLBUTTONDOWN, Helpers.HT_CAPTION, 0);
    }

    [DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();
}