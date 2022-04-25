using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Module
{
    public class ColorTable : ProfessionalColorTable
    {

        public override Color MenuItemSelectedGradientBegin
        {
            get { return Color.FromArgb(53, 55, 59); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return Color.FromArgb(53, 55, 59); }
        }
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(42, 42, 46); }
        }

        public override Color MenuBorder  //added for changing the menu border
        {
            get { return Color.Transparent; }
        }

        public override Color MenuItemBorder
        {
            get { return Color.Transparent; }
        }

        public override Color ToolStripDropDownBackground
        {
            get { return Color.FromArgb(32, 32, 36); }
        }

        public override Color ToolStripBorder
        {
            get { return Color.FromArgb(32, 32, 36); }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get { return Color.FromArgb(32, 32, 36); }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get { return Color.FromArgb(32, 32, 36); }
        }

        public override Color ImageMarginGradientBegin
        {
            get { return Color.FromArgb(32, 32, 36); }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return Color.FromArgb(32, 32, 36); }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return Color.FromArgb(32, 32, 36); }
        }

    }
}
