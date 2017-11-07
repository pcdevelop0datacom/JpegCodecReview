using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;

namespace JpegCodecReview
{
    class Program
    {
        //This method gets the bytedata from pictures.
        static private void GetBytesFromFiles(List<byte[]> list, DirectoryInfo dir, string format)
        {
            foreach (FileInfo file in dir.EnumerateFiles(format))
            {
                byte[] arr;

                try
                {
                    Image img = Image.FromFile(file.FullName, false);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        img.Save(ms, img.RawFormat);
                        arr = ms.ToArray();
                    }
                    list.Add(arr);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error while trying load image files: {0}", exc);
                }
            }
        }

        //This method encodes bmp files in \bin\x64\Debug\dataset to jpeg and puts them in \bin\x64\Debug\output.
        static private void Encode()
        {
            cOpenCV OpenCVcodec = new cOpenCV();
            cDotNet DotNetcodec = new cDotNet();
            Libjpegturbo libJPEGTurbocodec = new Libjpegturbo();

            //Path to bmp dataset (in folder).
            //Put any .bmp files to this folder for testing (the more - the better).
            string bmpDataset = "dataset\\bmp";

            //array for raw datasets converted to bytes
            List<byte[]> JList = new List<byte[]>();
            GetBytesFromFiles(JList, new DirectoryInfo(bmpDataset), "*");

            //count time for different codecs
            var allTimeOpenCV = 0D;
            var allTimeDotNet = 0D;
            var allTimelibJPEGTurbo = 0D;

            //Quality for output JPEG file (from 10 to 100%). By default 95.
            var compressionQuality = 95;

            Console.WriteLine("BMP to JPEG converting. {0}% quality.", compressionQuality);

            //i - number of test runs. By default - 10: i(1) * j(10). 
            //Recommended is 100.
            for (int i = 0; i < 1; i++)
            {
                var circleTimeOpenCV = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = OpenCVcodec.Encode(JList, compressionQuality);
                    //uncomment next line for additional debug info (unnecessary)
                    //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                    circleTimeOpenCV += time;
                }
                Console.WriteLine("Total time of 10 tries for OpenCV: {0}", circleTimeOpenCV);
                allTimeOpenCV += circleTimeOpenCV / 10;
                Console.WriteLine("Average time of 1 try for OpenCV: {0}", circleTimeOpenCV / 10);

                var circleTimeDotNet = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = DotNetcodec.Encode(JList, compressionQuality);
                    //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                    circleTimeDotNet += time;
                }
                Console.WriteLine("Total time of 10 tries for DotNET: {0}", circleTimeDotNet);
                allTimeDotNet += circleTimeDotNet / 10;
                Console.WriteLine("Average time of 1 try for DotNET: {0}", circleTimeDotNet / 10);

                var circleTimeLibJPEGTurbo = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = libJPEGTurbocodec.Encode(JList, compressionQuality);
                    //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                    circleTimeLibJPEGTurbo += time;
                }
                Console.WriteLine("Total time of 10 tries for DotNET: {0}", circleTimeLibJPEGTurbo);
                allTimelibJPEGTurbo += circleTimeLibJPEGTurbo / 10;
                Console.WriteLine("Average time of 1 try for DotNET: {0}", circleTimeLibJPEGTurbo / 10);
            }

            Console.WriteLine();
            Console.WriteLine("Average time of 10 tries for OpenCV: {0}", allTimeOpenCV / 10);
            Console.WriteLine("Average time of 10 tries for .NET: {0}", allTimeDotNet / 10);
            Console.WriteLine("Average time of 10 tries for libJPEGTurbo: {0}", allTimelibJPEGTurbo / 10);

            Console.WriteLine("\nEncoding is done. Press any button to continue..");
            Console.Read();
        }

        //This method decodes jpeg files in \bin\x64\Debug\dataset to bmp and puts them in \bin\x64\Debug\output.
        //to-do:
        //Add support for Bgr and Rgb file formats. 
        //Right now only Bgr is supported.
        static private void Decode(string format)
        {
            //Path to jpg dataset (in folder).
            //Put any .jpg files to this folder for testing (the more - the better).
            string jpegDataset = "dataset\\jpeg";

            cOpenCV OpenCVcodec = new cOpenCV();
            cDotNet DotNetcodec = new cDotNet();
            Libjpegturbo libjpegurbocodec = new Libjpegturbo();

            //array for raw datasets converted to bytes
            List<byte[]> BList = new List<byte[]>();
            GetBytesFromFiles(BList, new DirectoryInfo(jpegDataset), "*");

            Console.WriteLine("BMP to JPEG converting.");

            //count time for different codecs
            var allTimeOpenCV = 0D;
            var allTimeDotNet = 0D;
            var allTimelibJPEGTurbo = 0D;

            //i - number of test runs. By default - 10: i(1) * j(10). 
            //Recommended is 100.
            var counter = 0;
            for (int i = 0; i < 1; i++)
            {
                var circleTimeOpenCV = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = OpenCVcodec.DecodeInBgr(BList, false);
                    if (time != 0)
                    {
                        //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                        circleTimeOpenCV += time;
                        counter++;
                    }
                }
                Console.WriteLine("Total time of {0} tries for OpenCV: {1}", counter, circleTimeOpenCV);
                allTimeOpenCV += circleTimeOpenCV / counter;
                Console.WriteLine("Average time of 1 try for OpenCV: {0}", circleTimeOpenCV / 10);
            }

            counter = 0;
            for (int i = 0; i < 1; i++)
            {
                var circleTimeDotNet = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = DotNetcodec.DecodeInBgr(BList, false);
                    if (time != 0)
                    {
                        //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                        circleTimeDotNet += time;
                        counter++;
                    }
                }
                Console.WriteLine("Total time of {0} tries for OpenCV: {1}", counter, circleTimeDotNet);
                allTimeDotNet += circleTimeDotNet / counter;
                Console.WriteLine("Average time of 1 try for OpenCV: {0}", circleTimeDotNet / 10);
            }

            counter = 0;
            for (int i = 0; i < 1; i++)
            {
                var circleTimeLibJPEGTurbo = 0D;
                for (int j = 0; j < 10; j++)
                {
                    var time = libjpegurbocodec.DecodeInBgr(BList, false);
                    if (time != 0)
                    {
                        //Console.WriteLine("Total time of converting {0} images: {1}", JList.Count, time);
                        circleTimeLibJPEGTurbo += time;
                        counter++;
                    }
                }
                Console.WriteLine("Total time of {0} tries for OpenCV: {1}", counter, circleTimeLibJPEGTurbo);
                allTimelibJPEGTurbo += circleTimeLibJPEGTurbo / counter;
                Console.WriteLine("Average time of 1 try for OpenCV: {0}", circleTimeLibJPEGTurbo / 10);
            }

            Console.WriteLine();
            Console.WriteLine("Average time of 10 tries for OpenCV: {0}", allTimeOpenCV / 10);
            Console.WriteLine("Average time of 10 tries for .NET: {0}", allTimeDotNet / 10);
            Console.WriteLine("Average time of 10 tries for libJPEGTurbo: {0}", allTimelibJPEGTurbo / 10);

            Console.WriteLine("\nDecoding is done. Press any button to continue..");

            Console.Read();
        }
        
        static void Main(string[] args)
        {
            //Encode();
            Decode("Bgr"); // or "Rgb"
            Console.WriteLine("End of program.");
            Console.WriteLine("Press any button to exit..");
            Console.Read();
        }

    }
}
