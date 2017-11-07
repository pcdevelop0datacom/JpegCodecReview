using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.IO;
using System.Drawing;

namespace JpegCodecReview
{
    class cOpenCV : cCodec
    {
        public override double DecodeInBgr(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by OpenCV to BMP..");

            double avgtime = 0;
            double delta;
            int i = 0;

            foreach (byte[] imgByte in JList)
            {
                Emgu.CV.Util.VectorOfByte output = new Emgu.CV.Util.VectorOfByte();

                Mat convertedImg = new Mat();

                DateTime start = DateTime.Now;

                //CvInvoke.Imencode(".bmp", imgToConvert, output);
                CvInvoke.Imdecode(imgByte, LoadImageType.Unchanged, convertedImg);

                DateTime finish = DateTime.Now;

                delta = (finish - start).TotalMilliseconds;
                try
                {
                    using (FileStream file = new FileStream("output\\OpenCV" + i.ToString() + ".bmp", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        file.Write(output.ToArray(), 0, output.ToArray().Length);

                        avgtime += delta;

                        if (debugInfoIsOn)
                            Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2}", i, "---", delta);
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    return 0;
                }

                i++;
            }

            Console.WriteLine("..done.");

            return avgtime;
        }

        public override double DecodeInRgb(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by OpenCV to BMP..");

            double avgtime = 0;
            double delta;
            int i = 0;

            foreach (byte[] imgByte in JList)
            {
                Emgu.CV.Util.VectorOfByte output = new Emgu.CV.Util.VectorOfByte();

                Mat convertedImg = new Mat();

                DateTime start = DateTime.Now;

                //CvInvoke.Imencode(".bmp", imgToConvert, output);
                CvInvoke.Imdecode(imgByte, LoadImageType.Unchanged, convertedImg);

                DateTime finish = DateTime.Now;

                delta = (finish - start).TotalMilliseconds;
                try
                {
                    using (FileStream file = new FileStream("output\\OpenCV" + i.ToString() + ".bmp", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        file.Write(output.ToArray(), 0, output.ToArray().Length);

                        avgtime += delta;

                        if (debugInfoIsOn)
                            Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2}", i, "---", delta);
                    }
                }
                catch (Exception exc)
                {
                    Console.WriteLine(exc);
                    return 0;
                }

                i++;
            }

            Console.WriteLine("..done.");

            return avgtime;
        }

        public override double Encode(List<byte[]> JList, object CompressionQuality, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by OpenCV to JPG..");

            double avgtime = 0;
            double delta;
            int i = 0;

            foreach (byte[] imgByte in JList)
            {
                Emgu.CV.Util.VectorOfByte output = new Emgu.CV.Util.VectorOfByte();

                Mat imgToConvert = new Image<Bgr, byte>(new Bitmap(new MemoryStream(imgByte))).Mat;

                DateTime start = DateTime.Now;

                CvInvoke.Imencode(".jpg", imgToConvert, output, new int[] { Convert.ToInt32(CompressionQuality) });

                DateTime finish = DateTime.Now;

                delta = (finish - start).TotalMilliseconds;

                using (FileStream file = new FileStream("output\\OpenCV" + i.ToString() + ".jpeg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    file.Write(output.ToArray(), 0, output.ToArray().Length);
                }

                avgtime += delta;

                if (debugInfoIsOn)
                    Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2}", i, "---", delta);

                i++;
            }

            Console.WriteLine("..done.");
            return avgtime;
        }

    }
}
