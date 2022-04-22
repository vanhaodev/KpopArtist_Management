using ArtistMNG.Module.ImageFile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Subform
{
    public partial class Template : Form
    {
        int artistID, groupID;
        public Template(int artistID, int groupID)
        {
            InitializeComponent();
            this.artistID = artistID;
            this.groupID = groupID;
            LoadDesign();
        }
        void LoadDesign()
        {
           
        }

    }
}
