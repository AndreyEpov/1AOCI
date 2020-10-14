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
        private Image<Bgr, byte> prevImage;
        private VideoCapture capture;
        private int frameCounter = 0;
        double cannyThreshold;
        double cannyThresholdLinking;
        int choice = 0;
        editImage newImage = new editImage();
        private int tb1, tb2, tb3, tb4,tb11 = 0;
        private double tb5 = 10, tb6 = 0, tb7 = 5, tb8 = 5, tb9 = 126, tb10 = 100, tb12 = 0;
        private int[,] mass = new int[3, 3]
            {
                {-1,-1,-1},
                {-1,9,-1 },
                { -1,-1,-1}
            };
        int[,] mass1 = new int[3, 3]
{
                {-4,-2,0},
                {-2,1,2 },
                { 0,2,4}
};
        int[,] mass2 = new int[3, 3]
{
                {0,0,0},
                {-4,4,0 },
                { 0,0,0}
};
        int[,] mass3 = new int[3, 3];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            choice = 0;
            sourceImage = newImage.loadfunction(sourceImage);
            if (sourceImage != null)
            {
                imageBox1.Image = sourceImage;
                imageBox2.Image = sourceImage;
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
                imageBox2.Image = newImage.thresholdFilter(firstImage, cannyThreshold, cannyThresholdLinking, tb1, tb2, tb3, tb4).Resize(640, 480, Inter.Linear);
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

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            tb2 = trackBar2.Value;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            tb3 = trackBar3.Value;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            tb4 = trackBar4.Value;
        }

        private void Accept_but_Click(object sender, EventArgs e)
        {
            choice = 4;
        }

        private void Make_Gray_Click(object sender, EventArgs e)
        {
            choice = 5;
        }

        private void Sepia_Click(object sender, EventArgs e)
        {
            choice = 6;
        }

        private void Brightness_Click(object sender, EventArgs e)
        {
            choice = 7;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            choice = 8;
            prevImage = newImage.loadfunction(prevImage);
        }

        private void trackBar5_Scroll(object sender, EventArgs e)
        {
            tb5 = trackBar5.Value;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            choice = 9;
            prevImage = newImage.loadfunction(prevImage);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            choice = 10;
            prevImage = newImage.loadfunction(prevImage);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            choice = 11;
        }

        private void button10_Click(object sender, EventArgs e)
        {

            choice = 12;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            choice = 13;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            choice = 14;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if(textBox1!=null)
            {
                mass3 = new int[3, 3]
                {
                    {Convert.ToInt32(textBox1.Text[0]),Convert.ToInt32(textBox1.Text[1]),Convert.ToInt32(textBox1.Text[2])},
                    {Convert.ToInt32(textBox1.Text[3]),Convert.ToInt32(textBox1.Text[4]),Convert.ToInt32(textBox1.Text[5]) },
                    { Convert.ToInt32(textBox1.Text[6]),Convert.ToInt32(textBox1.Text[7]),Convert.ToInt32(textBox1.Text[8])}
                };
                choice = 15;
            }

        }

        private void button14_Click(object sender, EventArgs e)
        {
            prevImage = newImage.loadfunction(prevImage);
            choice = 16;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            choice = 17;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            choice = 18;
        }

        private void LR_1_SelectedIndexChanged(object sender, EventArgs e)
        {
                vScrollBar1.Visible = true;
                hScrollBar1.Visible = true;

            trackBar1.Visible = true;
            trackBar2.Visible = true;
            trackBar3.Visible = true;
            trackBar4.Visible = true;

            trackBar5.Visible = false;
            trackBar6.Visible = false;
            trackBar7.Visible = false;
            trackBar8.Visible = false;
            trackBar9.Visible = false;
            trackBar10.Visible = false;
            trackBar11.Visible = false;
            trackBar12.Visible = false;
            RGBList.Visible = false;
        }

        private void LR_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RGBList.Visible = false;
            vScrollBar1.Visible = false;
            hScrollBar1.Visible = false;
    
            trackBar1.Visible = false;
            trackBar2.Visible = false;
            trackBar3.Visible = false;
            trackBar4.Visible = false;          
            trackBar5.Visible = false;
            trackBar6.Visible = false;
            trackBar7.Visible = false;
            trackBar8.Visible = false;
            trackBar9.Visible = false;
            trackBar10.Visible = false;
            trackBar11.Visible = false;
            trackBar12.Visible = false;

            if (LR_2.SelectedIndex == 0)
            {
                RGBList.Visible = true;
                choice = 4;
            }
            if (LR_2.SelectedIndex == 1)
                choice = 5;
            if (LR_2.SelectedIndex == 2)
            {
                choice = 6;
            }
            if (LR_2.SelectedIndex == 3)
            {
                choice = 7;
                trackBar5.Visible = true;
                trackBar6.Visible = true;
            }
            if (LR_2.SelectedIndex == 4)
            {
                choice = 8;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
            }
            if (LR_2.SelectedIndex == 5)
            {
                choice = 9;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
            }
            if (LR_2.SelectedIndex == 6)
            {
                choice = 10;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
            }
            if (LR_2.SelectedIndex == 7)
            {
                choice = 18;
                trackBar11.Visible = true;
                trackBar12.Visible = true;
            }
            if (LR_2.SelectedIndex == 8)
                choice = 11;

            if (LR_2.SelectedIndex == 9)
                choice = 12;

            if (LR_2.SelectedIndex == 10)
                choice = 13;

            if (LR_2.SelectedIndex == 11)
                choice = 14;
            if (LR_2.SelectedIndex == 12)
            {
                choice = 18;
                trackBar5.Visible = true;
                trackBar6.Visible = true;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
            }
            if (LR_2.SelectedIndex == 13)
            {
                choice = 18;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar9.Visible = true;
                trackBar10.Visible = true;
            }
        }

        private void trackBar11_Scroll(object sender, EventArgs e)
        {
            tb11 = trackBar11.Value;
        }

        private void trackBar12_Scroll(object sender, EventArgs e)
        {
            tb12 = trackBar12.Value;
        }

        private void trackBar9_Scroll(object sender, EventArgs e)
        {
            tb9 = trackBar9.Value;
        }

        private void trackBar10_Scroll(object sender, EventArgs e)
        {
            tb10 = trackBar10.Value;
        }

        private void trackBar7_Scroll(object sender, EventArgs e)
        {
            tb7 = trackBar7.Value;
        }

        private void trackBar8_Scroll(object sender, EventArgs e)
        {
            tb8 = trackBar8.Value;
        }

        private void trackBar6_Scroll(object sender, EventArgs e)
        {
            tb6 = trackBar6.Value;
        }

        private void imageBox2_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (choice == 0)
                imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear);
            if (LR_1.SelectedIndex == 0)
            {
                if(vScrollBar1.Visible != true && hScrollBar1.Visible != true)
                {

                  
                }
                imageBox2.Image = newImage.filterCanny(sourceImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);

            }
            if (LR_1.SelectedIndex == 1)
                imageBox2.Image = newImage.thresholdFilter(sourceImage, cannyThreshold, cannyThresholdLinking, tb1,tb2,tb3,tb4).Resize(640, 480, Inter.Linear);
            if (choice == 4 && RGBList.SelectedItem != null)
                imageBox2.Image = newImage.editColourChanel(sourceImage.Resize(640, 480, Inter.Linear), RGBList);
            if (choice == 5)
                imageBox2.Image = newImage.grayAlgoritm(sourceImage.Resize(640, 480, Inter.Linear));
            if (choice == 6)
                imageBox2.Image = newImage.Sepia(sourceImage.Resize(640, 480, Inter.Linear));
            if (choice == 7)
            {
                prevImage = sourceImage.Resize(640, 480, Inter.Linear);
                prevImage = newImage.editBrightness(prevImage,tb6);
                imageBox2.Image = newImage.editContrast(prevImage, tb5);
            }
            if (choice == 8)
            {
                if(prevImage!=null)
                {
                    prevImage.Resize(640, 480, Inter.Linear);
                    imageBox2.Image = newImage.additionImage(sourceImage, prevImage, 1, tb7, tb8);
                }             
            }
            if (choice == 9)
            {
                if (prevImage != null)
                {
                    prevImage.Resize(640, 480, Inter.Linear);
                    imageBox2.Image = newImage.exceptionImage(sourceImage, prevImage, 1, tb7, tb8);
                }
            }
            if (choice == 10)
            {
                if (prevImage != null)
                {
                    prevImage.Resize(640, 480, Inter.Linear);
                    imageBox2.Image = newImage.intersectionImage(sourceImage, prevImage, 1, tb7, tb8);
                }
            }
            if (choice == 11)
                imageBox2.Image = newImage.editBlur(sourceImage.Resize(640, 480, Inter.Linear));
            if (choice == 12)
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass);
            if (choice == 13)
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass1);
            if (choice == 14)
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass2);
            if (choice == 15)
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass3);
            if (choice == 16)
            {
                sourceImage = sourceImage.Resize(640, 480, Inter.Linear);
                imageBox2.Image = newImage.additionImage(newImage.editBrightness(newImage.editContrast(newImage.editBlur(sourceImage), tb5), tb6), prevImage, 1, tb7, tb8);
            }
            if (choice == 17)
            {
                sourceImage = sourceImage.Resize(640, 480, Inter.Linear);
                imageBox2.Image = newImage.intersectionImage(sourceImage, newImage.editEdge(newImage.editBlurGray(sourceImage),tb9,tb10) , 1, tb7, tb8);
            }
            if (choice == 18)
            {
                sourceImage = sourceImage.Resize(640, 480, Inter.Linear);
                imageBox2.Image = newImage.editHSV(sourceImage,tb12,tb11);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
             tb1 = trackBar1.Value;
        }

    }
}
