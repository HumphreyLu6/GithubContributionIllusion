using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GithubContributionIllusion
{
    class Tile : Label
    {
        public Tile(Point point)
        {
            this.Location = point;
            this.Width = 8;
            this.Height = 8;
            this.BackColor = Color.Green;
        }
        public void changeColor(Color color)
        {
            this.BackColor = color;
        }
        

    }
}
