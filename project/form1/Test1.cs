using Emgu.CV.CvEnum;
using Emgu.CV;

namespace form1
{
    public class Test1
    {
        public static void Execute()
        {
            string path = "C:\\Users\\umity_gf8afn4\\OneDrive\\Masaüstü\\omr_test_01.png";
            int widthImg = 700;
            int heightImg = 700;

            var img = CvInvoke.Imread(path);
            CvInvoke.Resize(img, img, new Size(widthImg, heightImg));
            //var imgContours = img.Clone();

            Mat? imgGray = new();
            CvInvoke.CvtColor(img, imgGray, ColorConversion.Bgr2Gray);

            Mat? imgBlur = new();
            CvInvoke.GaussianBlur(imgGray, imgBlur, new Size(5, 5), 0); //önceki değer 1

            Mat? imgCanny = new();
            CvInvoke.Canny(imgBlur, imgCanny, 75, 200); //10 50 yapıldığında daha fazla piksel beliriyor

            //dynamic contours = new VectorOfVectorOfPoint();
            //dynamic hierarchy = new Mat();
            //CvInvoke.FindContours(imgCanny, contours, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxNone);
            //CvInvoke.DrawContours(imgContours, contours, -1, new MCvScalar(255, 0, 0), 10);


            //Image<Bgr, byte> img = new Image<Bgr, byte>(filename);
            CvInvoke.Imshow("Original", imgCanny);

            CvInvoke.WaitKey(0);

            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());





            //            gray = cv2.cvtColor(image, cv2.COLOR_BGR2GRAY)
            //blurred = cv2.GaussianBlur(gray, (5, 5), 0)
            //edged = cv2.Canny(blurred, 75, 200)
        }
    }
}
