using Emgu.CV.CvEnum;
using Emgu.CV;

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

            Mat? contours = new();
            Mat? hierarchy = new();
            CvInvoke.FindContours(imgCannyCopy, contours, hierarchy, mode: RetrType.External, method: ChainApproxMethod.ChainApproxSimple);


            CvInvoke.Imshow("Original", imgCannyCopy);

            CvInvoke.WaitKey(0);


            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());






        }
    }
}
