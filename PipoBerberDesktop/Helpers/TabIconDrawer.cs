using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PipoBerberDesktop.Helpers
{
    public static class TabIconDrawer
    {
        public static void Draw(TabControl tabControl, List<Image> tabIcons, DrawItemEventArgs e)
        {
            if (e.Index < 0 || e.Index >= tabControl.TabPages.Count)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            Rectangle tabBounds = tabControl.GetTabRect(e.Index);
            TabPage tabPage = tabControl.TabPages[e.Index];

            // Arka plan rengi
            g.FillRectangle(Brushes.White, tabBounds);

            // İkon çizimi
            if (e.Index < tabIcons.Count)
            {
                Image icon = tabIcons[e.Index]; // Her sekme için farklı ikon

                        int iconSize = 24;
                        Rectangle iconRect = new Rectangle(
                            tabBounds.X + 5,
                            tabBounds.Y + (tabBounds.Height - iconSize) / 2,
                            iconSize,
                            iconSize);

                        g.DrawImage(icon, iconRect);

                        // Yazı çizimi
                        using (Font font = new Font("Segoe UI", 10))
                        {
                            Point textPoint = new Point(iconRect.Right + 5, tabBounds.Y + (tabBounds.Height - font.Height) / 2);
                            g.DrawString(tabPage.Text, font, Brushes.Black, textPoint);
                        }
                    
            }
        }
    }
}
