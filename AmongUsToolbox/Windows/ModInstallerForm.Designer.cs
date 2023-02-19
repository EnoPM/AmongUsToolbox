using System.ComponentModel;

namespace AmongUsToolbox.Windows;

partial class ModInstallerForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModInstallerForm));
        this.titleLabel = new MetroFramework.Controls.MetroLabel();
        this.repoInput = new MetroFramework.Controls.MetroTextBox();
        this.repoLabel = new MetroFramework.Controls.MetroLabel();
        this.submitButton = new MetroFramework.Controls.MetroButton();
        this.downloadProgressBar = new MetroFramework.Controls.MetroProgressBar();
        this.downloadLabel = new MetroFramework.Controls.MetroLabel();
        this.progressionLabel = new MetroFramework.Controls.MetroLabel();
        this.SuspendLayout();
        // 
        // titleLabel
        // 
        resources.ApplyResources(this.titleLabel, "titleLabel");
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Style = MetroFramework.MetroColorStyle.Brown;
        this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.titleLabel.UseStyleColors = true;
        this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
        // 
        // repoInput
        // 
        // 
        // 
        // 
        this.repoInput.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
        this.repoInput.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
        this.repoInput.CustomButton.Name = "";
        this.repoInput.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
        this.repoInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.repoInput.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
        this.repoInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.repoInput.CustomButton.UseSelectable = true;
        this.repoInput.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
        this.repoInput.FontSize = MetroFramework.MetroTextBoxSize.Medium;
        this.repoInput.Lines = new string[0];
        resources.ApplyResources(this.repoInput, "repoInput");
        this.repoInput.MaxLength = 32767;
        this.repoInput.Name = "repoInput";
        this.repoInput.PasswordChar = '\0';
        this.repoInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.repoInput.SelectedText = "";
        this.repoInput.SelectionLength = 0;
        this.repoInput.SelectionStart = 0;
        this.repoInput.ShortcutsEnabled = false;
        this.repoInput.Style = MetroFramework.MetroColorStyle.Brown;
        this.repoInput.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.repoInput.UseCustomBackColor = true;
        this.repoInput.UseSelectable = true;
        this.repoInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.repoInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // repoLabel
        // 
        this.repoLabel.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.repoLabel, "repoLabel");
        this.repoLabel.Name = "repoLabel";
        this.repoLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.repoLabel.UseCustomBackColor = true;
        // 
        // submitButton
        // 
        this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
        this.submitButton.ForeColor = System.Drawing.Color.White;
        resources.ApplyResources(this.submitButton, "submitButton");
        this.submitButton.Name = "submitButton";
        this.submitButton.Style = MetroFramework.MetroColorStyle.Green;
        this.submitButton.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.submitButton.UseCustomBackColor = true;
        this.submitButton.UseCustomForeColor = true;
        this.submitButton.UseSelectable = true;
        this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
        // 
        // downloadProgressBar
        // 
        resources.ApplyResources(this.downloadProgressBar, "downloadProgressBar");
        this.downloadProgressBar.Name = "downloadProgressBar";
        this.downloadProgressBar.Style = MetroFramework.MetroColorStyle.Brown;
        this.downloadProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.downloadProgressBar.Click += new System.EventHandler(this.submitButton_Click);
        // 
        // downloadLabel
        // 
        this.downloadLabel.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.downloadLabel, "downloadLabel");
        this.downloadLabel.Name = "downloadLabel";
        this.downloadLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.downloadLabel.UseCustomBackColor = true;
        // 
        // progressionLabel
        // 
        this.progressionLabel.BackColor = System.Drawing.Color.Transparent;
        this.progressionLabel.FontSize = MetroFramework.MetroLabelSize.Small;
        this.progressionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
        resources.ApplyResources(this.progressionLabel, "progressionLabel");
        this.progressionLabel.Name = "progressionLabel";
        this.progressionLabel.Style = MetroFramework.MetroColorStyle.Brown;
        this.progressionLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.progressionLabel.UseCustomBackColor = true;
        this.progressionLabel.UseCustomForeColor = true;
        // 
        // ModInstallerForm
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
        this.Controls.Add(this.progressionLabel);
        this.Controls.Add(this.downloadLabel);
        this.Controls.Add(this.downloadProgressBar);
        this.Controls.Add(this.submitButton);
        this.Controls.Add(this.repoLabel);
        this.Controls.Add(this.repoInput);
        this.Controls.Add(this.titleLabel);
        this.DisplayHeader = false;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ModInstallerForm";
        this.Resizable = false;
        this.Style = MetroFramework.MetroColorStyle.Brown;
        this.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ModInstallerForm_FormClosing);
        this.Load += new System.EventHandler(this.ModInstallerForm_Load);
        this.ResumeLayout(false);
    }

    private MetroFramework.Controls.MetroLabel downloadLabel;
    private MetroFramework.Controls.MetroLabel progressionLabel;

    private MetroFramework.Controls.MetroProgressBar downloadProgressBar;

    private MetroFramework.Controls.MetroButton submitButton;

    private MetroFramework.Controls.MetroLabel repoLabel;

    private MetroFramework.Controls.MetroTextBox repoInput;

    private MetroFramework.Controls.MetroLabel titleLabel;

    #endregion
}