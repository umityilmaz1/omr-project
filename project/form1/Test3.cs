//using Emgu.CV.CvEnum;
//using Emgu.CV;
//using Emgu.CV.Structure;

//namespace form1
//{
//    public class Test3
//    {
//        public static void Execute()
//        {
//            string path = "C:\\Users\\umity_gf8afn4\\OneDrive\\Masaüstü\\omr_test_01.png";
//            int widthImg = 700;
//            int heightImg = 700;

//            Image<Bgr, Byte> image = new Image<Bgr, byte>(widthImg, heightImg);
//            Image<Gray, byte> gray = image.Convert<Gray, byte>();
//            Image<Gray, byte> blurred = gray.SmoothGaussian(5);
//            Image<Gray, byte> edged = blurred.Canny(75, 200);


            

//            Contour<Point>[] contours = edged.FindContours(
//                                   Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE,
//                                   Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

//            Mat? imgCannyCopy = new(); ;
//            imgCanny.CopyTo(imgCannyCopy);

//            Mat? contours = new();
//            Mat? hierarchy = new();

//            CvInvoke.FindContours(imgCannyCopy, contours, hierarchy, mode: RetrType.External, method: ChainApproxMethod.ChainApproxSimple);

//            CvInvoke.Imshow("Original", imgCannyCopy);

//            CvInvoke.WaitKey(0);


//            //ApplicationConfiguration.Initialize();
//            //Application.Run(new Form1());






//        }
//    }
//}
