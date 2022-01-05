using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        int index = 0;
        
        private void button4_Click(object sender, EventArgs e)//показать рисунок
        {
            // Show the Open File dialog. If the user clicks OK, load the
            // picture that the user chose.

            openFileDialog1.Multiselect = true;// свойство позволяющее выбирать несколько файлов
            


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }



        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Clear the picture
            pictureBox1.Image = null;
        }

        private void button2_Click(object sender, EventArgs e)//изменение цвета фона
        {
            // Show the color dialog box. If the user clicks OK, change the
            // PictureBox control's background to the color the user chose.
            if (colorDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.BackColor = colorDialog1.Color;
            }
        }

        private void button1_Click(object sender, EventArgs e)//закртие
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)//фиксирование размера
        {
            if (checkBox1.Checked)
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
        }

        private void rush_Click(object sender, EventArgs e)
        {
            
            string[] image = openFileDialog1.FileNames;//получаем массив путей к файлам
            
            try
            {
                if (index < image.Length)
                    pictureBox1.Load(image[++index]);
            }
            catch (System.IndexOutOfRangeException)
            {
                try {
                    index = 0;
                    pictureBox1.Load(image[index]);
                }
                
                catch (System.IO.FileNotFoundException)
                {
                    MessageBox.Show("Файлы не загружены".ToString());
                }
            } 
        }

        private void backrush_Click(object sender, EventArgs e)
        {
            string[] image = openFileDialog1.FileNames;//получаем массив путей к файлам

            try
            {
                if (index > 0)
                    pictureBox1.Load(image[--index]);
                else
                {
                    index = image.Length;
                    pictureBox1.Load(image[--index]);
                }
            }

            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Файлы не загружены".ToString());
            }
        }
    }
}

