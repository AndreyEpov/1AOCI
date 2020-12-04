using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using Emgu.CV.Util;
namespace _1Laba
{
    public class editImage
    {
        private double value;
        private PointF[] pts = new PointF[4];
        private int delta = 10;
        private int number;
        public Image<Bgr, byte> loadfunction(Image<Bgr, byte> image)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "(*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif;*.png";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fileName = openFileDialog1.FileName;
                image = new Image<Bgr, byte>(fileName).Resize(640, 480, Inter.Linear);
            }
            return image;
        }
        public Image<Gray, byte> editGray(Image<Bgr, byte> sourceImage)
        {
            Image<Gray, byte> grayImage = sourceImage.Convert<Gray, byte>();

            return grayImage;
        }
        public Image<Gray, byte> filterCanny(Image<Bgr, byte> sourceImage, double value1, double value2)
        {
            Image<Gray, byte> grayImage = editGray(sourceImage);
            var tempImage = grayImage.PyrDown();
            var destImage = tempImage.PyrUp();
            double cannyThreshold = value1;
            double cannyThresholdLinking = value2;
            Image<Gray, byte> cannyEdges = destImage.Canny(cannyThreshold, cannyThresholdLinking);
            return cannyEdges;
        }
        public Image<Bgr, byte> thresholdFilter(Image<Bgr, byte> sourceImage, double value1, double value2, int tb1, int tb2, int tb3, int tb4)
        {
            Image<Gray, byte> cannyEdges = filterCanny(sourceImage, value1, value2);
            Image<Bgr, byte> cannyEdgesBgr = cannyEdges.Convert<Bgr, byte>();
            Image<Bgr, byte> resultImage = sourceImage.Sub(cannyEdgesBgr);
            //обход по каналам
            for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
                for (int x = 0; x < resultImage.Width; x++)
                    for (int y = 0; y < resultImage.Height; y++) // обход по пискелям
                    {
                        // получение цвета пикселя
                        byte color = resultImage.Data[y, x, channel];
                        if (color <= tb1)
                            color = 0;
                        else if (color <= tb2)
                            color = 25;
                        else if (color <= tb3)
                            color = 180;
                        else if (color <= tb4)
                            color = 210;
                        else
                            color = 255;
                        resultImage.Data[y, x, channel] = color; // изменение цвета пикселя
                    }

            return resultImage;
        }
        public Image<Bgr, byte> editColourChanel(Image<Bgr, byte> sourceImage, CheckedListBox checkedListBox)
        {

            var channel = sourceImage.Split()[checkedListBox.SelectedIndex];

            Image<Bgr, byte> destImage = sourceImage.CopyBlank();

            VectorOfMat vm = new VectorOfMat();
            for (int i = 0; i < 3; i++)
            {
                if (i == checkedListBox.SelectedIndex)
                    vm.Push(channel);
                else
                    vm.Push(channel.CopyBlank());
            }
            CvInvoke.Merge(vm, destImage);
            return destImage;
        }
        public Image<Gray, byte> grayAlgoritm(Image<Bgr, byte> sourceImage)
        {
            var grayImage = new Image<Gray, byte>(sourceImage.Size);
            for (int y = 0; y < sourceImage.Size.Height; y++)
                for (int x = 0; x < sourceImage.Size.Width; x++)
                    grayImage.Data[y, x, 0] = Convert.ToByte(0.299 * sourceImage.Data[y, x, 2] + 0.587 * sourceImage.Data[y, x, 1] + 0.114 * sourceImage.Data[y, x, 0]);

            return grayImage;
        }
        public Image<Bgr, byte> Sepia(Image<Bgr, byte> sourceImage)
        {
            double a1 = 0, a2 = 0, a3 = 0;
            var destImage = sourceImage.Copy();
            for (int ch = 0; ch < 3; ch++)
            {
                if (ch == 0)
                {
                    a1 = 0.272;
                    a2 = 0.534;
                    a3 = 0.131;
                }
                if (ch == 1)
                {
                    a1 = 0.349;
                    a2 = 0.686;
                    a3 = 0.168;
                }
                if (ch == 2)
                {
                    a1 = 0.393;
                    a2 = 0.769;
                    a3 = 0.189;
                }
                for (int y = 0; y < destImage.Size.Height; y++)
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if (a1 * destImage.Data[y, x, ch] + a2 * destImage.Data[y, x, ch] + a3 * destImage.Data[y, x, ch] > 255)
                            destImage.Data[y, x, ch] = 255;
                        else
                            destImage.Data[y, x, ch] = Convert.ToByte(a1 * destImage.Data[y, x, ch] + a2 * destImage.Data[y, x, ch] + a3 * destImage.Data[y, x, ch]);

                    }
            }

            return destImage;
        }
        public Image<Bgr, byte> editBrightness(Image<Bgr, byte> sourceImage, double value1)
        {
            var destImage = sourceImage.Copy();
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
                for (int y = 0; y < destImage.Size.Height; y++)
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if ((destImage.Data[y, x, channel] + value1) > 255)
                            destImage.Data[y, x, channel] = 255;
                        else if ((destImage.Data[y, x, channel] + value1) <= 0)
                            destImage.Data[y, x, channel] = 10;
                        else
                            destImage.Data[y, x, channel] = (byte)(sourceImage.Data[y, x, channel] + value1);
                    }


            return destImage;
        }
        public Image<Bgr, byte> editContrast(Image<Bgr, byte> sourceImage, double value1)
        {

            var destImage = sourceImage.Copy();
            value = value1 / 10;
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
                for (int y = 0; y < destImage.Size.Height; y++)
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if ((destImage.Data[y, x, channel] * value) > 255)
                            destImage.Data[y, x, channel] = 255;
                        else
                            destImage.Data[y, x, channel] = (byte)(sourceImage.Data[y, x, channel] * value);
                    }
            return destImage;
        }
        public Image<Bgr, byte> additionImage(Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2, int sum, double value1, double value2)
        {
            value1 /= 10;
            value2 /= 10;
            var destImage = sourceImage.Copy();
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = 0; y < destImage.Size.Height; y++)
                {
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if (sourceImage2 != null)
                        {
                            if ((sourceImage.Data[y, x, channel] * value1 + sourceImage2.Data[y, x, channel] * value2) > 255)
                            {
                                destImage.Data[y, x, channel] = 255;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] = Convert.ToByte(sourceImage.Data[y, x, channel] * value1 + sourceImage2.Data[y, x, channel] * value2);
                            }
                        }
                        else
                        {
                            if ((destImage.Data[y, x, channel] + sum) > 255)
                            {
                                destImage.Data[y, x, channel] = 255;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] += Convert.ToByte(sum);
                            }
                        }
                    }
                }

            }
            return destImage;
        }
        public Image<Bgr, byte> intersectionImage(Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2, double sum, double value1, double value2)
        {
            value1 /= 10;
            value2 /= 10;
            var destImage = sourceImage.Copy();
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = 0; y < destImage.Size.Height; y++)
                {
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if (sourceImage2 != null)
                        {
                            if (Convert.ToDouble((sourceImage.Data[y, x, channel] * value1 / 10) * (sourceImage2.Data[y, x, channel] * value2 / 10)) > 255)
                            {
                                destImage.Data[y, x, channel] = 255;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] = Convert.ToByte((sourceImage.Data[y, x, channel] * value1 / 10) * (sourceImage2.Data[y, x, channel] * value2 / 10));
                            }
                        }
                        else
                        {
                            if ((destImage.Data[y, x, channel] * Convert.ToDouble(sum / 10)) > 255)
                            {
                                destImage.Data[y, x, channel] = 255;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] = Convert.ToByte(destImage.Data[y, x, channel] * Convert.ToDouble(sum / 10));
                            }
                        }
                    }
                }

            }
            return destImage;
        }
        public Image<Bgr, byte> exceptionImage(Image<Bgr, byte> sourceImage, Image<Bgr, byte> sourceImage2, int sum, double value1, double value2)
        {
            value1 /= 10;
            value2 /= 10;
            var destImage = sourceImage.Copy();
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = 0; y < destImage.Size.Height; y++)
                {
                    for (int x = 0; x < destImage.Size.Width; x++)
                    {
                        if (sourceImage2 != null)
                        {
                            if ((sourceImage.Data[y, x, channel] * value1 - sourceImage2.Data[y, x, channel] * value2) < 0)
                            {
                                destImage.Data[y, x, channel] = 0;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] = Convert.ToByte(sourceImage.Data[y, x, channel] * value1 - sourceImage2.Data[y, x, channel] * value2);
                            }
                        }
                        else
                        {
                            if ((destImage.Data[y, x, channel] + sum) < 0)
                            {
                                destImage.Data[y, x, channel] = 0;
                            }
                            else
                            {
                                destImage.Data[y, x, channel] = Convert.ToByte(Convert.ToInt16(destImage.Data[y, x, channel]) + sum);
                            }
                        }
                    }
                }

            }
            return destImage;
        }
        public Image<Bgr, byte> editBlur(Image<Bgr, byte> sourceImage)
        {
            var destImage = sourceImage.CopyBlank();
            int sh = 1;
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = sh; y < destImage.Size.Height - sh; y++)
                {
                    for (int x = sh; x < destImage.Size.Width - sh; x++)
                    {
                        List<byte> blurl = new List<byte>();
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                blurl.Add(sourceImage.Data[y + j, x + i, channel]);
                            }
                        }
                        blurl.Sort();
                        destImage.Data[y, x, channel] = blurl[4];
                    }
                }
            }
            return destImage;
        }
        public Image<Bgr, byte> editMass(Image<Bgr, byte> sourceImage, int[,] mat)
        {

            var destImage = sourceImage.CopyBlank();
            int sh = 1;
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = sh; y < destImage.Size.Height - sh; y++)
                {
                    for (int x = sh; x < destImage.Size.Width - sh; x++)
                    {
                        int result = 0;
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                result += sourceImage.Data[j + y, i + x, channel] * mat[i + 1, j + 1];
                            }
                        }

                        if (result > 255) result = 255; else if (result < 0) result = 0;
                        destImage.Data[y, x, channel] = Convert.ToByte(result);
                    }
                }
            }
            return destImage;
        }
        public Image<Bgr, byte> editEdge(Image<Gray, byte> sourceImage, double value1, double value2)
        {
            var edges = sourceImage;
            edges = edges.ThresholdAdaptive(new Gray(value1), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, new Gray(value2 / 10));
            Image<Bgr, byte> edgesBgr = edges.Convert<Bgr, byte>();
            return edgesBgr;
        }
        public Image<Gray, byte> editBlurGray(Image<Bgr, byte> sourceImage)
        {
            var blurimg = editGray(sourceImage);
            var destImage = blurimg.CopyBlank();
            int sh = 1;
            for (int channel = 0; channel < destImage.NumberOfChannels; channel++)
            {
                for (int y = sh; y < destImage.Size.Height - sh; y++)
                {
                    for (int x = sh; x < destImage.Size.Width - sh; x++)
                    {
                        List<byte> blurl = new List<byte>();
                        for (int i = -1; i < 2; i++)
                        {
                            for (int j = -1; j < 2; j++)
                            {
                                blurl.Add(blurimg.Data[y + j, x + i, channel]);
                            }
                        }
                        blurl.Sort();
                        destImage.Data[y, x, channel] = blurl[4];
                    }
                }
            }
            return destImage;
        }
        public Image<Hsv, byte> editHSV(Image<Bgr, byte> sourceImage, int value, double value1)
        {
            Image<Hsv, byte> imageHsv = sourceImage.Convert<Hsv, byte>();
            for (int y = 0; y < imageHsv.Size.Height; y++)
            {
                for (int x = 0; x < imageHsv.Size.Width; x++)
                {
                    imageHsv.Data[y, x, value] = (byte)value1;

                }
            }
            return imageHsv;
        }
        public Image<Bgr, byte> editScale(Image<Bgr, byte> sourceImage, double k)
        {
            Image<Bgr, byte> scaleImg = new Image<Bgr, byte>((int)(sourceImage.Width * k), (int)(sourceImage.Height * k));
            for (int i = 0; i < scaleImg.Width; i++)
                for (int j = 0; j < scaleImg.Height; j++)
                {
                    int oldI = (int)(i / k);
                    int oldJ = (int)(j / k);
                    scaleImg[j, i] = sourceImage[oldJ, oldI];
                }

            return scaleImg;
        }

        public Image<Bgr, byte> editBiScale(Image<Bgr, byte> sourceImage, double k)
        {
            Image<Bgr, byte> scaleImg = new Image<Bgr, byte>((int)(sourceImage.Width * k), (int)(sourceImage.Height * k));
            for (int i = 0; i < scaleImg.Width - 1; i++)
                for (int j = 0; j < scaleImg.Height - 1; j++)
                {
                    double I = (i / k);
                    double J = (j / k);


                    double baseI = Math.Floor(I);
                    double baseJ = Math.Floor(J);
                    if (baseI >= sourceImage.Width - 1) continue;
                    if (baseJ >= sourceImage.Height - 1) continue;

                    double rI = I - baseI;
                    double rJ = J - baseJ;

                    double irI = 1 - rI;
                    double irJ = 1 - rJ;

                    Bgr c1 = new Bgr();
                    c1.Blue = sourceImage.Data[(int)baseJ, (int)baseI, 0] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 0] * rI;
                    c1.Green = sourceImage.Data[(int)baseJ, (int)baseI, 1] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 1] * rI;
                    c1.Red = sourceImage.Data[(int)baseJ, (int)baseI, 2] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 2] * rI;

                    Bgr c2 = new Bgr();
                    c2.Blue = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 0] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 0] * rI;
                    c2.Green = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 1] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 1] * rI;
                    c2.Red = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 2] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 2] * rI;

                    Bgr c = new Bgr();
                    c.Blue = c1.Blue * irJ + c2.Blue * rJ;
                    c.Green = c1.Green * irJ + c2.Green * rJ;
                    c.Red = c1.Red * irJ + c2.Red * rJ;

                    scaleImg[j, i] = c;
                }

            return scaleImg;
        }
        public Image<Bgr, byte> editShift(Image<Bgr, byte> sourceImage, double x, double y, double cx, double cy)
        {

            double sx = x + cx;
            double sy = y + cy;
            Image<Bgr, byte> shiftedImg = new Image<Bgr, byte>((int)(sourceImage.Width), (int)(sourceImage.Height));
            if (sy == 0)
            {
                for (int i = 0; i < shiftedImg.Width - 1; i++)
                    for (int j = 0; j < shiftedImg.Height - 1; j++)
                    {
                        double I = (i + sx * (shiftedImg.Height - j));
                        double J = j;

                        double baseI = Math.Floor(I);
                        double baseJ = Math.Floor(J);

                        if (baseI >= sourceImage.Width - 1) continue;
                        if (baseJ >= sourceImage.Height - 1) continue;

                        double rI = I - baseI;
                        double rJ = J - baseJ;

                        double irI = 1 - rI;
                        double irJ = 1 - rJ;

                        Bgr c1 = new Bgr();
                        c1.Blue = sourceImage.Data[(int)baseJ, (int)baseI, 0] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 0] * rI;
                        c1.Green = sourceImage.Data[(int)baseJ, (int)baseI, 1] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 1] * rI;
                        c1.Red = sourceImage.Data[(int)baseJ, (int)baseI, 2] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 2] * rI;

                        Bgr c2 = new Bgr();
                        c2.Blue = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 0] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 0] * rI;
                        c2.Green = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 1] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 1] * rI;
                        c2.Red = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 2] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 2] * rI;

                        Bgr c = new Bgr();

                        c.Blue = c1.Blue * irJ + c2.Blue * rJ;
                        c.Green = c1.Green * irJ + c2.Green * rJ;
                        c.Red = c1.Red * irJ + c2.Red * rJ;

                        shiftedImg[j, i] = c;
                    }
            }
            if (sx == 0)
            {
                for (int i = 0; i < shiftedImg.Width - 1; i++)
                    for (int j = 0; j < shiftedImg.Height - 1; j++)
                    {
                        double I = i;
                        double J = j + sy * (shiftedImg.Width - i);

                        double baseI = Math.Floor(I);
                        double baseJ = Math.Floor(J);

                        if (baseI >= sourceImage.Width - 1) continue;
                        if (baseJ >= sourceImage.Height - 1) continue;

                        double rI = I - baseI;
                        double rJ = J - baseJ;

                        double irI = 1 - rI;
                        double irJ = 1 - rJ;

                        Bgr c1 = new Bgr();
                        c1.Blue = sourceImage.Data[(int)baseJ, (int)baseI, 0] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 0] * rI;
                        c1.Green = sourceImage.Data[(int)baseJ, (int)baseI, 1] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 1] * rI;
                        c1.Red = sourceImage.Data[(int)baseJ, (int)baseI, 2] * irI + sourceImage.Data[(int)baseJ, (int)baseI + 1, 2] * rI;

                        Bgr c2 = new Bgr();
                        c2.Blue = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 0] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 0] * rI;
                        c2.Green = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 1] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 1] * rI;
                        c2.Red = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 2] * irI + sourceImage.Data[(int)(baseJ + 1), (int)baseI + 1, 2] * rI;

                        Bgr c = new Bgr();

                        c.Blue = c1.Blue * irJ + c2.Blue * rJ;
                        c.Green = c1.Green * irJ + c2.Green * rJ;
                        c.Red = c1.Red * irJ + c2.Red * rJ;

                        shiftedImg[j, i] = c;
                    }
            }
            return shiftedImg;
        }
        public Image<Bgr, byte> editRotate(Image<Bgr, byte> sourceImage, Point p, double ang)
        {
            Image<Bgr, byte> rotateimage = sourceImage.CopyBlank();

            for (int i = 0; i < rotateimage.Width - 1; i++)
            {
                for (int j = 0; j < rotateimage.Height - 1; j++)
                {
                    int newI = Convert.ToInt32(Math.Cos(ang) * (j - p.X) - Math.Sin(ang) * (i - p.Y) + p.X);
                    int newJ = Convert.ToInt32(Math.Sin(ang) * (j - p.X) + (Math.Cos(ang)) * (i - p.Y) + p.Y);
                    if (newI <= (rotateimage.Width - 1) && newI >= 0 && newJ <= (rotateimage.Height - 1) && newJ >= 0)
                    {

                        double I = newI;
                        double J = newJ;

                        double baseI = Math.Floor(I);
                        double baseJ = Math.Floor(J);

                        if (baseI >= sourceImage.Width - 1) continue;
                        if (baseJ >= sourceImage.Height - 1) continue;

                        double rI = I - baseI;
                        double rJ = J - baseJ;

                        double irI = 1 - rI;
                        double irJ = 1 - rJ;

                        Bgr c1 = new Bgr();
                        c1.Blue = sourceImage.Data[(int)baseJ, (int)baseI, 0] * irI + sourceImage.Data[(int)baseJ, (int)(baseI + 1), 0] * rI;
                        c1.Green = sourceImage.Data[(int)baseJ, (int)baseI, 1] * irI + sourceImage.Data[(int)baseJ, (int)(baseI + 1), 1] * rI;
                        c1.Red = sourceImage.Data[(int)baseJ, (int)baseI, 2] * irI + sourceImage.Data[(int)baseJ, (int)(baseI + 1), 2] * rI;

                        Bgr c2 = new Bgr();
                        c2.Blue = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 0] * irI + sourceImage.Data[(int)(baseJ + 1), (int)(baseI + 1), 0] * rI;
                        c2.Green = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 1] * irI + sourceImage.Data[(int)(baseJ + 1), (int)(baseI + 1), 1] * rI;
                        c2.Red = sourceImage.Data[(int)(baseJ + 1), (int)baseI, 2] * irI + sourceImage.Data[(int)(baseJ + 1), (int)(baseI + 1), 2] * rI;

                        Bgr c = new Bgr();
                        c.Blue = c1.Blue * irJ + c2.Blue * rJ;
                        c.Green = c1.Green * irJ + c2.Green * rJ;
                        c.Red = c1.Red * irJ + c2.Red * rJ;

                        rotateimage[j, i] = c;
                    }
                }
            }
            return rotateimage;
        }
        public Image<Bgr, byte> editPoint(Image<Bgr, byte> sourceImage, PointF[] pts)
        {
            var srcPoints = pts;

            var destPoints = new PointF[]
            {
                new PointF(0, 0),
                new PointF(0, sourceImage.Height - 1),
                new PointF(sourceImage.Width - 1, sourceImage.Height - 1),
                new PointF(sourceImage.Width - 1, 0)
            };

            var homographyMatrix = CvInvoke.GetPerspectiveTransform(srcPoints, destPoints);
            var imgCopy = new Image<Bgr, byte>(sourceImage.Size);
            CvInvoke.WarpPerspective(sourceImage, imgCopy, homographyMatrix, imgCopy.Size);
            return imgCopy;
        }
        public Image<Bgr, byte> editFlip(Image<Bgr, byte> sourceImage, int k1, int k2)
        {
            Image<Bgr, byte> flipedimage = sourceImage.Copy();
            for (int i = 0; i < sourceImage.Width - 1; i++)
            {
                for (int j = 0; j < sourceImage.Height - 1; j++)
                {
                    int newX = i;
                    int newY = j;
                    if (k1 == -1)
                    {
                        newX = i * k1 + sourceImage.Width - 1;
                    }
                    if (k2 == -1)
                    {
                        newY = j * k2 + sourceImage.Height - 1;
                    }

                    flipedimage[newY, newX] = sourceImage[j, i];
                }
            }
            return flipedimage;
        }

        public Image<Gray, byte> edit_Noise_and_Brightness(Image<Bgr, byte> sourceImage, double k2)
        {
            var grayImage = sourceImage.Convert<Gray, byte>();

            var bluredImage = grayImage.SmoothGaussian(5);
            var color = new Gray(255);
            var binarizedImage = bluredImage.ThresholdBinary(new Gray(k2), color);

            return binarizedImage;
        }

        public Image<Bgr, byte> edit_contours(Image<Bgr, byte> sourceImage, double k2, int thicc)
        {
            Image<Gray, byte> binarizedImage = edit_Noise_and_Brightness(sourceImage, k2);
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(
                binarizedImage,
                contours,
                null,
                RetrType.List,
                ChainApproxMethod.ChainApproxSimple);

            var contoursImage = sourceImage.Copy();
            for (int i = 0; i < contours.Size; i++)
            {
                var points = contours[i].ToArray();
                contoursImage.Draw(points, new Bgr(Color.GreenYellow), thicc);
            }

            return contoursImage;
        }
        public Image<Bgr, byte> findTriangles(Image<Bgr, byte> sourceImage, double k2, int thicc, int tresh)
        {
            number = 0;
            Image<Gray, byte> binarizedImage = edit_Noise_and_Brightness(sourceImage, k2);
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(
                binarizedImage,
                contours,
                null,
                RetrType.List,
                ChainApproxMethod.ChainApproxSimple);

            var contoursImage = sourceImage.Copy();

            var approxContour = new VectorOfPoint();

            for (int i = 0; i < contours.Size; i++)
            {
                CvInvoke.ApproxPolyDP(
                    contours[i],
                    approxContour,
                    CvInvoke.ArcLength(contours[i], true) * 0.05,
                    true);
                if (CvInvoke.ContourArea(approxContour, false) > tresh)
                {

                    if (approxContour.Size == 3)
                    {
                        var points = approxContour.ToArray();
                        contoursImage.Draw(new Triangle2DF(points[0], points[1], points[2]),
                        new Bgr(Color.GreenYellow), thicc);
                        number++;
                    }
                }
            }

            return contoursImage;
        }
        public Image<Bgr, byte> findRectangles(Image<Bgr, byte> sourceImage, double k2, int thicc, int tresh)
        {
            number = 0;
            Image<Gray, byte> binarizedImage = edit_Noise_and_Brightness(sourceImage, k2);
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(
                binarizedImage,
                contours,
                null,
                RetrType.List,
                ChainApproxMethod.ChainApproxSimple);

            var contoursImage = sourceImage.Copy();

            var approxContour = new VectorOfPoint();

            for (int i = 0; i < contours.Size; i++)
            {
                CvInvoke.ApproxPolyDP(
                    contours[i],
                    approxContour,
                    CvInvoke.ArcLength(contours[i], true) * 0.05,
                    true);

                if (CvInvoke.ContourArea(approxContour, false) > tresh)
                {
                    var points = approxContour.ToArray();
                    if (isRectangle(points, delta) == true)
                    {
                        contoursImage.Draw(CvInvoke.MinAreaRect(approxContour), new Bgr(Color.GreenYellow), thicc);
                        number++;
                    }
                }
            }
            return contoursImage;
        }
        private bool isRectangle(Point[] points, int delta)
        {
            LineSegment2D[] edges = PointCollection.PolyLine(points, true);
            for (int i = 0; i < edges.Length; i++)
            {
                double angle = Math.Abs(edges[(i + 1) %
                edges.Length].GetExteriorAngleDegree(edges[i]));
                if (angle < 90 - delta || angle > 90 + delta)
                {
                    return false;
                }
            }
            return true;
        }
        public Image<Bgr, byte> findCirkle(Image<Bgr, byte> sourceImage, int minDist, int tresh, int minRad, int maxRad)
        {
            number = 0;
            var grayImage = sourceImage.Convert<Gray, byte>();
            var bluredImage = grayImage.SmoothGaussian(9);

            List<CircleF> circles = new List<CircleF>(CvInvoke.HoughCircles(bluredImage,
                 HoughModes.Gradient,
                 1.0,
                 minDist,//min dist
                 100,
                 tresh,//treshold
                 minRad,//min rad
                 maxRad));//max rad

            var resultImage = sourceImage.Copy();
            foreach (CircleF circle in circles)
            {
                resultImage.Draw(circle, new Bgr(Color.Blue), 2);
                number++;
            }

            return resultImage.Resize(640, 480, Inter.Linear);
        }

        public string Number_of_Figure()
        {
            string s = number.ToString();
            return s;
        }

        public Image<Gray, byte> editBinarize(Image<Bgr, byte> sourceImage, int k1, bool k2)//Белый текст на чёрном фоне надо получить
        {
            var grayImage = sourceImage.Convert<Gray, byte>();
            Image<Gray, byte> binarizedImage;
            if (k2 == true)
            {
                binarizedImage = grayImage.ThresholdBinaryInv(new Gray(k1), new Gray(255));
            }
            else
            {
                binarizedImage = grayImage.ThresholdBinary(new Gray(k1), new Gray(255));
            }

            return binarizedImage;
        }
        public Image<Gray, byte> editDilatade(Image<Bgr, byte> sourceImage, int k1, bool k2, int k3)
        {
            var binarizedImage = editBinarize(sourceImage, k1, k2);

            var dilatedImage = binarizedImage.Dilate(k3);

            return dilatedImage;
        }
        public Image<Bgr, byte> editRoiFinder(Image<Bgr, byte> sourceImage, int k1, bool k2, int k3, List<Rectangle> rois)
        {
            var dilatedImage = editDilatade(sourceImage, k1, k2, k3);

            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(dilatedImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            var img = sourceImage.Copy();
            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > (50))
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    rois.Add(rect);

                    img.Draw(rect, new Bgr(Color.Green), 2);
                }
            }

            return img;
        }
        public Image<Bgr, byte> editDiffusal(Image<Bgr, byte> sourceImage, Image<Gray, byte> background)
        {
            Image<Gray, byte> diff = background.AbsDiff(sourceImage.Convert<Gray, byte>());

            diff.Erode(3);
            diff.Dilate(4);

            Image<Gray, byte> binarizedImage = diff.ThresholdBinary(new Gray(120), new Gray(255));

            var copy = sourceImage.Copy();
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(binarizedImage, contours, null, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 1000)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);
                    copy.Draw(rect, new Bgr(Color.Red), 1);
                }
            }

            return copy;
        }
        public Image<Bgr, byte> editFilterMask(Image<Gray, byte> mask, Image<Bgr, byte> sourceImage)
        {
            var anchor = new Point(-1, -1);
            var borderValue = new MCvScalar(1);
            var kernel = CvInvoke.GetStructuringElement(ElementShape.Ellipse, new Size(3, 3), anchor);
            var closing = mask.MorphologyEx(MorphOp.Close, kernel, anchor, 1, BorderType.Default, borderValue);
            var opening = closing.MorphologyEx(MorphOp.Open, kernel, anchor, 1, BorderType.Default, borderValue);
            var dilation = opening.Dilate(7);
            var threshold = dilation.ThresholdBinary(new Gray(250), new Gray(255));

            var copy = sourceImage.Copy();
            var contours = new VectorOfVectorOfPoint();
            CvInvoke.FindContours(threshold, contours, null, RetrType.External, ChainApproxMethod.ChainApproxTc89L1);
            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i]) > 600)
                {
                    Rectangle boundingRect = CvInvoke.BoundingRectangle(contours[i]);
                    copy.Draw(boundingRect, new Bgr(Color.Green), 2);
                }
            }

            return copy;
        }
        public Image<Gray, byte> editNegative(Image<Bgr, byte> sourceImage, Image<Gray, byte> background)
        {
            Image<Gray, byte> diff = background.AbsDiff(sourceImage.Convert<Gray, byte>());
            diff.Erode(4);
            diff.Dilate(6);
            Image<Gray, byte> binarizedImage = diff.ThresholdBinary(new Gray(120), new Gray(255));
         



            return binarizedImage;
        }
    }
}
