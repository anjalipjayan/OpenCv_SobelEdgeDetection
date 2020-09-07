using System;
using System.Collections.Generic;
using OpenCvSharp;

namespace SobelEdgeDetection
{
  class Program
  {
    static void Main(string[] args)
    {
       SobelEdges();
    }
    static void SobelEdges()
    {
      string image = "..\\image.png";
      Mat image = Cv2.ImRead(image);
      Mat gray = image.CvtColor(ColorConversionCodes.BGR2GRAY);
      gray.SaveImage("..\\grey.png");

      Mat canny = gray.Canny(50,150);
      canny.SaveImage("..\\canny.png");

      Mat thresh = gray.Threshold(0, 255, ThresholdTypes.Otsu);         
      
      //sobel vertical lines 
      Mat sobelVertical = canny.Sobel(MatType.CV_8U, 1, 0);
      //sobel horizontal lines
      Mat sobelHorizontal = canny.Sobel(MatType.CV_8U, 0, 1);
      using (new Window("SobelVertical", WindowMode.AutoSize, sobelVertical))
      {
          Window.WaitKey(0);
      }
      using (new Window("SobelHorizontal", WindowMode.AutoSize, sobelHorizontal))
      {
         Window.WaitKey(0);
      }
    }
  }
}

