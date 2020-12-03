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
using Emgu.CV.OCR;
using Emgu.CV.Structure;
using Emgu.CV.Util;
namespace _1Laba
{
    public partial class Form1 : Form
    {
        //CascadeClassifier cascadeClassifier;
        private double Ten = 10;
        private Image<Bgr, byte> sourceImage;
        private Image<Bgr, byte> prevImage;
        private VideoCapture capture;
        private int frameCounter = 0;
        double cannyThreshold;
        double cannyThresholdLinking;
        int choice = 0;
        editImage newImage = new editImage();
        private int tb1 = 50, tb2, tb3, tb4,tb11 = 0,tb13=5;
        private double tb5 = 10, tb6 = 0, tb7 = 5, tb8 = 5, tb9 = 126, tb10 = 100, tb12 = 0;
        const int x1 = 500, x2 = 500, x3 = 500, x4 = 500 , y1 = 520, y2 = 560, y3 = 600, y4 = 640;
        private int numPts = 0;
        PointF[] pts = new PointF[4];
        Point pointRotate;
        int k1=1,k2=1;
        int numberAngle = 0;
        List<Rectangle> rois = new List<Rectangle>();
        VideoCapture capture1;
        Mat mask;
        Image<Gray, byte> gray;

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
        private Tesseract ocr;

