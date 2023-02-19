using System.ComponentModel;

namespace AmongUsToolbox.Windows;

partial class ConfigForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
        this.titleLabel = new MetroFramework.Controls.MetroLabel();
        this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
        this.selectFolderLabel = new MetroFramework.Controls.MetroLabel();
        this.debugModeCheckbox = new MetroFramework.Controls.MetroCheckBox();
        this.folderSelectorButton = new MetroFramework.Controls.MetroButton();
        this.amongUsFolderValue = new MetroFramework.Controls.MetroTextBox();
        this.metroPanel1.SuspendLayout();
        this.SuspendLayout();
        // 
        // titleLabel
        // 
        this.titleLabel.Location = new System.Drawing.Point(20, 5);
        this.titleLabel.Name = "titleLabel";
        this.titleLabel.Size = new System.Drawing.Size(492, 22);
        this.titleLabel.Style = MetroFramework.MetroColorStyle.Blue;
        this.titleLabel.TabIndex = 4;
        this.titleLabel.Text = "Among Us Mods Manager";
        this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.titleLabel.UseStyleColors = true;
        this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
        // 
        // metroPanel1
        // 
        this.metroPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
        this.metroPanel1.Controls.Add(this.selectFolderLabel);
        this.metroPanel1.Controls.Add(this.debugModeCheckbox);
        this.metroPanel1.Controls.Add(this.folderSelectorButton);
        this.metroPanel1.Controls.Add(this.amongUsFolderValue);
        this.metroPanel1.HorizontalScrollbarBarColor = true;
        this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
        this.metroPanel1.HorizontalScrollbarSize = 10;
        this.metroPanel1.Location = new System.Drawing.Point(0, 27);
        this.metroPanel1.Margin = new System.Windows.Forms.Padding(0);
        this.metroPanel1.Name = "metroPanel1";
        this.metroPanel1.Size = new System.Drawing.Size(574, 123);
        this.metroPanel1.TabIndex = 5;
        this.metroPanel1.UseCustomBackColor = true;
        this.metroPanel1.VerticalScrollbarBarColor = true;
        this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
        this.metroPanel1.VerticalScrollbarSize = 10;
        // 
        // selectFolderLabel
        // 
        this.selectFolderLabel.BackColor = System.Drawing.Color.Transparent;
        this.selectFolderLabel.Location = new System.Drawing.Point(6, 3);
        this.selectFolderLabel.Margin = new System.Windows.Forms.Padding(0);
        this.selectFolderLabel.Name = "selectFolderLabel";
        this.selectFolderLabel.Size = new System.Drawing.Size(291, 23);
        this.selectFolderLabel.TabIndex = 5;
        this.selectFolderLabel.Text = "Select your Among Us folder";
        this.selectFolderLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.selectFolderLabel.UseCustomBackColor = true;
        // 
        // debugModeCheckbox
        // 
        this.debugModeCheckbox.BackColor = System.Drawing.Color.Transparent;
        this.debugModeCheckbox.Location = new System.Drawing.Point(6, 85);
        this.debugModeCheckbox.Name = "debugModeCheckbox";
        this.debugModeCheckbox.Size = new System.Drawing.Size(565, 24);
        this.debugModeCheckbox.TabIndex = 4;
        this.debugModeCheckbox.Text = "Enable debug mode";
        this.debugModeCheckbox.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.debugModeCheckbox.UseCustomBackColor = true;
        this.debugModeCheckbox.UseSelectable = true;
        this.debugModeCheckbox.CheckedChanged += new System.EventHandler(this.debugModeCheckbox_CheckedChanged);
        // 
        // folderSelectorButton
        // 
        this.folderSelectorButton.Location = new System.Drawing.Point(4, 56);
        this.folderSelectorButton.Name = "folderSelectorButton";
        this.folderSelectorButton.Size = new System.Drawing.Size(246, 23);
        this.folderSelectorButton.TabIndex = 3;
        this.folderSelectorButton.Text = "Select folder";
        this.folderSelectorButton.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.folderSelectorButton.UseSelectable = true;
        this.folderSelectorButton.Click += new System.EventHandler(this.folderSelectorButton_Click);
        // 
        // amongUsFolderValue
        // 
        // 
        // 
        // 
        this.amongUsFolderValue.CustomButton.Image = null;
        this.amongUsFolderValue.CustomButton.Location = new System.Drawing.Point(544, 1);
        this.amongUsFolderValue.CustomButton.Name = "";
        this.amongUsFolderValue.CustomButton.Size = new System.Drawing.Size(21, 21);
        this.amongUsFolderValue.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
        this.amongUsFolderValue.CustomButton.TabIndex = 1;
        this.amongUsFolderValue.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
        this.amongUsFolderValue.CustomButton.UseSelectable = true;
        this.amongUsFolderValue.CustomButton.Visible = false;
        this.amongUsFolderValue.Lines = new string[0];
        this.amongUsFolderValue.Location = new System.Drawing.Point(6, 29);
        this.amongUsFolderValue.Margin = new System.Windows.Forms.Padding(0);
        this.amongUsFolderValue.MaxLength = 32767;
        this.amongUsFolderValue.Name = "amongUsFolderValue";
        this.amongUsFolderValue.PasswordChar = '\0';
        this.amongUsFolderValue.ReadOnly = true;
        this.amongUsFolderValue.ScrollBars = System.Windows.Forms.ScrollBars.None;
        this.amongUsFolderValue.SelectedText = "";
        this.amongUsFolderValue.SelectionLength = 0;
        this.amongUsFolderValue.SelectionStart = 0;
        this.amongUsFolderValue.ShortcutsEnabled = true;
        this.amongUsFolderValue.Size = new System.Drawing.Size(566, 23);
        this.amongUsFolderValue.TabIndex = 2;
        this.amongUsFolderValue.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.amongUsFolderValue.UseSelectable = true;
        this.amongUsFolderValue.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
        this.amongUsFolderValue.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
        // 
        // ConfigForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(574, 150);
        this.Controls.Add(this.metroPanel1);
        this.Controls.Add(this.titleLabel);
        this.DisplayHeader = false;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.Location = new System.Drawing.Point(15, 15);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "ConfigForm";
        this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
        this.Theme = MetroFramework.MetroThemeStyle.Dark;
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
        this.metroPanel1.ResumeLayout(false);
        this.ResumeLayout(false);
    }

    private MetroFramework.Controls.MetroLabel selectFolderLabel;

    private MetroFramework.Controls.MetroCheckBox debugModeCheckbox;

    private MetroFramework.Controls.MetroButton folderSelectorButton;

    private MetroFramework.Controls.MetroTextBox amongUsFolderValue;

    private MetroFramework.Controls.MetroPanel metroPanel1;

    private MetroFramework.Controls.MetroLabel titleLabel;

    #endregion
}