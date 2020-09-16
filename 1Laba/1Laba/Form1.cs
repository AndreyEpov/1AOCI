using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
namespace _1Laba
{
    public partial class Form1 : Form
    {
        private Image<Bgr, byte> sourceImage;
        private VideoCapture capture;
        private int frameCounter = 0;
        double cannyThreshold;
        double cannyThresholdLinking;
        int choice = 0;
        editImage newImage = new editImage();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 0;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;*.png";
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                sourceImage = new Image<Bgr, byte>(fileName);
                imageBox1.Image = sourceImage.Resize(640, 480, Inter.Linear); 
                imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear); 
                timer2.Enabled = true;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            choice = 3;
            timer2.Enabled = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "video Files(*.MP4)| *.MP4;";
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                capture = new VideoCapture(fileName);
                timer1.Enabled = true;

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();
            Image<Bgr, byte> firstImage = frame.ToImage<Bgr, byte>();
            imageBox2.Image = firstImage;

            if (choice == 0)
                imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear);
            if (choice == 1)
                imageBox2.Image = newImage.filterCanny(firstImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);
            if (choice == 2)
                imageBox2.Image = newImage.thresholdFilter(firstImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);
            if (choice == 3)
                imageBox2.Image = firstImage;

           frameCounter++;
            if (frameCounter >= capture.GetCaptureProperty(CapProp.FrameCount))
            {
                timer1.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            choice = 2;
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cannyThreshold += e.OldValue - e.NewValue;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cannyThresholdLinking += e.OldValue - e.NewValue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox2.ClearOperation();
            imageBox1.ClearOperation();
            timer1.Enabled = false;
            timer2.Enabled = false;
            choice = 0;

        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (choice == 0)
                imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear);
            if (choice == 1)
                imageBox2.Image = newImage.filterCanny(sourceImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);
            if(choice == 2)
                imageBox2.Image = newImage.thresholdFilter(sourceImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);

        }
    }
}
