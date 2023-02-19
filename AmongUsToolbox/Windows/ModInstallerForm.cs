using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using AmongUsToolbox.Modules;
using AmongUsToolbox.Windows.Properties;
using MetroFramework;
using MetroFramework.Forms;

namespace AmongUsToolbox.Windows;

public partial class ModInstallerForm : MetroForm
{
    private readonly MainForm _parent;
    private readonly ModConfig _mod;

    private readonly PictureBox _appIcon = new();

    public ModInstallerForm(MainForm parent, ModConfig mod = null)
    {
        _parent = parent;
        _mod = mod;
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
        
        if (_mod != null)
        {
            repoLabel.Visible = false;
            repoInput.Visible = false;
            submitButton.Visible = false;
        }
        repoLabel.Text = Resources.RepoLabel;
        submitButton.Text = Resources.DownloadModButton;
        titleLabel.Text = Resources.DownloadModTitle + @" - " + Resources.AppName;
        downloadLabel.Text = Resources.DownloadStatus;
    }

    private void ModInstallerForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        _parent.ClearModInstallerForm();
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

    private async void submitButton_Click(object sender, EventArgs e)
    {
        repoInput.WithError = repoInput.Text == "";
        submitButton.Enabled = false;
        var mod = await _downloadMod();
        submitButton.Enabled = true;
        Config.Data.Mods.Mods.Add(mod);
        Config.Data.Save();
        _parent.ReloadMods();
        Close();
    }

    private async Task<ModConfig> _downloadMod()
    {
        var repository = Github.Parse(_mod == null ? repoInput.Text : $"{_mod.Owner.ToLower()}/{_mod.Repository.ToLower()}");
        if (repository.Name == null)
        {
            _showError(Resources.ParseRepositoryErrorTitle, string.Format(Resources.ParseRepositoryError, repoInput.Text));
            return null;
        }

        var release = await Github.GetLatestRelease(repository);
        if (release == null)
        {
            _showError(Resources.UnableToFindRepositoryTitle, string.Format(Resources.UnableToFindRepository + "{0}/{1}", repository.Owner, repository.Name));
            return null;
        }

        var asset = release.GetZipAsset();
        if (asset == null)
        {
            _showError(Resources.UnableToFindAssetTitle, string.Format(Resources.UnableToFindAsset + "{0}/{1}", repository.Owner, repository.Name));
            return null;
        }

        if (_mod != null && release.Id == _mod.Id) return null;

        var zipPath = await Github.DownloadAsset(asset, downloadProgressBar, progressionLabel);
        downloadProgressBar.Value = 0;
        progressionLabel.Text = Resources.DecompressionInProgress;
        Github.CreateModDirectory(repository.Owner, repository.Name, zipPath, downloadProgressBar, progressionLabel);
        return new ModConfig
            { Id = release.Id, Owner = repository.Owner, Repository = repository.Name };
    }

    private void _showError(string title, string message)
    {
        MetroMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async void ModInstallerForm_Load(object sender, EventArgs e)
    {
        if (_mod == null) return;
        var mod = await _downloadMod();
        if (mod != null)
        {
            _mod.Id = mod.Id;
            Config.Data.Save();
        }
        Close();
        _parent.ReloadMods();
    }
}