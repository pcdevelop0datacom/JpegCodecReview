using System;
using System.Collections.Generic;
using TurboJpegWrapper;
using System.IO;
using System.Drawing;

namespace JpegCodecReview
{
    class Libjpegturbo : cCodec
    {
        public override double DecodeInBgr(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by libJPEG Turbo to BMP..");

            double avgtime = 0;
            double delta;
            int i = 0;

            var decompressor = new TJDecompressor();

            foreach (byte[] bitmap in JList)
            {
                MemoryStream stream = new MemoryStream();

                byte[] output = new byte[] { };
                int width, height, stride;
                
                DateTime start = DateTime.Now;
                output = decompressor.Decompress(output, TJPixelFormats.TJPF_RGB, TJFlags.NONE, out width, out height, out stride);
                DateTime finish = DateTime.Now;

                delta = (finish - start).TotalMilliseconds;
                avgtime += delta;

                try
                {
                    using (FileStream file = new FileStream("output\\libjpeg-turbo" + i.ToString() + ".bmp", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        file.Write(output, 0, output.Length);
                    }
                    if (debugInfoIsOn)
                        Console.WriteLine("Done converting image {0}. Size: {1} x {2}. Time: {3} ms", i, width, height, delta);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error while converint: {0}", exc);
                }

                i++;
            }

            Console.WriteLine("..done.");
            return avgtime;
        }

        public override double DecodeInRgb(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by libJPEG Turbo to BMP..");

            double avgtime = 0;
            double delta;
            int i = 0;

            var decompressor = new TJDecompressor();

            foreach (byte[] bitmap in JList)
            {
                MemoryStream stream = new MemoryStream();

                int width, height, step;
                byte[] output = new byte[] { };

                DateTime start = DateTime.Now;
                output = decompressor.Decompress(output, TJPixelFormats.TJPF_RGB, TJFlags.FASTUPSAMPLE, out width, out height, out step);
                DateTime finish = DateTime.Now;
                delta = (finish - start).TotalMilliseconds;
                avgtime += delta;
                try
                {
                    using (FileStream file = new FileStream("output\\libjpeg-turbo" + i.ToString() + ".bmp", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        file.Write(output, 0, output.Length);
                    }
                    if (debugInfoIsOn)
                        Console.WriteLine("Done converting image {0}. Size: {1} x {2}. Time: {3} ms", i, width, height, delta);
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Error while converting: {0}", exc);
                }
                i++;
            }
            Console.WriteLine("..done.");
            return avgtime;
        }

        public override double Encode(List<byte[]> JList, object CompressionQuality, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by libJPEG Turbo to JPG");

            double avgtime = 0;
            double delta;
            int i = 0;

            var compressor = new TJCompressor();

            foreach (byte[] bitmap in JList)
            {
                MemoryStream stream = new MemoryStream();

                Image img = Image.FromStream(new MemoryStream(bitmap));
                var sourceImage = (Bitmap)img;
                var width = img.Width;
                var height = img.Height;
                byte[] output;
                DateTime start = DateTime.Now;

                output = compressor.Compress(sourceImage, TJSubsamplingOptions.TJSAMP_420, Convert.ToInt32(CompressionQuality), TJFlags.FASTUPSAMPLE);
                DateTime finish = DateTime.Now;
                delta = (finish - start).TotalMilliseconds;
                avgtime += delta;

                using (FileStream file = new FileStream("output\\libJPEGTurbo" + i.ToString() + ".jpg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    file.Write(output, 0, output.Length);
                }
                if (debugInfoIsOn)
                    Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2} ms", i, img.Size, delta);

                i++;
            }
            Console.WriteLine("..done.");
            return avgtime;
        }

    }
}
