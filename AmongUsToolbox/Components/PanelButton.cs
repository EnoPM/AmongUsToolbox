using System.Drawing;
using System.Windows.Forms;

namespace AmongUsToolbox.Components;

public class PanelButton : Button
{
    public PanelButton()
    {
        InitializeComponents();
    }

    private void InitializeComponents()
    {
        Size = new Size(36, 36);
        BackgroundImageLayout = ImageLayout.Center;
        FlatStyle = FlatStyle.Flat;
        FlatAppearance.BorderSize = 0;
        BackColor = Helpers.TransparentColor;
        ForeColor = Helpers.TransparentColor;
        FlatAppearance.MouseDownBackColor = Helpers.TransparentColor;
        FlatAppearance.MouseOverBackColor = Helpers.TransparentColor;
        FlatAppearance.BorderColor = Helpers.RgbaColor(255, 255, 255, 50);
        Cursor = Cursors.Hand;
    }
    
    protected override bool ShowFocusCues => false;
}