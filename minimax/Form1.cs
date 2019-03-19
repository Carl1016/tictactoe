using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace minimax
{
    public partial class Form1 : Form
    {
        int flag = 1;
        int[,] chestboard = new int[3, 3];
        int[] status = new int[9];
        public Form1()
        {
            InitializeComponent();
            
            Chest[,] chests = new Chest[3, 3];
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    chests[i, j] = new Chest();
                    chests[i, j].pos_x = i;
                    chests[i, j].pos_y = j;
                    chests[i, j].Location = new System.Drawing.Point(i * (chests[i, j].Size.Width + 2), j * (chests[i, j].Size.Height + 2));
                    chests[i, j].Image = imageList1.Images[0];
                    chests[i,j].situation = 0;
                    this.Controls.Add(chests[i, j]);
                    chests[i, j].Click += new System.EventHandler(this.Click);
                }
            }
            for(int i =0;i<=8;i++)
            {
                status[i] = 0;
            }
        }
        private void Click(object sender, EventArgs e)
        {
            Chest ch = new Chest();
            ch = (Chest)sender;          
            if(ch.situation==0)
            {
                ch.Image = imageList1.Images[flag];
                chestboard[ch.pos_x, ch.pos_y] = flag;
                ch.situation = 1;
                if(flag==1)
                {
                    flag = 2;
                }
                else
                {
                    flag = 1;
                }
            }
            else
            {
                MessageBox.Show("wrong input!");
            }
            chestboard_to_status(chestboard);
            judge();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public class Chest:Button
        {
            public int situation;
            public int pos_x;
            public int pos_y;
            public Chest()
            {
                this.Size = new System.Drawing.Size(115, 115);
            }
        }
        public Boolean matched(int i, int j, int k, int who)
        {
            return (status[i] == who && status[j] == who && status[k] == who);
        }
        public Boolean matched(int who)
        {
            if (matched(0, 1, 2, who))
            {
                return true;
            }
            if (matched(3, 4, 5, who))
            {
                return true;
            }
            if (matched(6, 7, 8, who))
            {
                return true;
            }
            if (matched(0, 3, 6, who))
            {
                return true;
            }
            if (matched(1, 4, 7, who))
            {
                return true;
            }
            if (matched(2, 5, 8, who))
            {
                return true;
            }
            if (matched(0, 4, 8, who))
            {
                return true;
            }
            if (matched(2, 4, 6, who))
            {
                return true;
            }
            return false;
        }
        public void chestboard_to_status(int[,]chestboard)
        {
            int num = 0;
            for(int i =0;i<=2;i++)
            {
                for(int j=0;j<=2;j++)
                {
                    status[num] = chestboard[j, i];
                    num++;
                }
            }
        }
        public void judge()
        {
            if (matched(1))
            {
                MessageBox.Show("X贏了!");
            }
            if (matched(2))
            {
                MessageBox.Show("O贏了!");
            }
            int num = 0;
            foreach(int i in status)
            {
                if(i==0)
                {
                    num++;
                }
            }
            if(num==0)
            {
                MessageBox.Show("平手!");
            }
        }
    }
}
