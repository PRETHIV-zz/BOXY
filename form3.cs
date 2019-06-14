using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Boxy_Rocky
{
    public partial class Form3 : Form
    {
        public static string[,] gb = new string[9, 9];
        public static string p1 = Form1.pl1, p2 = Form1.pl2, s1 = Form1.sm1, s2 = Form1.sm2;
        public static int gc = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 1);
        }

        private void button57_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 8);
        }

        private void button58_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 8);
        }

        private void button49_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 7);
        }

        private void button50_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 7);
        }

        public Form3()
        {
            InitializeComponent();
            for(int i = 1; i < 9; i++)
            {
                for(int j = 1; j < 9; j++)
                {
                    gb[i, j] = "";
                }
            }
            label2.Text = p1;
        }
        public void putmark(object e,int x,int y)
        {
            Button t = e as Button;
            int cx, cy;
            cx = x;
            cy = y + 1;
            if (cy <= 8)
            {
                if (gb[cx, cy] == "")
                {
                    MessageBox.Show("The box under you are trying to put mark is still not filled so u can't put mark here");
                    return;
                }
            }
            if ((gc % 2 == 0) && t.Text == "")
            {
                t.Text = s1;
                gb[x, y] = s1;
                gc++;
                label2.Text = p2;
                label22.Text = Convert.ToString(gc);
                if (gc == 64)
                {
                    MessageBox.Show("Match draw");
                    label20.Text = "Match Draw";
                    return;
                }
                hrightchk(x, y,p1,x+1,x+2);
                hrightchk(x, y, p1, x - 1, x + 1);
                hleftchk(x, y,p1);
                vupchk(x, y, p1,y-1,y-2);
                vupchk(x, y, p1, y - 1, y + 1);
                vdownchk(x, y, p1);
                stleftupchk(x, y, p1,x-1,x-2,y-1,y-2);
                stleftupchk(x, y, p1, x + 1, x - 1, y + 1, y - 1);
                strightdownchk(x, y, p1);
                stleftdownchk(x, y, p1, x - 1, x - 2, y + 1, y + 2);
                stleftdownchk(x, y, p1, x + 1, x - 1, y - 1, y + 1);
                strightupchk(x, y, p1);

            }
            else if((gc%2==1)&& t.Text == ""){
                t.Text = s2;
                gb[x, y] = s2;
                gc++;
                label2.Text = p1;
                label22.Text = Convert.ToString(gc);
                if (gc == 64)
                {
                    MessageBox.Show("Match draw");
                    label20.Text = "Match Draw";
                    return;
                }
                hrightchk(x, y, p2, x + 1, x + 2);
                hrightchk(x, y, p2, x - 1, x + 1);
                hleftchk(x, y, p2);
                vupchk(x, y, p2, y - 1, y - 2);
                vupchk(x, y, p2, y - 1, y + 1);
                vdownchk(x, y, p2);
                stleftupchk(x, y, p2, x - 1, x - 2, y - 1, y - 2);
                stleftupchk(x, y, p2, x + 1, x - 1, y + 1, y - 1);
                strightdownchk(x, y, p2);
                stleftdownchk(x, y, p2,x-1,x-2,y+1,y+2);
                stleftdownchk(x, y, p2, x + 1, x - 1, y - 1, y + 1);
                strightupchk(x, y, p2);
            }
            else if (t.Text != "")
            {
                MessageBox.Show("ALready marked");
                return;
            }
        }
        public void stleftdownchk(int x,int y,string s,int x1,int x2,int y1,int y2)
        {
           
            if (x1 > 0 && x2 > 0 && y1 < 9 && y2 < 9 && x1 < 9 && x2 < 9 && y1 > 0 && y2 > 0)
            {
                if (gb[x, y] == gb[x1, y1] && gb[x, y] == gb[x2, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "/";
                    gb[x1, y1] = "/";
                    gb[x2, y2] = "/";
                    markall();
                }
            }
        }
        public void strightupchk(int x,int y,string s)
        {
            int x1 = x + 1, x2 = x + 2, y1 = y - 1, y2 = y - 2;
            if (x1 < 9 && x2 < 9 && y1 > 0 && y2 > 0)
            {
                if (gb[x, y] == gb[x1, y1] && gb[x, y] == gb[x2, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "/";
                    gb[x1, y1] = "/";
                    gb[x2, y2] = "/";
                    markall();
                }
            }
        }
        public void strightdownchk(int x,int y,string s)
        {
            int x1 = x + 1, x2 = x + 2, y1 = y + 1, y2 = y + 2;
            if (x1 < 9 && x2 < 9 && y1 < 9 && y2 < 9)
            {
                if (gb[x, y] == gb[x1, y1] && gb[x, y] == gb[x2, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "\\";
                    gb[x1, y1] = "\\";
                    gb[x2, y2] = "\\";
                    markall();
                }
            }
        }
        public void stleftupchk(int x,int y,string s,int x1,int x2,int y1,int y2)
        {
          
            if (x1 > 0 && x2 > 0 && y1 > 0 && y2 > 0 && x1 < 9 && x2 < 9 && y1 < 9 && y2 < 9) 
            {

                if (gb[x, y] == gb[x1, y1] && gb[x, y] == gb[x2, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x,y]="\\";
                    gb[x1, y1] = "\\";
                    gb[x2, y2] = "\\";
                    markall();
                  
                }
            }
        }
        public void vdownchk(int x,int y,string s)
        {
            int y1 = y + 1;
            int y2 = y + 2;
            if (y1 < 9 && y2 < 9)
            {
                if (gb[x, y] == gb[x, y1] && gb[x, y] == gb[x, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "|";
                    gb[x, y1] = "|";
                    gb[x, y2] = "|";
                    markall();
                }
            }
        }
        public void vupchk(int x,int y,string s,int y1,int y2)
        {
            if (y1 > 0 && y2 > 0 && y1<9 && y2 < 9)
            {
                if (gb[x, y] == gb[x, y1] && gb[x, y] == gb[x, y2] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "|";
                    gb[x, y1] = "|";
                    gb[x, y2] = "|";
                    markall();
                }
            }
        }
        public void hleftchk(int x,int y,string s)
        {
            int x1 = x - 1, x2 = x - 2;
            if (x1 > 0 && x2 > 0)
            {
                if (gb[x, y] == gb[x1, y] && gb[x, y] == gb[x2, y] && gb[x, y] != "")
                {
                    label20.Text = s;
                    gb[x, y] = "-";
                    gb[x1, y] = "-";
                    gb[x2, y] = "-";
                    markall();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            putmark(sender,3, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 1);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 1);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            putmark(sender, 2,2);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 2);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 2);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 2);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            putmark(sender, 8,2);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 3);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 3);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 3);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 3);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            putmark(sender, 5,3);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 3);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 3);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 3);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 4);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 4);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 4);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 4);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 4);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 4);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 4);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 4);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 5);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 5);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 5);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 5);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 5);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 5);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 5);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 5);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 6);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            putmark(sender, 2, 6);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 6);
        }

        private void button44_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 6);
        }

        private void button45_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 6);
        }

        private void button46_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 6);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 6);
        }

        private void button48_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 6);
        }

        private void button51_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 7);
        }

        private void button52_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 7);
        }

        private void button53_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 7);
        }

        private void button54_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 7);
        }

        private void button55_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 7);
        }

        private void button56_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 7);
        }

        private void button59_Click(object sender, EventArgs e)
        {
            putmark(sender, 3, 8);
        }

        private void button60_Click(object sender, EventArgs e)
        {
            putmark(sender, 4, 8);
        }

        private void button61_Click(object sender, EventArgs e)
        {
            putmark(sender, 5, 8);
        }

        private void button62_Click(object sender, EventArgs e)
        {
            putmark(sender, 6, 8);
        }

        private void button63_Click(object sender, EventArgs e)
        {
            putmark(sender, 7, 8);
        }

        private void button64_Click(object sender, EventArgs e)
        {
            putmark(sender, 8, 8);
        }

        public void hrightchk(int x,int y,string s,int x1,int x2) {
            if (x1 < 9 && x2 < 9 && x1 > 0 && x2 > 0) 
            {
                if (gb[x, y] == gb[x1, y] && gb[x, y] == gb[x2, y]&&gb[x,y]!="")
                {
                    label20.Text = s;
                   
                    gb[x, y] ="-";
                    gb[x1, y] = "-";
                    gb[x2, y] = "-";
                    markall();

                }
            }
        }
        public void markall()
        {
            button1.Text = gb[1, 1];
            button2.Text = gb[2, 1];
            button3.Text = gb[3, 1];
            button4.Text = gb[4, 1];
            button5.Text = gb[5, 1];
            button6.Text = gb[6, 1];
            button7.Text = gb[7, 1];
            button8.Text = gb[8, 1];
            button9.Text = gb[1, 2];
            button10.Text = gb[2, 2];
            button11.Text = gb[3, 2];
            button12.Text = gb[4, 2];
            button13.Text = gb[5, 2];
            button14.Text = gb[6, 2];
            button15.Text = gb[7, 2];
            button16.Text = gb[8, 2];
            button17.Text = gb[1, 3];
            button18.Text = gb[2, 3];
            button19.Text = gb[3, 3];
            button20.Text = gb[4, 3];
            button21.Text = gb[5, 3];
            button22.Text = gb[6, 3];
            button23.Text = gb[7, 3];
            button24.Text = gb[8, 3];
            button25.Text = gb[1, 4];
            button26.Text = gb[2, 4];
            button27.Text = gb[3, 4];
            button28.Text = gb[4, 4];
            button29.Text = gb[5, 4];
            button30.Text = gb[6, 4];
            button31.Text = gb[7, 4];
            button32.Text = gb[8, 4];
            button33.Text = gb[1, 5];
            button34.Text = gb[2, 5];
            button35.Text = gb[3, 5];
            button36.Text = gb[4, 5];
            button37.Text = gb[5, 5];
            button38.Text = gb[6, 5];
            button39.Text = gb[7, 5];
            button40.Text = gb[8, 5];
            button41.Text = gb[1, 6];
            button42.Text = gb[2, 6];
            button43.Text = gb[3, 6];
            button44.Text = gb[4, 6];
            button45.Text = gb[5, 6];
            button46.Text = gb[6, 6];
            button47.Text = gb[7, 6];
            button48.Text = gb[8, 6];
            button49.Text = gb[1, 7];
            button50.Text = gb[2, 7];
            button51.Text = gb[3, 7];
            button52.Text = gb[4, 7];
            button53.Text = gb[5, 7];
            button54.Text = gb[6, 7];
            button55.Text = gb[7, 7];
            button56.Text = gb[8, 7];
            button57.Text = gb[1, 8];
            button58.Text = gb[2, 8];
            button59.Text = gb[3, 8];
            button60.Text = gb[4, 8];
            button61.Text = gb[5, 8];
            button62.Text = gb[6, 8];
            button63.Text = gb[7, 8];
            button64.Text = gb[8, 8];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            putmark(sender, 1, 1);
        }

    }
}
