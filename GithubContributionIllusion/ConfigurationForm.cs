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
        private char[] chars;
        private List<Tile> baseTiles = new List<Tile>();

        public ConfigurationForm()
        {
            InitializeComponent();
           
            InitializeMonthTag();

            InitializeTiles();

        }
        //723 154
        private void button1_Click(object sender, EventArgs e)
        {
            chars = textBox1.Text.ToCharArray();
            foreach (char item in chars)
            {
                List<int> poses = new List<int>();
                int width=0;

                getTemplate(item, ref width);
            }
        }

        private List<int> getTemplate(char item, ref int width)
        {
            List<int> temp = new List<int>();
            if (item.Equals('A'))
            {
                width = 5;
                temp.Add(3);
                temp.Add(7);
                temp.Add(9);
                temp.Add(11);
                temp.Add(15);
                temp.Add(16);
                temp.Add(20);
                temp.Add(21);
                temp.Add(22);
                temp.Add(23);
                temp.Add(24);
                temp.Add(25);
                temp.Add(26);
                temp.Add(30);
                temp.Add(31);
                temp.Add(35);

                return temp;
            }else if (item.Equals('B'))
            {
                width = 5;
                temp.Add(1);
                temp.Add(2);
                temp.Add(3);
                temp.Add(4);
                temp.Add(6);
                temp.Add(10);
                temp.Add(11);
                temp.Add(15);
                temp.Add(16);
                temp.Add(17);
                temp.Add(18);
                temp.Add(19);
                temp.Add(21);
                temp.Add(25);
                temp.Add(26);
                temp.Add(30);
                temp.Add(31);
                temp.Add(32);
                temp.Add(33);
                temp.Add(34);

                return temp;
            }else if (item.Equals('C'))
            {
                width = 5;
                temp.Add(2);
                temp.Add(3);
                temp.Add(4);
                temp.Add(6);
                temp.Add(10);
                temp.Add(11);
                temp.Add(16);
                temp.Add(21);
                temp.Add(26);
                temp.Add(30);
                temp.Add(32);
                temp.Add(33);
                temp.Add(34);

                return temp;
            }else if (item.Equals('D'))
            {
                width = 5;
                temp.Add(1);
                temp.Add(2);
                temp.Add(3);
                temp.Add(6);
                temp.Add(9);
                temp.Add(11);
                temp.Add(15);
                temp.Add(16);
                temp.Add(20);
                temp.Add(21);
                temp.Add(25);
                temp.Add(26);
                temp.Add(29);
                temp.Add(31);
                temp.Add(32);
                temp.Add(33);

                return temp;
            }else if (item.Equals('E'))
            {
                width = 5;
                temp.Add(1);
                temp.Add(2);
                temp.Add(3);
                temp.Add(4);
                temp.Add(5);
                temp.Add(6);
                temp.Add(11);
                temp.Add(17);
                temp.Add(18);
                temp.Add(19);
                temp.Add(20);
                temp.Add(21);
                temp.Add(26);
                temp.Add(31);
                temp.Add(32);
                temp.Add(33);
                temp.Add(34);
                temp.Add(35);

                return temp;
            }

            return null;
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
                    baseTiles.Add(tile);
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
