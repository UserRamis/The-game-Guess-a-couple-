using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassWork_01._04._2022
{
    public partial class Form2 : Form
    {
        int opened_counter;
        int[] pairs;
        int[] game_pairs;
        int[] opened;
        int  u= 45 ;
        PictureBox[] array_picbox;
        
        public Form2()
        {
            InitializeComponent();
            pairs = new int[16];
            game_pairs = new int[16];
            opened = new int[2];
            opened_counter = 0;
            array_picbox = new PictureBox [16];
            array_picbox[0] = pictureBox1;
            array_picbox[1] = pictureBox2;
            array_picbox[2] = pictureBox3;
            array_picbox[3] = pictureBox4;
            array_picbox[4] = pictureBox5;
            array_picbox[5] = pictureBox6;
            array_picbox[6] = pictureBox7;
            array_picbox[7] = pictureBox8;
            array_picbox[8] = pictureBox9;
            array_picbox[9] = pictureBox10;
            array_picbox[10] = pictureBox11;
            array_picbox[11] = pictureBox12;
            array_picbox[12] = pictureBox13;
            array_picbox[13] = pictureBox14;
            array_picbox[14] = pictureBox15;
            array_picbox[15] = pictureBox16;           
        }                    
        public void hide()
        {
            pictureBox1.BackgroundImage = imageList1.Images[6];
            pictureBox2.BackgroundImage = imageList1.Images[6];
            pictureBox3.BackgroundImage = imageList1.Images[6];
            pictureBox4.BackgroundImage = imageList1.Images[6];
            pictureBox5.BackgroundImage = imageList1.Images[6];
            pictureBox6.BackgroundImage = imageList1.Images[6];
            pictureBox7.BackgroundImage = imageList1.Images[6];
            pictureBox8.BackgroundImage = imageList1.Images[6];
            pictureBox9.BackgroundImage = imageList1.Images[6];
            pictureBox10.BackgroundImage = imageList1.Images[6];
            pictureBox11.BackgroundImage = imageList1.Images[6];
            pictureBox11.BackgroundImage = imageList1.Images[6];
            pictureBox12.BackgroundImage = imageList1.Images[6];
            pictureBox13.BackgroundImage = imageList1.Images[6];
            pictureBox14.BackgroundImage = imageList1.Images[6];
            pictureBox15.BackgroundImage = imageList1.Images[6];
            pictureBox16.BackgroundImage = imageList1.Images[6];
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            u--;
            timer.Text = u.ToString();
            if (u == 0)
            {
                Form3 form3 = new Form3();
                form3.ShowDialog();
                using (StreamWriter w = File.AppendText(@"user.txt"))
                {
                    w.WriteLine(Data.Nameeeee  + " проиграл");
                }
            }                                   
        }

        private void button1_Click_1(object sender, EventArgs e)
        {           
            opened_counter = 0;
            timerMain.Enabled = true;            
            Random R;
            R = new Random();
            for(int i=0;i<8;i++)
            {
                pairs[i] = R.Next(6);
            }
            for (int i = 0; i < 16; i++)
            {
                array_picbox[i].Visible = true;
                game_pairs[i] = -1;
            }
            int used = 0;
            while(used!=8)
            {
                int n1 = R.Next(16);
                int n2 = R.Next(16);
                if (n2 == n1) continue;
                if (game_pairs[n1] == -1 && game_pairs[n2] == -1)
                {
                    game_pairs[n1] = game_pairs[n2] = pairs[used];
                    used++;
                }
            }
            hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            PictureBox p = (PictureBox)sender;            
            int index = Convert.ToInt32(p.Tag);
            if(opened_counter == 1)
            {
                if (opened[0] == index) return;
            }
            if (opened_counter == 2)
            {
                opened_counter = 0;
                hide();
            }

            opened[opened_counter] = index;
            opened_counter++;

            if(opened_counter==2)
            {
                if(game_pairs[opened[0]]== game_pairs[opened[1]])
                {
                    array_picbox[opened[0]].Visible = false;
                    array_picbox[opened[1]].Visible = false;
                    opened_counter = 0;
                    hide();
                }
            }
            p.BackgroundImage = imageList1.Images[game_pairs[index]];

            if (pictureBox1.Visible == false&pictureBox2.Visible == false& pictureBox3.Visible == false& pictureBox4.Visible == false& pictureBox5.Visible == false & pictureBox6.Visible == false & pictureBox7.Visible == false & pictureBox8.Visible == false & pictureBox9.Visible == false & pictureBox10.Visible == false & pictureBox11.Visible == false & pictureBox12.Visible == false & pictureBox13.Visible == false & pictureBox14.Visible == false & pictureBox15.Visible == false & pictureBox16.Visible == false)                                           
            {
                DialogResult result= MessageBox.Show("Ваше имя будет в файле как победитель!, если вы хотите продолжить игру нажмите Да!. Если хотите выйти нажмите Нет!", "Поздавляем вы выйграли игру", MessageBoxButtons.YesNo,MessageBoxIcon.None);
                
                using (StreamWriter w = File.AppendText(@"user.txt"))
                {
                    w.WriteLine(Data.Nameeeee + " выйграл");
                }

                if (result == DialogResult.Yes)
                {
                    button1_Click_1(this,e);
                    u = 45;
                }

                if (result == DialogResult.No)
                {
                    Close();
                }
            }
        }
    }
}
