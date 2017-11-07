using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//to-do: 
//implement realisation of Intel Performance Library
namespace JpegCodecReview
{
    class cIPP : cCodec
    {
        public override double DecodeInBgr(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            throw new NotImplementedException();
        }

        public override double DecodeInRgb(List<byte[]> JList, bool debugInfoIsOn = false)
        {
            throw new NotImplementedException();
        }

        public override double Encode(List<byte[]> JList, object CompressionQuality, bool debugInfoIsOn = false)
        {
            throw new NotImplementedException();
        }
    }

}
