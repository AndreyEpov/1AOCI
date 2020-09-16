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
        public Image<Bgr, byte> thresholdFilter(Image<Bgr, byte> sourceImage, double value1, double value2,int tb1, int tb2, int tb3, int tb4)
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

    }
}
