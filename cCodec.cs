using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JpegCodecReview
{
    abstract class cCodec
    {
        abstract public double Encode(List<byte[]> JList, object CompressionQuality, bool debugInfoIsOn = false);

        abstract public double DecodeInBgr(List<byte[]> JList, bool debugInfoIsOn = false);

        abstract public double DecodeInRgb(List<byte[]> JList, bool debugInfoIsOn = false);
    }
}
