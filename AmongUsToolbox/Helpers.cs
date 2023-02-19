using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AmongUsToolbox;

public static class Helpers
{
    
    public const int WM_NCLBUTTONDOWN = 0xA1;
    public const int HT_CAPTION = 0x2;
    
    public static Color TransparentColor = RgbaColor(0, 0, 0, 0);
    
    public static Color RgbaColor(int r, int g, int b, int a = 255)
    {
        return Color.FromArgb((byte)(a), (byte)(r), (byte)(g), (byte)(b));
    }

    public static Color HexColor(string hexColor, int alpha = 255)
    {
        if (hexColor.IndexOf('#') != -1)
            hexColor = hexColor.Replace("#", "");
 
        int red = 0;
        int green = 0;
        int blue = 0;
 
        if (hexColor.Length == 6)
        {
            red = int.Parse(hexColor.Substring(0, 2), NumberStyles.AllowHexSpecifier);
            green = int.Parse(hexColor.Substring(2, 2), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(hexColor.Substring(4, 2), NumberStyles.AllowHexSpecifier);
        }
        else if (hexColor.Length == 3)
        {
            red = int.Parse(hexColor[0] + hexColor[0].ToString(), NumberStyles.AllowHexSpecifier);
            green = int.Parse(hexColor[1] + hexColor[1].ToString(), NumberStyles.AllowHexSpecifier);
            blue = int.Parse(hexColor[2] + hexColor[2].ToString(), NumberStyles.AllowHexSpecifier);
        }
 
        return Color.FromArgb(alpha, red, green, blue);
    }

    public static int AutoWidth(Form form, Button button)
    {
        using Graphics cg = form.CreateGraphics();
        SizeF size = cg.MeasureString(button.Text, button.Font);
        return (int)size.Width;
    }
    
    public static bool IsDirectoryWritable(string dirPath, bool throwIfFails = false)
    {
        try
        {
            using (File.Create(
                       Path.Combine(
                           dirPath, 
                           Path.GetRandomFileName()
                       ), 
                       1,
                       FileOptions.DeleteOnClose))
            { }

            return true;
        }
        catch
        {
            if (throwIfFails) throw;
            return false;
        }
    }

    public static string GetLocalLowDirectoryPath()
    {
        return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData", "LocalLow");
    }
    
    public static string GetRandomString(int length = 7)
    {
        StringBuilder str_build = new StringBuilder();  
        Random random = new Random();

        for (int i = 0; i < length; i++)
        {
            double flt = random.NextDouble();
            int shift = Convert.ToInt32(Math.Floor(25 * flt));
            var letter = Convert.ToChar(shift + 65);
            str_build.Append(letter);  
        }

        return str_build.ToString();
    }
    
    public static string ColorToHex(Color c)
    {
        return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
    }
}