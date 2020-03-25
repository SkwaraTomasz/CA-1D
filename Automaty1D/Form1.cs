using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Automaty1D
{
    public partial class Form1 : Form
    {
        int LiczbaIteracji;
        int LiczbaKomorek;
        int Regula;
        private Graphics rysunek1;
        private Bitmap bitmapa1;
        Pen blackPen = new Pen(Color.Black, 1);
        
        public Form1()
        {
            
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush blackBrush = new SolidBrush(Color.Black);
            int.TryParse(textBox1.Text, out LiczbaIteracji);
            int.TryParse(textBox2.Text, out LiczbaKomorek);
            int.TryParse(comboBox1.Text, out Regula);

            pictureBox1.Size = new System.Drawing.Size(LiczbaKomorek*4, LiczbaIteracji*4);

            bitmapa1 = new Bitmap(LiczbaKomorek*4, LiczbaIteracji*4);
            pictureBox1.Image = bitmapa1;
            rysunek1 = Graphics.FromImage(pictureBox1.Image);


            int [,]stany= new int [LiczbaIteracji,LiczbaKomorek];

            for (int i = 0; i < LiczbaIteracji; i++) {
                for (int j = 0; j < LiczbaKomorek; j++) stany[i, j] = 0;
            }
            stany[0, LiczbaKomorek / 2] = 1;

            Rectangle test = new Rectangle((LiczbaKomorek*4)/2,0,4,4);
            rysunek1.FillRectangle(blackBrush, test);

            int lewa=0;
            int srodkowa=0;
            int prawa=0;
            string binary = Convert.ToString(Regula, 2).PadLeft(8, '0'); ;
            for (int i = 1; i <LiczbaIteracji; i++) {
                for (int j = 0; j < LiczbaKomorek; j++) {
                    if (j == 0)
                    {
                        lewa = stany[i - 1, LiczbaKomorek - 1];
                        srodkowa = stany[i - 1, j];
                        prawa = stany[i - 1, j + 1];
                    }
                    else if (j == LiczbaKomorek - 1)
                    {
                        lewa = stany[i - 1, j - 1];
                        srodkowa = stany[i - 1, j];
                        prawa = stany[i - 1, 0];
                    }
                    else
                    {
                        lewa = stany[i - 1, j - 1];
                        srodkowa = stany[i - 1, j];
                        prawa = stany[i - 1, j + 1];
                    }
                    if(lewa==1 && srodkowa==1 && prawa==1)
                    {
                        
                        
                       stany[i, j] = (int)Char.GetNumericValue(binary[0]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j*4, i*4, 4, 4); }

                    }
                    else if (lewa == 1 && srodkowa == 1 && prawa == 0)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[1]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else if (lewa == 1 && srodkowa == 0 && prawa == 1)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[2]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else if (lewa == 1 && srodkowa == 0 && prawa == 0)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[3]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else if (lewa == 0 && srodkowa == 1 && prawa == 1)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[4]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else if (lewa == 0 && srodkowa == 1 && prawa == 0)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[5]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else if (lewa == 0 && srodkowa == 0 && prawa == 1)
                    {

                        stany[i, j] = (int)Char.GetNumericValue(binary[6]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }
                    else
                    {
                        
                        stany[i, j] = (int)Char.GetNumericValue(binary[7]);

                        if (stany[i, j] == 1) { rysunek1.FillRectangle(blackBrush, j * 4, i * 4, 4, 4); }
                    }


                }
            }



            pictureBox1.Refresh();
        }
    }
}