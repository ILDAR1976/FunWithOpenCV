using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System.Drawing;
using SpecialScanner.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DirectShowLib;
using static System.Net.Mime.MediaTypeNames;
using System.Threading.Channels;
using Emgu.CV.Reg;
using System.Runtime.InteropServices;

namespace SpecialScanner.Model {
    public class ScannerToolsRelease : IScannerToolsGeneral, IScannerToolsBarrel, IScannerToolsBoard

    {
        private double CIRCLE_COEF = 1 / (4 * Math.PI);

        public void drawRectangleAroundObjects(Dictionary<string, List<int>> objectsCoordinates, Mat image)
        {
            foreach (var (key, value) in objectsCoordinates)
            {
                string str = key.Split(",")[0].Replace("[", "").Replace("]", "");
                var rect = new Rectangle(value[0], value[1], value[2], value[3]);
                CvInvoke.Rectangle(image, rect, new MCvScalar(0, 0, 255), 2);
                CvInvoke.PutText(image, str, new Point(rect.X, rect.Y - 10), FontFace.HersheySimplex, 0.5, new MCvScalar(0, 0, 255), 2);
            }
        }

        public VectorOfVectorOfPoint findContoursOfObjects(Mat imgGrayscale)
        {
            var contours = findContoursOfObjects(imgGrayscale, 5, 5, 13, 13, 50, 250, RetrType.External);

            return contours;
        }

        public VectorOfVectorOfPoint findContoursOfObjects(Mat imgGrayscale, int BlurSizeX, int BlurSizeY, int ElementSizeX, int ElementSizeY, int CannyX, int CannyY, RetrType retrType)
        {
            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(BlurSizeX, BlurSizeY), 0);

            Mat edges = new Mat();
            CvInvoke.Canny(imgBlurred, edges, CannyX, CannyY);

            show("Test", edges);

            Mat kernel = new Mat();
            kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(ElementSizeX, ElementSizeY), new Point(1, 1));

            //show("Test", kernel);

            Mat closed = new Mat();
            CvInvoke.MorphologyEx(edges, closed, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

            //show("Test", closed);

            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(closed, contours, null, retrType, ChainApproxMethod.ChainApproxSimple);

            return contours;
        }

        public VectorOfVectorOfPoint findContoursOfObjects(Mat imgGrayscale, int triggerValue, int triggerTotalValue, int BlurSizeX, int BlurSizeY, int ElementSizeX, int ElementSizeY, int CannyX, int CannyY, RetrType retrType)
        {
            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgGrayscale, imgBlurred, new Size(BlurSizeX, BlurSizeY), 0);

            Mat edges = new Mat();
            CvInvoke.Canny(imgBlurred, edges, CannyX, CannyY);

            //show("Test", edges);

            Mat kernel = new Mat();
            kernel = CvInvoke.GetStructuringElement(Emgu.CV.CvEnum.ElementShape.Rectangle, new Size(ElementSizeX, ElementSizeY), new Point(1, 1));

            //show("Test", kernel);

            Mat closed = new Mat();
            CvInvoke.MorphologyEx(edges, closed, Emgu.CV.CvEnum.MorphOp.Close, kernel, new Point(-1, -1), 1, Emgu.CV.CvEnum.BorderType.Default, new MCvScalar());

            //show("Test", closed);

            Mat imgThresh = new Mat();

            CvInvoke.Threshold(edges, imgThresh, triggerValue, triggerTotalValue, ThresholdType.Binary);

            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            CvInvoke.FindContours(imgThresh, contours, null, retrType, ChainApproxMethod.ChainApproxSimple);

