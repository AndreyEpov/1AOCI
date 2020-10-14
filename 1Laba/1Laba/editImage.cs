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
        public Image<Bgr, byte> editBlur(Image<Bgr, byte> image)
        {
            var blurimg = image;
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
                                blurl.Add(blurimg.Data[ y + j, x + i, channel]);
                            }
                        }
                        blurl.Sort();
                        destImage.Data[y, x, channel] = blurl[4];
                    }
                }
            }
            return destImage;
        }
        public Image<Bgr, byte> editMass(Image<Bgr, byte> image, int[,] mat)
        {
            var blurimg = image;
            var destImage = blurimg.CopyBlank();
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
                                result += blurimg.Data[j + y, i + x, channel] * mat[i + 1, j + 1];
                            }
                        }
                       
                        if (result > 255) result = 255; else if (result < 0) result = 0;
                        destImage.Data[y, x, channel] = Convert.ToByte(result);
                    }
                }
            }
            return destImage;
        }
        public Image<Bgr, byte> editEdge(Image<Gray, byte> sourceImage,double value1, double value2)
        {
            var edges = sourceImage;
            edges = edges.ThresholdAdaptive(new Gray(value1), AdaptiveThresholdType.MeanC, ThresholdType.Binary, 3, new Gray(value2/10));
            Image<Bgr, byte> edgesBgr = edges.Convert<Bgr, byte>();
            return edgesBgr;
        }
        public Image<Gray, byte> editBlurGray(Image<Bgr, byte> image)
        {
            var blurimg = editGray(image);
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

    }
}
