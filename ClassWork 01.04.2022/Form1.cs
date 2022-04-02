using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassWork_01._04._2022
{
    public partial class Form1 : Form
    {

        Form2 form2 = new Form2();
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Data.Nameeeee = textBoxName.Text;
            form2.ShowDialog();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("При нажатии на кнопку СТАРТ, вы начнете играть игру !собери пару!, при нажатии на кнопку перемешать вам дадут 45 секунд, если вы не успеете собрать все пары вы проиграете и ваше имя запишется в файл как програвший. Удачи!!");
        }
    }
}
