using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    internal class Uilist
    {
        public static int GetTTextHeight(TextBox txb)
        {
            using (Graphics g = txb.CreateGraphics())
            {
                SizeF size = g.MeasureString(txb.Text, txb.Font, 495);
                return (int)Math.Ceiling(size.Height);
            }
        }

        public static int GetRTTextHeight(RichTextBox rtb)
        {
            using (Graphics g = rtb.CreateGraphics())
            {
                // Measure the size required for the text content in the RichTextBox
                SizeF size = g.MeasureString(rtb.Text, rtb.Font, rtb.Width);

                // Return the height (round up to the nearest integer)
                return (int)Math.Ceiling(size.Height);
            }

        }
    }
}
