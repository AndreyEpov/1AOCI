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
        bool treshhold;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                sourceImage = new Image<Bgr, byte>(fileName);
                imageBox1.Image = sourceImage.Resize(640, 480, Inter.Linear);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            treshhold = true;
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();

            double cannyThreshold = 80.0;
            double cannyThresholdLinking = 40.0;
            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);

            var cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
            var resultImage = sourceImage.Sub(cannyEdgesBgr); // попиксельное вычитание

            //обход по каналам
            for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                for (int x = 0; x < resultImage.Width; x++)
                    for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                    {
                        // получение цвета пикселя
                        byte color = resultImage.Data[y, x, channel];
                        if (color <= 50)
                            color = 0;
                        else if (color <= 100)
                            color = 25;
                        else if (color <= 150)
                            color = 180;
                        else if (color <= 200)
                            color = 210;
                        else
                            color = 255;
                        resultImage.Data[y, x, channel] = color; // изменение цвета пикселя
                    }

            imageBox2.Image = resultImage.Resize(640, 480, Inter.Linear);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "video Files(*.MP4)| *.MP4;";
            var result = openFileDialog.ShowDialog(); // открытие диалога выбора файла
            if (result == DialogResult.OK) // открытие выбранного файла
            {
                string fileName = openFileDialog.FileName;
                capture = new VideoCapture(fileName);
                timer1.Enabled = true;
                // timer1.Interval = (int)capture.GetCaptureProperty(CapProp.XiFramerate);

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();
            Image<Bgr, byte> firstImage = frame.ToImage<Bgr, byte>();
            Image<Gray, byte> grayImage = firstImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();

            double cannyThreshold = 80.0;
            double cannyThresholdLinking = 40.0;
            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);

            var cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
            var resultImage = firstImage.Sub(cannyEdgesBgr); // попиксельное вычитание

            //обход по каналам
            for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                for (int x = 0; x < resultImage.Width; x++)
                    for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                    {
                        // получение цвета пикселя
                        byte color = resultImage.Data[y, x, channel];
                        if (color <= 50)
                            color = 0;
                        else if (color <= 100)
                            color = 25;
                        else if (color <= 150)
                            color = 180;
                        else if (color <= 200)
                            color = 210;
                        else
                            color = 255;
                        resultImage.Data[y, x, channel] = color; // изменение цвета пикселя
                    }
            imageBox2.Image = resultImage;
            frameCounter++;
            if (frameCounter >= capture.GetCaptureProperty(CapProp.FrameCount))
            {
                timer1.Enabled = false;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            treshhold = false;
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();

            cannyThreshold = 80.0;
            cannyThresholdLinking = 40.0;
            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);
            imageBox2.Image = cannyEdges.Resize(640, 480, Inter.Linear);
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cannyThreshold += e.OldValue - e.NewValue;
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();


            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);
            if (treshhold == false)
            {
                imageBox2.Image = cannyEdges.Resize(640, 480, Inter.Linear);
            }
            else
            {
                var cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
                var resultImage = sourceImage.Sub(cannyEdgesBgr); // попиксельное вычитание

                //обход по каналам
                for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                    for (int x = 0; x < resultImage.Width; x++)
                        for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                        {
                            // получение цвета пикселя
                            byte color = resultImage.Data[y, x, channel];
                            if (color <= 50)
                                color = 0;
                            else if (color <= 100)
                                color = 25;
                            else if (color <= 150)
                                color = 180;
                            else if (color <= 200)
                                color = 210;
                            else
                                color = 255;
                            resultImage.Data[y, x, channel] = color; // изменение цвета пикселя
                        }

                imageBox2.Image = resultImage.Resize(640, 480, Inter.Linear);
            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            cannyThresholdLinking += e.OldValue - e.NewValue;
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();


            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);
            if (treshhold == false)
            {

                imageBox2.Image = cannyEdges.Resize(640, 480, Inter.Linear);
            }
            else
            {
                var cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
                var resultImage = sourceImage.Sub(cannyEdgesBgr); // попиксельное вычитание

                //обход по каналам
                for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                    for (int x = 0; x < resultImage.Width; x++)
                        for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                        {
                            // получение цвета пикселя
                            byte color = resultImage.Data[y, x, channel];
                            if (color <= 50)
                                color = 0;
                            else if (color <= 100)
                                color = 25;
                            else if (color <= 150)
                                color = 180;
                            else if (color <= 200)
                                color = 210;
                            else
                                color = 255;
                            resultImage.Data[y, x, channel] = color; // изменение цвета пикселя
                        }

                imageBox2.Image = resultImage.Resize(640, 480, Inter.Linear);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            imageBox1.Image = null;
            imageBox2.Image = null;
            imageBox2.ClearOperation();
            imageBox1.ClearOperation();

        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
