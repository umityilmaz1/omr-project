using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System;

namespace form1
{
    public class Test2
    {
        public static void Execute()
        {
            string path = "C:\\Users\\umity_gf8afn4\\OneDrive\\Masaüstü\\omr_test_01.png";
            int widthImg = 700;
            int heightImg = 700;

            var img = CvInvoke.Imread(path);
            CvInvoke.Resize(img, img, new Size(widthImg, heightImg));

            Mat? imgGray = new();
            CvInvoke.CvtColor(img, imgGray, ColorConversion.Bgr2Gray);

            Mat? imgBlur = new();
            CvInvoke.GaussianBlur(imgGray, imgBlur, new Size(5, 5), 0);

            Mat? imgCanny = new();
            CvInvoke.Canny(imgBlur, imgCanny, 75, 200);

            Mat? imgCannyCopy = new(); ;
            imgCanny.CopyTo(imgCannyCopy);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat hierarchy = new Mat();

            CvInvoke.FindContours(imgCannyCopy, contours, hierarchy, mode: RetrType.External, method: ChainApproxMethod.ChainApproxSimple);
            //CvInvoke.DrawContours(img, contours, 0, new MCvScalar(255, 0, 0), 2);

            VectorOfPoint docCnt = null;

            if (contours.Length > 0)
            {
                for (int i = 0; i < contours.Length; i++)
                {
                    var peri = CvInvoke.ArcLength(contours[i], true);
                    VectorOfPoint approx = new VectorOfPoint();
                    CvInvoke.ApproxPolyDP(contours[i], approx, 0.02 * peri, true);

                    if (approx.Length == 4)
                    {
                        docCnt = approx;
                        break;
                    }
                }
            }

            //PERSPECTIVE TRANSFORM
            // Dönüştürülecek köşeleri seçin
            Point[] srcPoints = docCnt.ToArray();

            // Hedef köşeleri tanımlayın (örneğin, dikdörtgen bir görüntü için)
            Point[] dstPoints = new Point[] {
                                            new Point(0, 0),
                                            new Point(widthImg, 0),
                                            new Point(widthImg, heightImg),
                                            new Point(0, heightImg)
};

            VectorOfPoint srcPointsVec = new VectorOfPoint(srcPoints);
            Mat srcPointsMat = srcPointsVec.GetInputArray().GetMat();

            VectorOfPoint dstPointsVec = new VectorOfPoint(dstPoints);
            Mat dstPointsMat = dstPointsVec.GetInputArray().GetMat();

            // Dönüşüm matrisini hesaplayın
            Mat perspectiveTransform = CvInvoke.GetPerspectiveTransform(srcPointsMat, dstPointsMat);

            Image<Bgr, Byte> image = img.ToImage<Bgr, Byte>();
            Image<Bgr, Byte> paper = image.WarpAffine(
    perspectiveTransform,
    image.Width, img.Height,
            Inter.Cubic,
    Warp.FillOutliers,
    Emgu.CV.CvEnum.BorderType.Constant,
    new Bgr(0, 0, 0));

            Image<Bgr, Byte> imageGray = img.ToImage<Bgr, Byte>();
            Image<Bgr, Byte> warped = image.WarpAffine(
    perspectiveTransform,
    image.Width, img.Height,
            Inter.Cubic,
    Warp.FillOutliers,
    Emgu.CV.CvEnum.BorderType.Constant,
    new Bgr(0, 0, 0));

            Mat thresh = new();
            CvInvoke.Threshold(warped, thresh, 0, 255, ThresholdType.Binary | ThresholdType.Otsu);

            CvInvoke.Imshow("Original", img);

            CvInvoke.WaitKey(0);


            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());






        }
    }
}
