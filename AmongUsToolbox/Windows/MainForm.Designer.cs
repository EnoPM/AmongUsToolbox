using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace AmongUsToolbox.Windows
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.headerMenu = new System.Windows.Forms.Panel();
            this.applyRegionsButton = new MetroFramework.Controls.MetroButton();
            this.settingsButton = new MetroFramework.Controls.MetroButton();
            this.mainTabControl = new MetroFramework.Controls.MetroTabControl();
            this.modsPage = new MetroFramework.Controls.MetroTabPage();
            this.addModButton = new MetroFramework.Controls.MetroButton();
            this.regionsPage = new MetroFramework.Controls.MetroTabPage();
            this.addPrivateServerButton = new MetroFramework.Controls.MetroButton();
            this.titleLabel = new MetroFramework.Controls.MetroLabel();
            this.headerMenu.SuspendLayout();
            this.mainTabControl.SuspendLayout();
            this.modsPage.SuspendLayout();
            this.regionsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerMenu
            // 
            this.headerMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(41)))));
            this.headerMenu.Controls.Add(this.applyRegionsButton);
            this.headerMenu.Controls.Add(this.settingsButton);
            resources.ApplyResources(this.headerMenu, "headerMenu");
            this.headerMenu.Name = "headerMenu";
            this.headerMenu.TabStop = true;
            // 
            // applyRegionsButton
            // 
            resources.ApplyResources(this.applyRegionsButton, "applyRegionsButton");
            this.applyRegionsButton.Name = "applyRegionsButton";
            this.applyRegionsButton.TabStop = false;
            this.applyRegionsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.applyRegionsButton.UseSelectable = true;
            this.applyRegionsButton.Click += new System.EventHandler(this.applyRegionsButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.settingsButton, "settingsButton");
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.TabStop = false;
            this.settingsButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.settingsButton.UseSelectable = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // mainTabControl
            // 
            resources.ApplyResources(this.mainTabControl, "mainTabControl");
            this.mainTabControl.Controls.Add(this.modsPage);
            this.mainTabControl.Controls.Add(this.regionsPage);
            this.mainTabControl.Multiline = true;
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.mainTabControl.Style = MetroFramework.MetroColorStyle.Blue;
            this.mainTabControl.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.mainTabControl.UseSelectable = true;
            this.mainTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.mainTabControl_Selected);
            // 
            // modsPage
            // 
            resources.ApplyResources(this.modsPage, "modsPage");
            this.modsPage.Controls.Add(this.addModButton);
            this.modsPage.HorizontalScrollbar = true;
            this.modsPage.HorizontalScrollbarBarColor = true;
            this.modsPage.HorizontalScrollbarHighlightOnWheel = false;
            this.modsPage.HorizontalScrollbarSize = 10;
            this.modsPage.Name = "modsPage";
            this.modsPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.modsPage.UseVisualStyleBackColor = true;
            this.modsPage.VerticalScrollbar = true;
            this.modsPage.VerticalScrollbarBarColor = true;
            this.modsPage.VerticalScrollbarHighlightOnWheel = false;
            this.modsPage.VerticalScrollbarSize = 10;
            // 
            // addModButton
            // 
            this.addModButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            resources.ApplyResources(this.addModButton, "addModButton");
            this.addModButton.Name = "addModButton";
            this.addModButton.Style = MetroFramework.MetroColorStyle.Orange;
            this.addModButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addModButton.UseSelectable = true;
            this.addModButton.UseStyleColors = true;
            this.addModButton.Click += new System.EventHandler(this.addModButton_Click);
            // 
            // regionsPage
            // 
            resources.ApplyResources(this.regionsPage, "regionsPage");
            this.regionsPage.BackColor = System.Drawing.Color.Gray;
            this.regionsPage.Controls.Add(this.addPrivateServerButton);
            this.regionsPage.HorizontalScrollbar = true;
            this.regionsPage.HorizontalScrollbarBarColor = true;
            this.regionsPage.HorizontalScrollbarHighlightOnWheel = false;
            this.regionsPage.HorizontalScrollbarSize = 10;
            this.regionsPage.Name = "regionsPage";
            this.regionsPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.regionsPage.UseCustomBackColor = true;
            this.regionsPage.VerticalScrollbar = true;
            this.regionsPage.VerticalScrollbarBarColor = true;
            this.regionsPage.VerticalScrollbarHighlightOnWheel = false;
            this.regionsPage.VerticalScrollbarSize = 10;
            // 
            // addPrivateServerButton
            // 
            this.addPrivateServerButton.FontSize = MetroFramework.MetroButtonSize.Medium;
            resources.ApplyResources(this.addPrivateServerButton, "addPrivateServerButton");
            this.addPrivateServerButton.Name = "addPrivateServerButton";
            this.addPrivateServerButton.Style = MetroFramework.MetroColorStyle.Green;
            this.addPrivateServerButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.addPrivateServerButton.UseSelectable = true;
            this.addPrivateServerButton.UseStyleColors = true;
            this.addPrivateServerButton.Click += new System.EventHandler(this.addPrivateServerButton_Click);
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Style = MetroFramework.MetroColorStyle.Blue;
            this.titleLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.titleLabel.UseStyleColors = true;
            this.titleLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.titleLabel_MouseDown);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.mainTabControl);
            this.Controls.Add(this.headerMenu);
            this.DisplayHeader = false;
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.headerMenu.ResumeLayout(false);
            this.mainTabControl.ResumeLayout(false);
            this.modsPage.ResumeLayout(false);
            this.regionsPage.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        private MetroFramework.Controls.MetroButton addModButton;

        private MetroFramework.Controls.MetroButton addPrivateServerButton;

        private MetroFramework.Controls.MetroButton applyRegionsButton;

        private MetroFramework.Controls.MetroLabel titleLabel;

        private MetroFramework.Controls.MetroTabControl mainTabControl;
        private MetroFramework.Controls.MetroTabPage modsPage;
        private MetroFramework.Controls.MetroTabPage regionsPage;

        private MetroFramework.Controls.MetroButton settingsButton;

        private System.Windows.Forms.Panel headerMenu;

        #endregion
    }
}