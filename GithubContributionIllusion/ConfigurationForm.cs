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
        private List<Tile> baseTiles = new List<Tile>();
        private List<Color> colors = new List<Color>();
        private bool draw;
        private int prevX, prevY;

        public ConfigurationForm()
        {
            InitializeComponent();
           
            InitializeMonthTag();

            InitializeTiles();

            colors.Add(label1.BackColor);
            colors.Add(label2.BackColor);
            colors.Add(label3.BackColor);
            colors.Add(label4.BackColor);

        }
        //723 154
        private void button1_Click(object sender, EventArgs e)
        {
        }

        

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            draw = true;
            prevX = e.X;
            prevY = e.Y;
        }

        private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                drawOnTiles(prevX, prevY);
                label7.Text = prevX.ToString() + " " + prevY.ToString() + "\n" + Cursor.Position.X.ToString() + " " + Cursor.Position.Y.ToString();

                prevX = e.X;
                prevY = e.Y;
            }
        }

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }

        private void drawOnTiles(int x, int y)
        {
            int col = (x - baseX - 49) / 10;
            if ((col >= 0) && ((x - baseX - 49) % 10 <= 8)&&(col<53))
            {
                int row = (y - baseY - 32) / 10;
                if ((row >= 0) && ((y - baseY - 32) % 10 <= 8)&&(row<7))
                {
                    Random random = new Random();
                    baseTiles[row * 53 + col].changeColor(colors[random.Next(0, 3)]);
                }
            }
        }

        private void InitializeTiles()
        {

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 53; x++)
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