        //----------------------------------------------------------------------------------------------------------------------------------Начало формы
        public Form1()
        {
            InitializeComponent();
            tbHide();
            visibleLR_false();
            visibleLR_true();
            locatedLR();
        }
        //----------------------------------------------------------------------------------------------------------------------------------Конец формы
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (choice == 31)
            {
                
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;*.png";
                var result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog1.FileName;
                    mask = CvInvoke.Imread(fileName, ImreadModes.Unchanged);
                    gray = mask.ToImage<Gray, byte>();
                    imageBox2.Image = gray;
                }
            }
            if (choice == 0)
            {
                sourceImage = newImage.loadfunction(sourceImage);
                if (sourceImage != null)
                {
                    imageBox1.Image = sourceImage.Resize(640, 480, Inter.Linear);
                    imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear);
                    
                }
            }
            timer2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            choice = 1;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            //choice = 3;
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
        private void ProcessFrame(object sender, EventArgs e)
        {            
           
            var frame1 = new Mat();
            capture1.Retrieve(frame1);
            Image<Bgr, byte> firstImage = frame1.ToImage<Bgr, byte>();

            Image<Gray, byte> grayImage = firstImage.Convert<Gray, byte>();
            using (CascadeClassifier cascadeClassifier = new CascadeClassifier("D:\\haarcascade_frontalface_default.xml"))
            {
                Rectangle[] facesDetected = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 10,
                new Size(20, 20));
                var copy = firstImage.Copy();
                if (mask != null)
                {
                    foreach (Rectangle rect in facesDetected)
                    {
                        Image<Bgra, byte> res = copy.Convert<Bgra, byte>();
                        res.ROI = rect;
                        Image<Bgra, byte> small = mask.ToImage<Bgra, byte>().Resize(rect.Width, rect.Height, Inter.Nearest);
                        Image<Gray, byte> graymask = small.Convert<Gray, byte>();
                        CvInvoke.cvCopy(small, res, small.Split()[3]);
                        res.ROI = System.Drawing.Rectangle.Empty;
                        imageBox2.Image = res;
                    }

                }
                else
                {
                    foreach (Rectangle rect in facesDetected)
                    {
                        copy.Draw(rect, new Bgr(Color.Green), 2);
                        imageBox2.Image = copy;
                    }
                }
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var frame = capture.QueryFrame();
            Image<Bgr, byte> firstImage = frame.ToImage<Bgr, byte>();
            //imageBox2.Image = firstImage;

            if (choice == 0)
                imageBox2.Image = sourceImage.Resize(640, 480, Inter.Linear);
            if (choice == 1)
                imageBox2.Image = newImage.filterCanny(firstImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);
            if (choice == 2)
                imageBox2.Image = newImage.thresholdFilter(firstImage, cannyThreshold, cannyThresholdLinking, tb1, tb2, tb3, tb4).Resize(640, 480, Inter.Linear);
            if (choice == 3)
                imageBox2.Image = firstImage;
            if (choice == 31)
            {
                Image<Gray, byte> grayImage = firstImage.Convert<Gray, byte>();
                 using (CascadeClassifier cascadeClassifier = new CascadeClassifier("D:\\haarcascade_frontalface_default.xml"))
                 {
                     Rectangle[] facesDetected = cascadeClassifier.DetectMultiScale(grayImage, 1.1, 10,
                     new Size(20, 20));
                     var copy = firstImage.Copy();
                     if (mask != null)
                     {
                         foreach (Rectangle rect in facesDetected)
                         {
                             Image<Bgra, byte> res = copy.Convert<Bgra, byte>();
                             res.ROI = rect;
                             Image<Bgra, byte> small = mask.ToImage<Bgra, byte>().Resize(rect.Width, rect.Height, Inter.Nearest);
                             Image<Gray, byte> graymask = small.Convert<Gray, byte>();
                             CvInvoke.cvCopy(small, res, small.Split()[3]);
                             res.ROI = Rectangle.Empty;
                             imageBox2.Image = res;
                         }

                     }
                     else
                     {
                         foreach (Rectangle rect in facesDetected)
                         {
                             copy.Draw(rect, new Bgr(Color.Green), 2);
                             imageBox2.Image = copy;
                         }
                     }
                 }
            }
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
            if(LR_3.SelectedIndex != 4)
            {
                imageBox1.Image = null;
                imageBox2.Image = null;
                imageBox2.ClearOperation();
                imageBox1.ClearOperation();
                timer1.Enabled = false;
                timer2.Enabled = false;
                choice = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                pts[i] = new PointF(0,0);
            }      

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
        //---------------------------------------------------------------------------------HIDE
        private void tbHide()
        {
            tbForComma.Clear();
            tbYcomma.Clear();
            tbForScale.Clear();
            tbY.Clear();
            tbForScale.Visible = false;
            tbForComma.Visible = false;
            tbY.Visible = false;
            tbYcomma.Visible = false;
            labelComma.Visible = false;
            labelComma1.Visible = false;
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
            trackBar13.Visible = false;
            RGBList.Visible = false;
            Accept_but.Visible = false;
            but_quarter1.Visible = false;
            but_quarter2.Visible = false;
            but_quarter3.Visible = false;
            but_quarter4.Visible = false;
            butCirkle.Visible = false;
            butRectangle.Visible = false;
            butTri.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;

            Rus_radioBut.Visible = false;
            Eng_radioBut.Visible = false;
            checkBox1.Visible = false;
            showText.Visible = false;
            showTextLb.Visible = false;
            guide5Lr.Visible = false;
            dilateLb.Visible = false;
            LoadMask.Visible = false;
        }
        //---------------------------------------------------------------------------------HIDE
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LR_3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LR_2.SelectedIndex != -1)
                LR_2.SetSelected(LR_2.SelectedIndex, false);
            if (LR_1.SelectedIndex != -1)
                LR_1.SetSelected(LR_1.SelectedIndex, false);
            tbHide();
            tbForScale.Visible = true;
            if (LR_3.SelectedIndex == 0)
            {
                choice = 18;
            }
            if (LR_3.SelectedIndex == 1)
            {
                choice = 19;
            }
            if (LR_3.SelectedIndex == 2)
            {
                choice = 20;
                tbY.Visible = true;
                tbYcomma.Visible = true;
                tbForComma.Visible = true;
                labelComma.Visible = true;
                labelComma1.Visible = true;
            }
            if (LR_3.SelectedIndex == 3)
            {
                choice = 21;
            }
            if (LR_3.SelectedIndex == 4)
            {
                tbForScale.Visible = false;
                choice = 22;
            }
            if (LR_3.SelectedIndex == 5)
            {
                tbForScale.Visible = false;
                but_quarter1.Visible = true;
                but_quarter2.Visible = true;
                but_quarter3.Visible = true;
                but_quarter4.Visible = true;
                choice = 23;
            }

        }

        private void Accept_but_Click(object sender, EventArgs e)
        {
            sourceImage = sourceImage.Resize(640, 480, Inter.Linear);
            try
            {
                if (choice == 18)
                    imageBox2.Image = newImage.editScale(sourceImage, double.Parse(tbForScale.Text));
                if (choice == 19)
                    imageBox2.Image = newImage.editBiScale(sourceImage, double.Parse(tbForScale.Text));
                if (choice == 20)
                {
                    if (tbForComma.Text.Length == 0)
                        tbForComma.Text = "0";

                    if (tbYcomma.Text.Length == 0)
                        tbYcomma.Text = "0";
                    double cx = double.Parse(tbForComma.Text) / Math.Pow(Ten, Convert.ToDouble(tbForComma.Text.Length));
                    double cy = double.Parse(tbYcomma.Text) / Math.Pow(Ten, Convert.ToDouble(tbYcomma.Text.Length));
                    imageBox2.Image = newImage.editShift(sourceImage, double.Parse(tbForScale.Text), double.Parse(tbY.Text), cx, cy);

                }
                if (choice == 21)
                {
                    imageBox2.Image = newImage.editRotate(sourceImage,pointRotate, Math.PI/double.Parse(tbForScale.Text));
                }
                if (choice == 22)
                {
                    imageBox2.Image = newImage.editPoint(sourceImage, pts);
                }

                if (choice == 30)
                {
                    
                    rois.Clear();
                    showText.Items.Clear();
                    imageBox2.Image = newImage.editRoiFinder(sourceImage, trackBar1.Value, checkBox1.Checked, trackBar7.Value, rois);
                    for (int i = 0; i < rois.Count; i++)
                    {
                        sourceImage.ROI = rois[i];
                        var roiCopy = sourceImage.Copy();
                        sourceImage.ROI = Rectangle.Empty;
                        if(ocr == null)
                        {
                            MessageBox.Show("Choice language");
                            Rus_radioBut.Checked = true;
                        }
                        ocr.SetImage(roiCopy);
                        ocr.Recognize();
                        string text = ocr.GetUTF8Text();
                        showText.Items.Add(text);
                    }
                                   
                }
                if(choice == 31)
                {
                   

                   /* capture1 = new VideoCapture();
                    capture1.ImageGrabbed += ProcessFrame;
                    capture1.Start(); */
                }


            }
            catch
            {
                MessageBox.Show("Enter number");
                tbForScale.Clear();
                tbY.Clear();
                tbForComma.Clear();
                tbYcomma.Clear();
            }
            
        }

        private void imageBox1_MouseClick(object sender, MouseEventArgs e)
        {
            var sourcecopy = sourceImage.Copy();

            int x = (int)(e.Location.X / imageBox1.ZoomScale);
            int y = (int)(e.Location.Y / imageBox1.ZoomScale);

            pointRotate = new Point(x, y);
            pts[numPts] = new PointF(x, y);
            numPts++;
            if (numPts >= 4)
                numPts = 0;

            Point center = new Point(x, y);
            int radius = 2;
            int thickness = 2;
            var color = new Bgr(Color.Blue).MCvScalar;

            for (int i = 0; i < 4; i++)
            {
                CvInvoke.Circle(sourcecopy, new Point((int)(pts[i].X), (int)(pts[i].Y)), radius, color, thickness);
            }

            imageBox1.Image = sourcecopy;

        }

        private void but_quarter2_Click(object sender, EventArgs e)
        {
            k1 = 1;
            k2 = -1;
        }

        private void but_quarter3_Click(object sender, EventArgs e)
        {
            k1 = -1;
            k2 = -1;

        }

        private void but_quarter4_Click(object sender, EventArgs e)
        {
            k1 = -1;
            k2 = 1;
  
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {   
            if(Rus_radioBut.Checked != true || Eng_radioBut.Checked != true)
            {
                visibleLR_false();
                visibleLR_true();
            }
        }
        private void visibleLR_false()
        {
            if(radioButton1.Checked == true)
            {
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                LR_4.Visible = false;
                LR_5.Visible = false;
                LR_6.Visible = false;
                LR_7.Visible = false;
            }
            if (radioButton2.Checked == true)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label7.Visible = false;
                LR_1.Visible = false;
                LR_2.Visible = false;
                LR_3.Visible = false;
                LR_7.Visible = false;

            }
            if (radioButton3.Checked == true)
            {
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                LR_1.Visible = false;
                LR_2.Visible = false;
                LR_3.Visible = false;
                LR_4.Visible = false;
                LR_5.Visible = false;
                LR_6.Visible = false;
            }
        }
        private void visibleLR_true()
        {
            if (radioButton1.Checked == true)
            {
                label1.Visible = true;
                label2.Visible = true;
                label3.Visible = true;

                LR_1.Visible = true;
                LR_2.Visible = true;
                LR_3.Visible = true;
            }
            if (radioButton2.Checked == true)
            {
                label4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;

                LR_4.Visible = true;
                LR_5.Visible = true;
                LR_6.Visible = true;
            }
            if (radioButton3.Checked == true)
            {
                label7.Visible = true;
                LR_7.Visible = true;
            }
        }
        private void locatedLR()
        {
            label4.Location = label1.Location;
            label5.Location = label2.Location;
            label6.Location = label3.Location;
            label7.Location = label2.Location;
            LR_4.Location = LR_1.Location;
            LR_5.Location = LR_2.Location;
            LR_6.Location = LR_3.Location;
            LR_7.Location = LR_1.Location;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (Rus_radioBut.Checked != true || Eng_radioBut.Checked != true)
            {
                visibleLR_false();
                visibleLR_true();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (Rus_radioBut.Checked != true || Eng_radioBut.Checked != true)
            {
                visibleLR_false();
                visibleLR_true();
            }
        }

        private void LR_4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LR_5.SelectedIndex != -1)
                LR_5.SetSelected(LR_5.SelectedIndex, false);
            if (LR_6.SelectedIndex != -1)
                LR_6.SetSelected(LR_6.SelectedIndex, false);
            tbHide();
            if (LR_4.SelectedIndex == 0)
            {
                choice = 25;
                //tbForScale.Visible = true;
                trackBar12.Visible = true; //порог
            }
            if (LR_4.SelectedIndex == 1)
            {
                choice = 26;
                trackBar12.Visible = true;
                trackBar13.Visible = true;
            }
            if (LR_4.SelectedIndex == 2)
            {
                choice = 27;
                butTri.Visible = true;
                butRectangle.Visible = true;
                butCirkle.Visible = true;

            }

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void butTri_Click(object sender, EventArgs e)
        {
            label16.Text = "--------";
            label17.Text = "--------";
            tbHide();
            numberAngle = 0;
            butTri.Visible = true;
            butRectangle.Visible = true;
            butCirkle.Visible = true;
            trackBar13.Visible = true;
            trackBar1.Visible = true;
            trackBar12.Visible = true;

            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;

        }

        private void butRectangle_Click(object sender, EventArgs e)
        {
            label17.Text = "--------";
            label15.Text = "--------";
            tbHide();
            numberAngle = 1;
            butTri.Visible = true;
            butRectangle.Visible = true;
            butCirkle.Visible = true;
            trackBar13.Visible = true;

            trackBar1.Visible = true;
            trackBar12.Visible = true;

            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
        }

        private void butCirkle_Click(object sender, EventArgs e)
        {
            label16.Text = "--------";
            label15.Text = "--------";
            tbHide();
            numberAngle = 2;
            butTri.Visible = true;
            butRectangle.Visible = true;
            butCirkle.Visible = true;
            trackBar9.Visible = true;
            trackBar10.Visible = true;

            trackBar1.Visible = true;
            trackBar12.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            label13.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;


            trackBar1.Value = 36;
            trackBar10.Maximum = 100;
            trackBar10.Value = 100;
            trackBar9.Maximum = 500;
            trackBar9.Value = 500;
            trackBar1.Minimum = 1;
            trackBar12.Minimum = 1;
            trackBar12.Maximum = 500;
            trackBar12.Value = 250;
        }

        private void LR_5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LR_4.SelectedIndex != -1)
                LR_4.SetSelected(LR_5.SelectedIndex, false);
            if (LR_6.SelectedIndex != -1)
                LR_6.SetSelected(LR_6.SelectedIndex, false);
            tbHide();
            checkBox1.Visible = true;
            trackBar1.Visible = true;
            trackBar1.Location = new Point(570, 640);
            label11.Visible = true;  //treshhold
            label11.Location = new Point(770, 640);
            guide5Lr.Visible = true;
            if (LR_5.SelectedIndex == 0)
            {
                choice = 28;


            }
            if (LR_5.SelectedIndex == 1)
            {
                choice = 29;
                dilateLb.Visible = true;
                dilateLb.Location = new Point(770, 700);
                trackBar7.Visible = true;
                trackBar7.Location = new Point(570, 700);
            }
            if (LR_5.SelectedIndex == 2)
            {
                choice = 30;
                trackBar7.Visible = true;
                Rus_radioBut.Visible = true;
                Eng_radioBut.Visible = true;
                showText.Visible = true;
                dilateLb.Visible = true;
                dilateLb.Location = new Point(770, 700);
                trackBar7.Location = new Point(570, 700);
            }
            if(LR_5.SelectedIndex == 3)
            {
                tbHide();
                choice = 31;
            }
        }

        private void Rus_radioBut_CheckedChanged(object sender, EventArgs e)
        {
            if(Rus_radioBut.Checked == true)
                ocr = new Tesseract("D:\\", "rus", OcrEngineMode.Default);
        }

        private void Eng_radioBut_CheckedChanged(object sender, EventArgs e)
        {
            if (Eng_radioBut.Checked == true)
                ocr = new Tesseract("D:\\", "eng", OcrEngineMode.Default);
        }

        private void showText_SelectedIndexChanged(object sender, EventArgs e)
        {
            sourceImage.ROI = rois[showText.SelectedIndex];
            var roiCopy = sourceImage.Copy();
            sourceImage.ROI = Rectangle.Empty;
            imageBox2.Image = roiCopy;
            showTextLb.Text = Convert.ToString(showText.SelectedItem);
        }

        private void LoadMask_Click(object sender, EventArgs e)
        {
            timer2.Enabled = false;
            capture1 = new VideoCapture();
            capture1.ImageGrabbed += ProcessFrame;
            capture1.Start();
        }

        private void trackBar13_Scroll(object sender, EventArgs e)
        {
            tb13 = trackBar13.Value;
        }

        private void but_quarter1_Click(object sender, EventArgs e)
        {
            k1 = 1;
            k2 = 1;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            choice = 13;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            choice = 14;
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
            if(LR_2.SelectedIndex != -1)
            LR_2.SetSelected(LR_2.SelectedIndex, false);
            if (LR_3.SelectedIndex != -1)
                LR_3.SetSelected(LR_3.SelectedIndex, false);
            choice = 1;
            tbHide();

            vScrollBar1.Visible = true;
            hScrollBar1.Visible = true;


            if (LR_1.SelectedIndex == 1)
            {
                choice = 2;
                trackBar1.Visible = true;
                trackBar2.Visible = true;
                trackBar3.Visible = true;
                trackBar4.Visible = true;
            }
            if (LR_1.SelectedIndex == 2)
            {
                //button3_Click(sender,e);
                trackBar1.Visible = true;
                trackBar2.Visible = true;
                trackBar3.Visible = true;
                trackBar4.Visible = true;
            }
        }


        private void LR_2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LR_1.SelectedIndex != -1)
                LR_1.SetSelected(LR_1.SelectedIndex, false);
            if (LR_3.SelectedIndex != -1)
                LR_3.SetSelected(LR_3.SelectedIndex, false);

            tbHide();


            if (LR_2.SelectedIndex == 0)
            {
                RGBList.Visible = true;
                choice = 4;
                RGBList.Location = new Point (x1, y1);   
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
                trackBar5.Location = new Point(x1, y1);
                trackBar6.Location = new Point(x2, y2);
            }
            if (LR_2.SelectedIndex == 4)
            {
                choice = 8;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar7.Location = new Point(x1, y1);
                trackBar8.Location = new Point(x2, y2);
                prevImage = newImage.loadfunction(prevImage);
            }
            if (LR_2.SelectedIndex == 5)
            {
                choice = 9;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar7.Location = new Point(x1, y1);
                trackBar8.Location = new Point(x2, y2);
                prevImage = newImage.loadfunction(prevImage);
            }
            if (LR_2.SelectedIndex == 6)
            {
                choice = 10;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar7.Location = new Point(x1, y1);
                trackBar8.Location = new Point(x2, y2);
                prevImage = newImage.loadfunction(prevImage);
            }
            if (LR_2.SelectedIndex == 7)
            {
                choice = 24;
                trackBar11.Visible = true;
                trackBar12.Visible = true;
                trackBar11.Location = new Point(x1, y1);
                trackBar12.Location = new Point(x2, y2);
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
                choice = 16;
                trackBar5.Visible = true;
                trackBar6.Visible = true;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar5.Location = new Point(x1, y1);
                trackBar6.Location = new Point(x2, y2);
                trackBar7.Location = new Point(x3, y3);
                trackBar8.Location = new Point(x4, y4);
                prevImage = newImage.loadfunction(prevImage);
            }
            if (LR_2.SelectedIndex == 13)
            {
                choice = 17;
                trackBar7.Visible = true;
                trackBar8.Visible = true;
                trackBar9.Visible = true;
                trackBar10.Visible = true;
                trackBar7.Location = new Point(x1, y1);
                trackBar8.Location = new Point(x2, y2);
                trackBar9.Location = new Point(x3, y3);
                trackBar10.Location = new Point(x4, y4);
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
            {
                imageBox2.Image = sourceImage;
            }
            if (choice == 1)
            {
                imageBox2.Image = newImage.filterCanny(sourceImage, cannyThreshold, cannyThresholdLinking).Resize(640, 480, Inter.Linear);
            }
            if (choice == 2)
            {
                imageBox2.Image = newImage.thresholdFilter(sourceImage, cannyThreshold, cannyThresholdLinking, tb1, tb2, tb3, tb4).Resize(640, 480, Inter.Linear);
            }    
            if (choice == 4 && RGBList.SelectedItem != null)
            {
                imageBox2.Image = newImage.editColourChanel(sourceImage.Resize(640, 480, Inter.Linear), RGBList);
            }      
            if (choice == 5)
            {
                imageBox2.Image = newImage.grayAlgoritm(sourceImage.Resize(640, 480, Inter.Linear));
            }
            if (choice == 6)
            {
                imageBox2.Image = newImage.Sepia(sourceImage.Resize(640, 480, Inter.Linear));
            }              
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
            {
                imageBox2.Image = newImage.editBlur(sourceImage.Resize(640, 480, Inter.Linear));
            }            
            if (choice == 12)
            {
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass);
            }        
            if (choice == 13)
            {
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass1);
            }
            if (choice == 14)
            {
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass2);
            }
            if (choice == 15)
            {
                imageBox2.Image = newImage.editMass(sourceImage.Resize(640, 480, Inter.Linear), mass3);
            }
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
            if (choice == 18 || choice == 19 || choice == 21)
            {
                if (tbForScale.Text.Length != 0)
                {
                    Accept_but.Show();
                    
                }
                else Accept_but.Hide();

            }
            if (choice == 20)
            {
                if (tbForScale.Text.Length != 0 && tbY.Text.Length != 0)
                {
                    Accept_but.Show();
                }
                else Accept_but.Hide();

            }
            if (choice == 22)
            {
                if (pts != null)
                {
                    Accept_but.Show();
                }
                else Accept_but.Hide();

            }
            if (choice == 23)
            {
                imageBox2.Image = newImage.editFlip(sourceImage, k1, k2);
            }
            if (choice == 24)
            {
                imageBox2.Image = newImage.editHSV(sourceImage.Resize(640, 480, Inter.Linear), tb11, tb12);
            }
            if (choice == 25)
            {
                imageBox2.Image = newImage.edit_Noise_and_Brightness(sourceImage.Resize(640, 480, Inter.Linear), tb12);
            }
            if (choice == 26)
            {
                imageBox2.Image = newImage.edit_contours(sourceImage.Resize(640, 480, Inter.Linear), tb12,tb13);
            }
            if (choice == 27)
            {
                if (numberAngle == 0)
                {
                    label15.Text = newImage.Number_of_Figure();
                    imageBox2.Image = newImage.findTriangles(sourceImage.Resize(640, 480, Inter.Linear), tb12, tb13, tb1);
                }
                if (numberAngle == 1)
                {
                    label16.Text = newImage.Number_of_Figure();
                    imageBox2.Image = newImage.findRectangles(sourceImage.Resize(640, 480, Inter.Linear), tb12, tb13, tb1);
                }

                if (numberAngle == 2)
                {
                    label17.Text = newImage.Number_of_Figure();
                    imageBox2.Image = newImage.findCirkle(sourceImage.Resize(640, 480, Inter.Linear), trackBar12.Value, tb1, trackBar10.Value, trackBar9.Value);

                }
            }
            if (choice == 28)
            {
                imageBox2.Image = newImage.editBinarize(sourceImage, trackBar1.Value, checkBox1.Checked);
            }
            if (choice == 29)
            {
                imageBox2.Image = newImage.editDilatade(sourceImage, trackBar1.Value, checkBox1.Checked, trackBar7.Value);
            }
            if (choice == 30)
            {
                Accept_but.Show();
            }
            if (choice == 31) 
            {
                LoadMask.Visible = true;
            }

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
             tb1 = trackBar1.Value;
        }

    }
}
