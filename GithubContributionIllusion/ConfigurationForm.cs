using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private bool draw, fineTune, activate;
        private int prevX, prevY, conNumber=0;

        public ConfigurationForm()
        {
            InitializeComponent();
           
            InitializeMonthTag();

            InitializeTiles();

            colors.Add(label1.BackColor);
            colors.Add(label2.BackColor);
            colors.Add(label3.BackColor);
            colors.Add(label4.BackColor);

            groupBox1.Click += new EventHandler(MousePressed);
            //groupBox1.MouseMove += new MouseEventHandler(FormMouseMove);
            //groupBox1.MouseUp += new MouseEventHandler(FormMouseUp);
            label8.Text = conNumber.ToString() + " contributions in the last year";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            draw = true;
            fineTune = false;
        }



        private void MousePressed(object sender, EventArgs e)
        {
            if (draw)
            {
                if (activate)
                {
                    activate = false;
                }
                else
                {
                    activate = true;
                }
            }
            
        }

        /*private void FormMouseMove(object sender, MouseEventArgs e)
        {
            if (draw)
            {
                drawOnTiles(prevX, prevY);
                label7.Text = prevX.ToString() + " " + prevY.ToString() + "\n" + Cursor.Position.X.ToString() + " " + Cursor.Position.Y.ToString();

                prevX = e.X;
                prevY = e.Y;
                //Tile tile = (Tile)sender;
                //Random random = new Random();
                //tile.changeColor(colors[random.Next(0, 3)]);
            }
        }*/

        private void FormMouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
        }
        /*
        private void drawOnTiles(int x, int y)
        {
            int col = (x - baseX) / 10;
            if ((col >= 0) && ((x - baseX) % 10 <= 8)&&(col<53))
            {
                int row = (y - baseY) / 10;
                if ((row >= 0) && ((y - baseY) % 10 <= 8)&&(row<7))
                {
                    Random random = new Random();
                    baseTiles[row * 53 + col].changeColor(colors[random.Next(0, 3)]);
                }
            }
        }*/

        private void InitializeTiles()
        {

            for (int y = 0; y < 7; y++)
            {
                for (int x = 0; x < 53; x++)
                {
                    Point point = CalculatePosition(x, y);
                    Tile tile = new Tile(point);
                    tile.Click += new EventHandler(changeColor);
                    tile.MouseEnter += new EventHandler(mouseEnterred);
                    baseTiles.Add(tile);
                    groupBox1.Controls.Add(tile);
                }
            }
        }

        private void mouseEnterred(object sender, EventArgs e)
        {
            if (activate)
            {
                Tile tile = (Tile)sender;
                Random random = new Random();
                tile.changeColor(colors[random.Next(0, 3)]);

            }
        }

        private void changeColor(object sender, EventArgs e)
        {
            if (fineTune)
            {
                Label label = sender as Label;
                if (label != null)
                {
                    Tile tile = label as Tile;
                    tile.changeColor(color);
                }
            }else if (draw)
            {
                if (activate)
                {
                    activate = false;
                }
                else
                {
                    activate = true;
                }
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

        private void label8_Click(object sender, EventArgs e)
        {
            foreach (Tile tile in baseTiles)
            {
                if (tile.BackColor.Equals(colors[0]))
                {
                    conNumber += 2;
                }else if (tile.BackColor.Equals(colors[1]))
                {
                    conNumber += 4;
                }else if (tile.BackColor.Equals(colors[2]))
                {
                    conNumber += 6;
                }else if (tile.BackColor.Equals(colors[3]))
                {
                    conNumber += 8;
                }
            }
            label8.Text = conNumber.ToString() + " contributions in the last year";
        }

        private void label3_Click(object sender, EventArgs e)
        {
            color = label3.BackColor;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            draw = false;
            fineTune = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            color = label4.BackColor;
        }
    }
}
