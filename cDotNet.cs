using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace JpegCodecReview
{
    class cDotNet : cCodec
    {
        public override double Encode(List<byte[]> JList, object CompressionQuality, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by .NET to JPG..");

            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            // Create an Encoder object based on the GUID for the Quality parameter category.

            // Create an EncoderParameters object.
            // An EncoderParameters object has an array of EncoderParameter
            // objects. In this case, there is only one EncoderParameter object in the array.
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, Convert.ToInt64(CompressionQuality));

            // Later the bitmap will be saved as a JPG file with specified quality level compression.

            double avgtime = 0;
            double delta;
            int i = 0;

            foreach (byte[] imgByte in JList)
            {
                MemoryStream stream = new MemoryStream();

                Image img = Image.FromStream(new MemoryStream(imgByte));
                DateTime start = DateTime.Now;

                img.Save(stream, jpgEncoder, myEncoderParameters);

                DateTime finish = DateTime.Now;
                delta = (finish - start).TotalMilliseconds;
                avgtime += delta;

                using (FileStream file = new FileStream("output\\dotNET" + i.ToString() + ".jpg", FileMode.Create, System.IO.FileAccess.Write))
                {
                    byte[] bytes = new byte[stream.Length];
                    stream.ToArray().CopyTo(bytes, 0);
                    file.Write(bytes, 0, bytes.Length);
                }
                if (debugInfoIsOn)
                    Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2} ms", i, img.Size, delta);

                i++;
            }
            Console.WriteLine("..done.");
            return avgtime;
        }

        public override double DecodeInBgr(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            Console.WriteLine();
            Console.WriteLine("Converting by .NET to BMP..");

            double avgtime = 0;
            double delta;
            int i = 0;

            EncoderParameter myEncoderParameter;
            System.Drawing.Imaging.Encoder bmpEncoder;
            ImageCodecInfo encoder = GetEncoder(ImageFormat.Bmp);
            bmpEncoder = System.Drawing.Imaging.Encoder.Transformation;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(bmpEncoder, (long)EncoderValue.ColorTypeCMYK);
            myEncoderParameters.Param[0] = myEncoderParameter;

            foreach (byte[] imgByte in JList)
            {
                MemoryStream stream = new MemoryStream();

                Image img = Image.FromStream(new MemoryStream(imgByte));

                DateTime start = DateTime.Now;
                img.Save(stream, ImageFormat.Bmp);
                DateTime finish = DateTime.Now;

                delta = (finish - start).TotalMilliseconds;
                avgtime += delta;

                try
                {
                    using (FileStream file = new FileStream("output\\dotNET" + i.ToString() + ".bmp", FileMode.Create, System.IO.FileAccess.Write))
                    {
                        byte[] bytes = new byte[stream.Length];
                        stream.ToArray().CopyTo(bytes, 0);
                        file.Write(bytes, 0, bytes.Length);
                    }
                    if (debugInfoIsOn)
                        Console.WriteLine("Done converting image {0}. Size: {1}. Time: {2} ms", i, img.Size, delta);
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
            throw new NotImplementedException("No realisation of this method.");
        }

        static private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
    }
}
