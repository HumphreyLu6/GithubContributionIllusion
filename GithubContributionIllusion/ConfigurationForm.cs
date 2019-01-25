using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GithubContributionIllusion
{
    public partial class ConfigurationForm : Form
    {
        private readonly int baseX = 50;
        private readonly int baseY = 42;
        private Color color = Color.White;

        public ConfigurationForm()
        {
            InitializeComponent();
           
            InitializeMonthTag();

            InitializeTiles();

        }
        //723 154
        private void button1_Click(object sender, EventArgs e)
        {
            label5.Text = this.Width.ToString() + "\n" + this.Height.ToString();
            MessageBox.Show(this.Width.ToString() + "\n" + this.Height.ToString());
        }

        private void InitializeTiles()
        {

            for (int x=0; x<53; x++)
            {
                for (int y=0; y<7; y++)
                {
                    Point point = CalculatePosition(x, y);
                    Tile tile = new Tile(point);
                    tile.Click += new EventHandler(changeColor);
                    groupBox1.Controls.Add(tile);
                }
            }
        }

        private void changeColor(object sender, EventArgs e)
        {
            Label label = sender as Label;
            if (label != null)
            {
                Tile tile = label as Tile;
                tile.changeColor(color);
            }
        }

        private void InitializeMonthTag()
        {
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(pictureBox2);
            groupBox1.Controls.Add(pictureBox3);
            pictureBox1.ImageLocation = @"C:\Users\labuser\Desktop\Intern Files\GithubContributionIllusion\GithubContributionIllusion\Properties\MonthHorizontal.jpg";
            pictureBox2.ImageLocation = @"C:\Users\labuser\Desktop\Intern Files\GithubContributionIllusion\GithubContributionIllusion\Properties\MonthVertical.jpg";
            pictureBox3.ImageLocation = @"C:\Users\labuser\Desktop\Intern Files\GithubContributionIllusion\GithubContributionIllusion\Properties\Bottom.jpg";
        }

        private Point CalculatePosition(int x, int y)
        {
            int positionX = baseX + x * 10;
            int positionY = baseY + y * 10;

            return new Point(positionX, positionY);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            color = Color.White;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            color = label1.BackColor;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            color = label2.BackColor;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            color = label3.BackColor;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            color = label4.BackColor;
        }
    }
}
