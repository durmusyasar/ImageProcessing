using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        Processes processes = new Processes();
        OpenFileDialog openFile = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(openFile.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFile.FileName);
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(pictureBox1.Image != null)
            {
                if(comboBox1.SelectedItem.ToString() == "mouse modu" )
                {
                    Bitmap bitmap;
                    bitmap = (Bitmap)pictureBox1.Image;

                    Color color = bitmap.GetPixel(e.X, e.Y);
                    pictureBox2.BackColor = color;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap originalImage = (Bitmap)Image.FromFile(openFile.FileName);
            Bitmap comingImage = null;

            switch (comboBox1.SelectedItem)
            {
                case "negatif":
                    comingImage = processes.Negative((Bitmap)originalImage);
                    break;
                case "gri":
                    comingImage = processes.ConvertGray((Bitmap)originalImage);
                    break;
                case "eşikleme":
                    comingImage = processes.ConvertGray((Bitmap)originalImage);
                    comingImage = processes.Thresholding((Bitmap)originalImage, 128);
                    break;
                case "parlaklık":
                    comingImage = processes.Brightness((Bitmap)originalImage, trackBar1.Value);
                    break;
            }
            pictureBox2.Image = comingImage;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString() == "mouse modu")
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox2.SizeMode = PictureBoxSizeMode.Normal;
            }
            else
            {
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox2.BackColor = Color.Lavender;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