            return contours;
        }

        public VectorOfVectorOfPoint findContoursOfObjects(Mat in_image, int triggerValue, int triggerTotalValue, RetrType retrType)
        {
            Mat imgThresh = new Mat();
            CvInvoke.Threshold(in_image, imgThresh, triggerValue, triggerTotalValue, ThresholdType.Binary);
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            show("target", imgThresh);

            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgThresh, imgBlurred, new Size(1, 1), 1);

            show("target", imgBlurred);

            Mat hierarchy = new Mat();
            CvInvoke.FindContours(imgBlurred, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            return contours;
        }

        public VectorOfVectorOfPoint findContoursOfObjects(Mat in_image, int triggerValue, int triggerTotalValue)
        {
            Mat imgThresh = new Mat();
            CvInvoke.Threshold(in_image, imgThresh, triggerValue, triggerTotalValue, ThresholdType.Binary);
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();

            Mat imgBlurred = new Mat();
            CvInvoke.GaussianBlur(imgThresh, imgBlurred, new Size(11, 11), 1);

            Mat hierarchy = new Mat();
            CvInvoke.FindContours(imgBlurred, contours, hierarchy, RetrType.List, ChainApproxMethod.ChainApproxSimple);
            return contours;
        }

        public Dictionary<string, List<int>> findCoordinatesOfObjects(VectorOfVectorOfPoint contours, Mat image)
        {
            var objectsCoordinates = new Dictionary<string, List<int>>();
            for (int i = 0; i < contours.Size; i++)
            {
                var rect = CvInvoke.BoundingRectangle(contours[i]);

                if (rect.Width > 20 || rect.Height > 30)
                {

                    if (rect.X - 15 < 0 || rect.Y - 15 < 0)
                    {
                        continue;
                    }

                    var cropRect = new Rectangle(rect.X - 15, rect.Y - 15, rect.Width + 15, rect.Height + 15);
                    Mat imgCrop = new Mat(image.Clone(), cropRect);

                    String objectsName = findFeatures(imgCrop);
                    if (objectsName.Equals(""))
                    {
                        continue;
                    }

                    var coords = new List<int>();
                    coords.Add(rect.X - 15);
                    coords.Add(rect.Y - 15);
                    coords.Add(rect.Width + 15);
                    coords.Add(rect.Height + 15);
                    objectsCoordinates.TryAdd(objectsName, coords);
                    if (objectsCoordinates.ContainsKey(objectsName))
                    {
                        objectsCoordinates[objectsName] = coords;
                    }
                }
            }
            return objectsCoordinates;
        }

        public string findFeatures(Mat img1)
        {
            string directory = Settings.Instance.SamplesFolderPathForBarrels;

            var filePaths = Directory.GetFiles(directory, "*.*");
            Dictionary<string, int> correctMatchesDic = new Dictionary<string, int>();

            foreach (string path in filePaths)
            {
                var img2 = CvInvoke.Imread(path);

                ORB orb = new ORB();

                Mat des1 = new Mat();
                Mat des2 = new Mat();
                VectorOfKeyPoint kp1 = new VectorOfKeyPoint();
                VectorOfKeyPoint kp2 = new VectorOfKeyPoint();

                orb.DetectAndCompute(img1, null, kp1, des1, false);
                orb.DetectAndCompute(img2, null, kp2, des2, false);

                BFMatcher bf = new BFMatcher(DistanceType.L2);
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();
                bf.KnnMatch(des1, des2, matches, 2);
                List<double> correctMatches = new List<double>();
                for (int i = 0; i < matches.Size; i++)
                {
                    VectorOfDMatch vector = matches[i];
                    if (vector[0].Distance < 0.75 * vector[1].Distance)
                    {
                        correctMatches.Add(vector[0].Distance);
                        String strKey = path.Split("\\").Last().Split(".")[0];
                        correctMatchesDic.TryAdd(strKey, correctMatches.Count);
                        if (correctMatchesDic.ContainsKey(strKey))
                        {
                            correctMatchesDic[strKey] = correctMatches.Count;
                        }
                    }
                }
            }
            correctMatchesDic = correctMatchesDic.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            if (correctMatchesDic.Count == 0)
            {
                return String.Empty;
            }
            else
            {
                return correctMatchesDic.ToList()[0].ToString();
            }
        }

        public void WatchContours(Mat in_image, ref int total, bool drawing = false)
        {
            WatchContours(in_image, ref total, 10, 250, drawing);
        }

        public void WatchContours(Mat in_image, ref int total, int CannyX, int CannyY, bool drawing = false)
        {
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(in_image, gray_image, ColorConversion.Bgr2Gray);

            var contours = findContoursOfObjects(gray_image, 3, 3, 7, 7, CannyX, CannyY, RetrType.External);

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];


                Rectangle cropRect = CvInvoke.BoundingRectangle(contour);

                if (cropRect.Width < 0 || cropRect.Height < 0 || cropRect.X < 0 || cropRect.Y < 0)
                {
                    continue;
                }

                var cur_image = new Mat(in_image, cropRect);

                //show("Test", cur_image);


                var arc = CvInvoke.ArcLength(contour, true);
                VectorOfPoint approxContour = new VectorOfPoint();
                CvInvoke.ApproxPolyDP(contour, approxContour, 0.02 * arc, true);
                var perimeter = CvInvoke.ContourArea(approxContour, false);

                if (perimeter > 5000 && perimeter < 97000)
                {
                    total++;
                    if (drawing)
                    {
                        CvInvoke.DrawContours(in_image, contours, i, new MCvScalar(0, 0, 255), 2);
                    }

                }
                else
                {
                    continue;
                }
            }
        }

        public void WatchLowContours(Mat in_image, ref int total, bool drawing = false)
        {
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(in_image, gray_image, ColorConversion.Bgr2Gray);

            Mat imgThresh = new Mat();
            CvInvoke.Threshold(gray_image, imgThresh, 215, 255, ThresholdType.Binary);

            var contours = findContoursOfObjects(imgThresh, 215, 255);

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];

                Rectangle cropRect = CvInvoke.BoundingRectangle(contour);

                if (cropRect.Width < 0 || cropRect.Height < 0 || cropRect.X < 0 || cropRect.Y < 0)
                {
                    continue;
                }
                var cur_image = new Mat(imgThresh, cropRect);
                //show("", cur_image);
                var perimeter = CvInvoke.ArcLength(contour, true);
                var area = CvInvoke.ContourArea(contour, false);
                var basicRelation = area / (perimeter * perimeter);

                if (basicRelation > 0.065 && basicRelation < 0.087 && area < 3000)
                {
                    //show("", cur_image);
                    total++;
                    if (drawing)
                    {

                        int tot = 0;

                        for (int row = 0; row < cur_image.Height; row++)
                        {
                            for (int col = 0; col < cur_image.Width; col++)
                            {
                                var value = cur_image.GetValue(row, col);
                                tot += value;
                                if (value > 0)
                                {
                                    tot++;
                                }
                            }
                        }
                        if (tot > 40)
                        {
                            CvInvoke.DrawContours(in_image, contours, i, new MCvScalar(0, 0, 255), 5);
                        }


                    }
                }
                else
                {
                    continue;
                }
            }
        }

        public (Mat, String) BarrelsScanner()
        {

            string infoMessage = String.Empty;
            string outMessage = String.Empty;
            var main_image = CvInvoke.Imread(Settings.Instance.SourceFolderPathForBarrels);
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);
            var contours = findContoursOfObjects(gray_image);
            var objectLocation = findCoordinatesOfObjects(contours, main_image);

            int total = 0;

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];
                Rectangle cropRect = CvInvoke.BoundingRectangle(contour);

                if (cropRect.Width < 0 || cropRect.Height < 0 || cropRect.X < 0 || cropRect.Y < 0)
                {
                    continue;
                }

                var cur_image = new Mat(main_image, cropRect);
                //CvInvoke.DrawContours(main_image, contours, i, new MCvScalar(0, 0, 255), 5);
                //show("Test", main_image);

                var perimeter = CvInvoke.ArcLength(contour, true);
                var area = CvInvoke.ContourArea(contour, false);

                var basicRelation = area / (perimeter * perimeter);


                if (basicRelation > 0.04 && basicRelation < 0.087 && area > 10000)
                {
                    //show("Test", cur_image);

                    int totalNext = 0;
                    WatchLowContours(cur_image, ref totalNext, true);

                    infoMessage += ", " + totalNext.ToString();

                    string message = String.Empty;

                    if (totalNext < 2)
                    {
                        message = "Бочка открыта";
                    }
                    else
                    {
                        message = "Бочка закрыта";
                    }


                    CvInvoke.PutText(main_image, message, new Point(cropRect.X, cropRect.Y - 15), FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 3, LineType.AntiAlias);
                    CvInvoke.Rectangle(main_image, cropRect, new MCvScalar(0, 255, 0), 2);

                    total++;
                }
            }

            outMessage = total.ToString() + " " + infoMessage;
            return (main_image, outMessage);
        }

        public (Mat, String) BarrelsScannerOnVideo(Mat main_image)
        {

            string infoMessage = String.Empty;
            string outMessage = String.Empty;

            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);
            var contours = findContoursOfObjects(gray_image);
            var objectLocation = findCoordinatesOfObjects(contours, main_image);

            int total = 0;

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];
                Rectangle cropRect = CvInvoke.BoundingRectangle(contour);

                if (cropRect.Width < 0 || cropRect.Height < 0 || cropRect.X < 0 || cropRect.Y < 0)
                {
                    continue;
                }

                var cur_image = new Mat(main_image, cropRect);
                //CvInvoke.DrawContours(main_image, contours, i, new MCvScalar(0, 0, 255), 5);
                //show("Test", main_image);

                var perimeter = CvInvoke.ArcLength(contour, true);
                var area = CvInvoke.ContourArea(contour, false);

                var basicRelation = area / (perimeter * perimeter);


                if (basicRelation > 0.04 && basicRelation < 0.087 && area > 10000)
                {
                    //show("Test", cur_image);

                    int totalNext = 0;
                    WatchLowContours(cur_image, ref totalNext, true);

                    infoMessage += ", " + totalNext.ToString();

                    string message = String.Empty;

                    if (totalNext < 2)
                    {
                        message = "Бочка открыта";
                    }
                    else
                    {
                        message = "Бочка закрыта";
                    }


                    CvInvoke.PutText(main_image, message, new Point(cropRect.X, cropRect.Y - 15), FontFace.HersheyComplex, 1, new MCvScalar(0, 0, 255), 3, LineType.AntiAlias);
                    CvInvoke.Rectangle(main_image, cropRect, new MCvScalar(0, 255, 0), 2);

                    total++;
                }
            }

            outMessage = total.ToString() + " " + infoMessage;
            return (main_image, outMessage);
        }

        public void show(String message, Mat img)
        {
            CvInvoke.Imshow(message, img);
            CvInvoke.WaitKey(0);
        }

        public (Mat, string) BoardScanner()
        {
            string infoMessage = String.Empty;
            string outMessage = String.Empty;
            var main_image = CvInvoke.Imread(Settings.Instance.SourceFolderPathForBoards);
            Mat gray_image = new Mat();
            CvInvoke.CvtColor(main_image, gray_image, ColorConversion.Bgr2Gray);
            var contours = findContoursOfObjects(gray_image, 1, 1, 3, 3, 10, 150, RetrType.External);
            
            //var contours = findContoursOfObjects(gray_image, 1, 270, RetrType.List);
            
            var objectLocation = findCoordinatesOfObjects(contours, main_image);
            //show("Gray", gray_image);
            int total = 0;

            for (int i = 0; i < contours.Size; i++)
            {
                var contour = contours[i];
                Rectangle cropRect = CvInvoke.BoundingRectangle(contour);
                
                if (cropRect.Width < 0 || cropRect.Height < 0 || cropRect.X < 0 || cropRect.Y < 0)
                {
                    continue;
                }
                total++;
                var cur_image = new Mat(main_image, cropRect);
                CvInvoke.DrawContours(cur_image, contours, i, new MCvScalar(0, 0, 255), 1);
            }

            outMessage = total.ToString() + " " + infoMessage;
            return (main_image, outMessage);
        }
    }

    public static class MatExtension
    {
        public static dynamic GetValue(this Mat mat, int row, int col)
        {
            var value = CreateElement(mat.Depth);
            Marshal.Copy(mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, value, 0, 1);
            return value[0];
        }

        public static void SetValue(this Mat mat, int row, int col, dynamic value)
        {
            var target = CreateElement(mat.Depth, value);
            Marshal.Copy(target, 0, mat.DataPointer + (row * mat.Cols + col) * mat.ElementSize, 1);
        }
        private static dynamic CreateElement(DepthType depthType, dynamic value)
        {
            var element = CreateElement(depthType);
            element[0] = value;
            return element;
        }

        private static dynamic CreateElement(DepthType depthType)
        {
            if (depthType == DepthType.Cv8S)
            {
                return new sbyte[1];
            }
            if (depthType == DepthType.Cv8U)
            {
                return new byte[1];
            }
            if (depthType == DepthType.Cv16S)
            {
                return new short[1];
            }
            if (depthType == DepthType.Cv16U)
            {
                return new ushort[1];
            }
            if (depthType == DepthType.Cv32S)
            {
                return new int[1];
            }
            if (depthType == DepthType.Cv32F)
            {
                return new float[1];
            }
            if (depthType == DepthType.Cv64F)
            {
                return new double[1];
            }
            return new float[1];
        }
    }
}
