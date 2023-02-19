using System.ComponentModel;

namespace AmongUsToolbox.Windows;

partial class RegionEditorForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionEditorForm));
        this.titleLabel = new MetroFramework.Controls.MetroLabel();
        this.nameInput = new MetroFramework.Controls.MetroTextBox();
        this.nameLabel = new MetroFramework.Controls.MetroLabel();
        this.hostInput = new MetroFramework.Controls.MetroTextBox();
        this.hostLabel = new MetroFramework.Controls.MetroLabel();
        this.portInput = new MetroFramework.Controls.MetroTextBox();
        this.portLabel = new MetroFramework.Controls.MetroLabel();
        this.colorPicker = new System.Windows.Forms.ColorDialog();
        this.colorButton = new MetroFramework.Controls.MetroButton();
        this.disableSslCheckbox = new MetroFramework.Controls.MetroCheckBox();
        this.submitButton = new MetroFramework.Controls.MetroButton();
        this.SuspendLayout();
        // 
        // titleLabel
        // 
        resources.ApplyResources(this.titleLabel, "titleLabel");
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Style = MetroFramework.MetroColorStyle.Green;
        this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.titleLabel.UseStyleColors = true;
        this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
        // 
        // nameInput
        // 
        // 
        // 
        // 
        this.nameInput.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
        this.nameInput.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location")));
        this.nameInput.CustomButton.Name = "";
        this.nameInput.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size")));
        this.nameInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.nameInput.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex")));
        this.nameInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.nameInput.CustomButton.UseSelectable = true;
        this.nameInput.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible")));
        this.nameInput.FontSize = MetroFramework.MetroTextBoxSize.Medium;
        this.nameInput.Lines = new string[0];
        resources.ApplyResources(this.nameInput, "nameInput");
        this.nameInput.MaxLength = 32767;
        this.nameInput.Name = "nameInput";
        this.nameInput.PasswordChar = '\0';
        this.nameInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.nameInput.SelectedText = "";
        this.nameInput.SelectionLength = 0;
        this.nameInput.SelectionStart = 0;
        this.nameInput.ShortcutsEnabled = false;
        this.nameInput.Style = MetroFramework.MetroColorStyle.Green;
        this.nameInput.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.nameInput.UseCustomBackColor = true;
        this.nameInput.UseSelectable = true;
        this.nameInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.nameInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // nameLabel
        // 
        this.nameLabel.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.nameLabel, "nameLabel");
        this.nameLabel.Name = "nameLabel";
        this.nameLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.nameLabel.UseCustomBackColor = true;
        // 
        // hostInput
        // 
        // 
        // 
        // 
        this.hostInput.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
        this.hostInput.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location1")));
        this.hostInput.CustomButton.Name = "";
        this.hostInput.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size1")));
        this.hostInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.hostInput.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex1")));
        this.hostInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.hostInput.CustomButton.UseSelectable = true;
        this.hostInput.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible1")));
        this.hostInput.FontSize = MetroFramework.MetroTextBoxSize.Medium;
        this.hostInput.Lines = new string[0];
        resources.ApplyResources(this.hostInput, "hostInput");
        this.hostInput.MaxLength = 32767;
        this.hostInput.Name = "hostInput";
        this.hostInput.PasswordChar = '\0';
        this.hostInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.hostInput.SelectedText = "";
        this.hostInput.SelectionLength = 0;
        this.hostInput.SelectionStart = 0;
        this.hostInput.ShortcutsEnabled = false;
        this.hostInput.Style = MetroFramework.MetroColorStyle.Green;
        this.hostInput.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.hostInput.UseCustomBackColor = true;
        this.hostInput.UseSelectable = true;
        this.hostInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.hostInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // hostLabel
        // 
        this.hostLabel.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.hostLabel, "hostLabel");
        this.hostLabel.Name = "hostLabel";
        this.hostLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.hostLabel.UseCustomBackColor = true;
        // 
        // portInput
        // 
        // 
        // 
        // 
        this.portInput.CustomButton.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
        this.portInput.CustomButton.Location = ((System.Drawing.Point)(resources.GetObject("resource.Location2")));
        this.portInput.CustomButton.Name = "";
        this.portInput.CustomButton.Size = ((System.Drawing.Size)(resources.GetObject("resource.Size2")));
        this.portInput.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.portInput.CustomButton.TabIndex = ((int)(resources.GetObject("resource.TabIndex2")));
        this.portInput.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.portInput.CustomButton.UseSelectable = true;
        this.portInput.CustomButton.Visible = ((bool)(resources.GetObject("resource.Visible2")));
        this.portInput.FontSize = MetroFramework.MetroTextBoxSize.Medium;
        this.portInput.Lines = new string[0];
        resources.ApplyResources(this.portInput, "portInput");
        this.portInput.MaxLength = 32767;
        this.portInput.Name = "portInput";
        this.portInput.PasswordChar = '\0';
        this.portInput.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.portInput.SelectedText = "";
        this.portInput.SelectionLength = 0;
        this.portInput.SelectionStart = 0;
        this.portInput.ShortcutsEnabled = false;
        this.portInput.Style = MetroFramework.MetroColorStyle.Green;
        this.portInput.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.portInput.UseCustomBackColor = true;
        this.portInput.UseSelectable = true;
        this.portInput.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.portInput.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // portLabel
        // 
        this.portLabel.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.portLabel, "portLabel");
        this.portLabel.Name = "portLabel";
        this.portLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.portLabel.UseCustomBackColor = true;
        // 
        // colorPicker
        // 
        this.colorPicker.Color = System.Drawing.Color.White;
        this.colorPicker.SolidColorOnly = true;
        // 
        // colorButton
        // 
        this.colorButton.BackColor = System.Drawing.Color.White;
        this.colorButton.FontSize = MetroFramework.MetroButtonSize.Medium;
        resources.ApplyResources(this.colorButton, "colorButton");
        this.colorButton.Name = "colorButton";
        this.colorButton.UseCustomBackColor = true;
        this.colorButton.UseSelectable = true;
        this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
        // 
        // disableSslCheckbox
        // 
        this.disableSslCheckbox.BackColor = System.Drawing.Color.Transparent;
        resources.ApplyResources(this.disableSslCheckbox, "disableSslCheckbox");
        this.disableSslCheckbox.Name = "disableSslCheckbox";
        this.disableSslCheckbox.Style = MetroFramework.MetroColorStyle.Green;
        this.disableSslCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.disableSslCheckbox.UseCustomBackColor = true;
        this.disableSslCheckbox.UseSelectable = true;
        // 
        // submitButton
        // 
        this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
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
        // RegionEditorForm
        // 
        resources.ApplyResources(this, "$this");
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
        this.Controls.Add(this.submitButton);
        this.Controls.Add(this.disableSslCheckbox);
        this.Controls.Add(this.colorButton);
        this.Controls.Add(this.portLabel);
        this.Controls.Add(this.portInput);
        this.Controls.Add(this.hostLabel);
        this.Controls.Add(this.hostInput);
        this.Controls.Add(this.nameLabel);
        this.Controls.Add(this.nameInput);
        this.Controls.Add(this.titleLabel);
        this.DisplayHeader = false;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "RegionEditorForm";
        this.Resizable = false;
        this.Style = MetroFramework.MetroColorStyle.Green;
        this.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddRegionForm_FormClosing);
        this.ResumeLayout(false);
    }

    private MetroFramework.Controls.MetroButton submitButton;

    private MetroFramework.Controls.MetroCheckBox disableSslCheckbox;

    private MetroFramework.Controls.MetroButton colorButton;

    private System.Windows.Forms.ColorDialog colorPicker;

    private MetroFramework.Controls.MetroTextBox hostInput;
    private MetroFramework.Controls.MetroLabel hostLabel;
    private MetroFramework.Controls.MetroTextBox portInput;
    private MetroFramework.Controls.MetroLabel portLabel;

    private MetroFramework.Controls.MetroLabel nameLabel;

    private MetroFramework.Controls.MetroTextBox nameInput;

    private MetroFramework.Controls.MetroLabel titleLabel;

    #endregion
}