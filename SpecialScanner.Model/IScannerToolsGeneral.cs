using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecialScanner.Model
{
    public interface IScannerToolsGeneral
    {
        void WatchContours(Mat in_image, ref int total, bool drawing = false);
        Emgu.CV.Util.VectorOfVectorOfPoint findContoursOfObjects(Mat imgGrayscale);
        Dictionary<string, List<int>> findCoordinatesOfObjects(Emgu.CV.Util.VectorOfVectorOfPoint contours, Mat image);
        String findFeatures(Mat img1);
        void drawRectangleAroundObjects(Dictionary<string, List<int>> objectsCoordinates, Mat image);
        void show(string message, Mat img);
    }
}

