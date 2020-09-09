using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Laba
{
   public class SourceImage
    {
        private Image<Bgr, byte> sourceImage;
        public SourceImage(string fileName)
        {
            sourceImage = new Image<Bgr, byte>(fileName);
            sourceImage = sourceImage.Resize(480, 640, Inter.Linear);
        }
    }
}
