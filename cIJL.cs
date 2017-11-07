using System;
using System.Runtime.InteropServices;

#region enums
public enum TIJL_COLOR
{

    IJL_PAD1, // = 0   // Stub for Delphi, enum type start with 0
    IJL_RGB, // = 1   // Red-Green-Blue color space.
    IJL_BGR, // = 2   // Reversed channel ordering from IJL_RGB.
    IJL_YCBCR, // = 3   // Luminance-Chrominance color space as defined
    // by CCIR Recommendation 601.
    IJL_G, // = 4   // Grayscale color space.
    IJL_RGBA_FPX, // = 5   // FlashPix RGB 4 channel color space that
    // has pre-multiplied opacity.
    IJL_YCBCRA_FPX, // = 6   // FlashPix YCbCr 4 channel color space that
    // has pre-multiplied opacity.
    IJL_OTHER = 255      // Some other color space not defined by the IJL.
    // (This means no color space conversion will
    // be done by the IJL.)
}

public enum TIJL_SUBSAMPLING
{
    IJL_PAD2,    // Stub for Delphi, enum type start with 0
    IJL_411, // = 1,    // Valid on a JPEG w/ 3 channels.
    IJL_422, // = 2,    // Valid on a JPEG w/ 3 channels.
    IJL_4114, // = 3,    // Valid on a JPEG w/ 4 channels.
    IJL_4224 // = 4     // Valid on a JPEG w/ 4 channels.
}

public enum TIJLIOType
{
    // Read JPEG parameters (i.e., height, width, channels, sampling, etc.)
    // from a JPEG bit stream.
    IJL_JFILE_READPARAMS, // =  0
    IJL_JBUFF_READPARAMS, // =  1

    // Read a JPEG Interchange Format image.
    IJL_JFILE_READWHOLEIMAGE, // =  2
    IJL_JBUFF_READWHOLEIMAGE, // =  3

    // Read JPEG tables from a JPEG Abbreviated Format bit stream.
    IJL_JFILE_READHEADER, // =  4,
    IJL_JBUFF_READHEADER, // =  5,

    // Read image info from a JPEG Abbreviated Format bit stream.
    IJL_JFILE_READENTROPY, // =  6
    IJL_JBUFF_READENTROPY, // =  7

    // Write an entire JFIF bit stream.
    IJL_JFILE_WRITEWHOLEIMAGE, // =  8
    IJL_JBUFF_WRITEWHOLEIMAGE, // =  9

    // Write a JPEG Abbreviated Format bit stream.
    IJL_JFILE_WRITEHEADER, // = 10
    IJL_JBUFF_WRITEHEADER, // = 11

    // Write image info to a JPEG Abbreviated Format bit stream.
    IJL_JFILE_WRITEENTROPY, // = 12
    IJL_JBUFF_WRITEENTROPY, // = 13


    // Scaled Decoding Options:

    // Reads a JPEG image scaled to 1/2 size.
    IJL_JFILE_READONEHALF, // = 14
    IJL_JBUFF_READONEHALF, // = 15

    // Reads a JPEG image scaled to 1/4 size.
    IJL_JFILE_READONEQUARTER, // = 16
    IJL_JBUFF_READONEQUARTER, // = 17

    // Reads a JPEG image scaled to 1/8 size.
    IJL_JFILE_READONEEIGHTH, // = 18
    IJL_JBUFF_READONEEIGHTH, // = 19

    // Reads an embedded thumbnail from a JFIF bit stream.
    IJL_JFILE_READTHUMBNAIL, // = 20
    IJL_JBUFF_READTHUMBNAIL // = 21
}

public enum TFAST_MCU_PROCESSING_TYPE
{
    IJL_NO_CC_OR_US, // = 0,

    IJL_111_YCBCR_111_RGB, // = 1,
    IJL_111_YCBCR_111_BGR, // = 2,

    IJL_411_YCBCR_111_RGB, // = 3,
    IJL_411_YCBCR_111_BGR, // = 4,

    IJL_422_YCBCR_111_RGB, // = 5,
    IJL_422_YCBCR_111_BGR, // = 6,

    IJL_111_YCBCR_1111_RGBA_FPX, // = 7,
    IJL_411_YCBCR_1111_RGBA_FPX, // = 8,
    IJL_422_YCBCR_1111_RGBA_FPX, // = 9,

    IJL_1111_YCBCRA_FPX_1111_RGBA_FPX, // = 10,
    IJL_4114_YCBCRA_FPX_1111_RGBA_FPX, // = 11,
    IJL_4224_YCBCRA_FPX_1111_RGBA_FPX, // = 12,

    IJL_111_RGB_1111_RGBA_FPX, // = 13,

    IJL_1111_RGBA_FPX_1111_RGBA_FPX, // = 14

    IJL_111_OTHER_111_OTHER, // = 15,
    IJL_411_OTHER_111_OTHER, // = 16,
    IJL_422_OTHER_111_OTHER, // = 17,

    IJL_YCBYCR_YCBCR, // = 18, encoding from YCbCr 422 format

    IJL_YCBCR_YCBYCR // = 19  decoding to YCbCr 422 format
}

public enum TDCTTYPE
{
    IJL_AAN,
    IJL_IPP
}

public enum TPROCESSOR_TYPE
{
    IJL_OTHER_PROC, // = 0,
    IJL_PENTIUM_PROC, // = 1,
    IJL_PENTIUM_PRO_PROC, // = 2,
    IJL_PENTIUM_PROC_MMX_TECH, // = 3,
    IJL_PENTIUM_II_PROC, // = 4
    IJL_PENTIUM_III_PROC, // = 5
    IJL_PENTIUM_4_PROC, // = 6
    IJL_NEW_PROCESSOR // = 7
}

public enum TUPSAMPLING_TYPE
{
    IJL_BOX_FILTER, // = 0
    IJL_TRIANGLE_FILTER // = 1
}
#endregion

#region structures
public struct TIJLibVersion
{
    public int Major;
    public int Minor;
    public int Build;
    public IntPtr Name;
    public IntPtr Version;
    public IntPtr InternalVersion;
    public IntPtr BuildDate;
    public IntPtr CallConv;
}

public struct TIJL_RECT
{
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;
}

public struct TFRAME
{
    public int precision;
    public int width;
    public int height;
    public int MCUheight;
    public int MCUwidth;
    public int max_hsampling;
    public int max_vsampling;
    public int ncomps;
    public int horMCU;
    public int totalMCU;
    public IntPtr comps;
    public int restart_interv;
    public int SeenAllDCScans;
    public int SeenAllACScans;
}

public struct TSTATE
{
    // Bit buffer.
    public UInt64 bit_buffer_64;
    public UInt32 bit_buffer_32;
    public int bitbuf_bits_valid;

    // Entropy.
    public IntPtr cur_entropy_ptr;
    public IntPtr start_entropy_ptr;
    public IntPtr end_entropy_ptr;
    public int entropy_bytes_processed;
    public int entropy_buf_maxsize;
    public int entropy_bytes_left;
    public int Prog_EndOfBlock_Run;

    // Input or output DIB.
    public IntPtr DIB_ptr;

    public byte unread_marker;
    public TPROCESSOR_TYPE processor_type;
    public int cur_scan_comp;
    public IntPtr hFile; // THandle;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]   // Size of file I/O buffer (4K)  
    public byte[] JPGBuffer;
}

public struct TQUANT_TABLE
{
    public int precision;
    public int ident;
    public IntPtr elements;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 84)]
    public short[] elarray;
}

public struct THUFFMAN_TABLE
{
    public int huff_class;
    public int ident;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public uint[] huffelem;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
    public short[] huffval;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
    public short[] mincode;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18)]
    public short[] maxcode;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
    public short[] valptr;
}

public struct TJPEGQuantTable
{
    public IntPtr quantizer;
    public byte iden;
}

public struct TJPEGHuffTable
{
    public IntPtr bits;
    public IntPtr vals;
    public byte hclass;
    public byte ident;
}

public struct TJPEG_PROPERTIES
{
    // Compression/Decompression control.
    public TIJLIOType iotype; // default = IJL_SETUP
    public TIJL_RECT roi; // default = 0
    public TDCTTYPE dcttype; // default = IJL_AAN
    public TFAST_MCU_PROCESSING_TYPE fast_processing; // default = IJL_NO_CC_OR_US
    public UInt32 intr; // default = FALSE

    // DIB specific I/O data specifiers.
    public IntPtr DIBBytes; // default = NULL
    public UInt32 DIBWidth; // default = 0
    public int DIBHeight; // default = 0
    public UInt32 DIBPadBytes; // default = 0
    public UInt32 DIBChannels; // default = 3
    public TIJL_COLOR DIBColor; // default = IJL_BGR
    public TIJL_SUBSAMPLING DIBSubsampling; // default = IJL_NONE
    public int DIBLineBytes; // default = 0

    // JPEG specific I/O data specifiers.
    public IntPtr JPGFile; // default = NULL
    public IntPtr JPGBytes; // default = NULL
    public UInt32 JPGSizeBytes; // default = 0
    public UInt32 JPGWidth; // default = 0
    public UInt32 JPGHeight; // default = 0
    public UInt32 JPGChannels; // default = 3
    public TIJL_COLOR JPGColor; // default = IJL_YCBCR
    public TIJL_SUBSAMPLING JPGSubsampling; // default = IJL_411
    public UInt32 JPGThumbWidth; // default = 0
    public UInt32 JPGThumbHeight; // default = 0

    // JPEG conversion properties.
    public UInt32 cconversion_reqd; // default = TRUE
    public UInt32 upsampling_reqd; // default = TRUE
    public UInt32 jquality; // default = 75
    public UInt32 jinterleaveType; // default = 0
    public UInt32 numxMCUs; // default = 0
    public UInt32 numyMCUs; // default = 0

    // Tables.
    public UInt32 nqtables;
    public UInt32 maxquantindex;
    public UInt32 nhuffActables;
    public UInt32 nhuffDctables;
    public UInt32 maxhuffindex;


    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public TQUANT_TABLE[] jFmtQuant;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public THUFFMAN_TABLE[] jFmtAcHuffman;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public THUFFMAN_TABLE[] jFmtDcHuffman;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public IntPtr[] jEncFmtQuant;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public IntPtr[] jEncFmtAcHuffman;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public IntPtr[] jEncFmtDcHuffman;

    // Allow user-defined tables.
    public UInt32 use_external_qtables;
    public UInt32 use_external_htables;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public TJPEGQuantTable[] rawquanttables;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public TJPEGHuffTable[] rawhufftables;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] HuffIdentifierAC;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public byte[] HuffIdentifierDC;

    // Frame specific members.
    public TFRAME jframe;
    public int needframe;

    // SCAN persistent members.
    public IntPtr jscan;

    public UInt32 Pad; // 8-byte alignment!!!

    // State members.
    public TSTATE state;
    public UInt32 SawAdobeMarker;
    public UInt32 AdobeXform;

    // ROI decoder members.
    public IntPtr rowoffsets;

    // Intermediate buffers.
    public IntPtr MCUBuf;

    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1440)] //??
    public byte[] tMCUBuf;

    // Processor detected.
    public TPROCESSOR_TYPE processor_type;

    public IntPtr raw_coefs;

    // Progressive mode members.
    public int progressive_found;
    public IntPtr coef_buffer;

    // Upsampling mode members.
    public TUPSAMPLING_TYPE upsampling_type;
    public IntPtr sampling_state_ptr;

    // Adobe APP14 segment variables
    public short AdobeVersion; // default = 100
    public short AdobeFlags0; // default = 0
    public short AdobeFlags1; // default = 0

    // JFIF APP0 segment variables
    public int jfif_app0_detected;
    public short jfif_app0_version; // default = 0x0101
    //public    jfif_app0_units: UCHAR; // default = 0 - pixel
    public short jfif_app0_Xdensity; // default = 1
    public short jfif_app0_Ydensity; // default = 1

    // comments related fields
    public IntPtr jpeg_comment; // default = NULL
    public short jpeg_comment_size; // default = 0
}


public struct TJPEG_CORE_PROPERTIES
{
    public UInt32 UseJPEGPROPERTIES; // default = 0

    // DIB specific I/O data specifiers.
    public IntPtr DIBBytes; // default = NULL
    public UInt32 DIBWidth; // default = 0
    public int DIBHeight; // default = 0
    public UInt32 DIBPadBytes; // default = 0
    public UInt32 DIBChannels; // default = 3
    public TIJL_COLOR DIBColor; // default = IJL_BGR
    public TIJL_SUBSAMPLING DIBSubsampling; // default = IJL_NONE

    // JPEG specific I/O data specifiers.
    public IntPtr JPGFile; // default = NULL
    public IntPtr JPGBytes; // default = NULL
    public UInt32 JPGSizeBytes; // default = 0
    public UInt32 JPGWidth; // default = 0
    public UInt32 JPGHeight; // default = 0
    public UInt32 JPGChannels; // default = 3
    public TIJL_COLOR JPGColor; // default = IJL_YCBCR
    public TIJL_SUBSAMPLING JPGSubsampling; // default = IJL_411
    public UInt32 JPGThumbWidth; // default = 0
    public UInt32 JPGThumbHeight; // default = 0

    // JPEG conversion properties.
    public UInt32 cconversion_reqd; // default = TRUE
    public UInt32 upsampling_reqd; // default = TRUE
    public UInt32 jquality; // default = 75

    public UInt32 Pad; // 8-byte alignment!!!
    // Low-level properties.
    public TJPEG_PROPERTIES jprops;
}
#endregion

//Outdated. IJL (Intel Jpeg Library) is not supported in 64bit runtime.
static class IJL
{
    #region Imported functions
    private const string ijlDLL = "ijl20";

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern int ijlInit(IntPtr jcprops);

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern int ijlFree(IntPtr jcprops);

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern IntPtr ijlGetLibVersion();

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern IntPtr ijlErrorStr(int code);

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern int ijlRead(IntPtr jcprops, TIJLIOType iotype);

    [DllImport(ijlDLL, CallingConvention = CallingConvention.StdCall, SetLastError = true, CharSet = CharSet.Ansi)]
    private static extern int ijlWrite(IntPtr jcprops, TIJLIOType iotype);

    #endregion

    #region Constants

    // The following "error" values indicate an "OK" condition.
    public const byte IJL_OK = 0;
    public const byte IJL_INTERRUPT_OK = 1;
    public const byte IJL_ROI_OK = 2;

    // The following "error" values indicate an error has occurred.
    public const short IJL_EXCEPTION_DETECTED = -1;
    public const short IJL_INVALID_ENCODER = -2;
    public const short IJL_UNSUPPORTED_SUBSAMPLING = -3;
    public const short IJL_UNSUPPORTED_shortS_PER_PIXEL = -4;
    public const short IJL_MEMORY_ERROR = -5;
    public const short IJL_BAD_HUFFMAN_TABLE = -6;
    public const short IJL_BAD_QUANT_TABLE = -7;
    public const short IJL_INVALID_JPEG_PROPERTIES = -8;
    public const short IJL_ERR_FILECLOSE = -9;
    public const short IJL_INVALID_FILENAME = -10;
    public const short IJL_ERROR_EOF = -11;
    public const short IJL_PROG_NOT_SUPPORTED = -12;
    public const short IJL_ERR_NOT_JPEG = -13;
    public const short IJL_ERR_COMP = -14;
    public const short IJL_ERR_SOF = -15;
    public const short IJL_ERR_DNL = -16;
    public const short IJL_ERR_NO_HUF = -17;
    public const short IJL_ERR_NO_QUAN = -18;
    public const short IJL_ERR_NO_FRAME = -19;
    public const short IJL_ERR_MULT_FRAME = -20;
    public const short IJL_ERR_DATA = -21;
    public const short IJL_ERR_NO_IMAGE = -22;
    public const short IJL_FILE_ERROR = -23;
    public const short IJL_INTERNAL_ERROR = -24;
    public const short IJL_BAD_RST_MARKER = -25;
    public const short IJL_THUMBNAIL_DIB_TOO_SMALL = -26;
    public const short IJL_THUMBNAIL_DIB_WRONG_COLOR = -27;
    public const short IJL_BUFFER_TOO_SMALL = -28;
    public const short IJL_UNSUPPORTED_FRAME = -29;
    public const short IJL_ERR_COM_BUFFER = -30;
    public const short IJL_RESERVED = -99;
    public const short IJL_NOT_INITED = -100;
    #endregion

    #region Переменные
    public static bool Inited { get { return inited; } }

    private static bool inited = false;
    private static IntPtr pjcore;
    private static TJPEG_CORE_PROPERTIES jcore;
    private static int lastErrCode;

    private static object initLock = new object();
    #endregion

    public static int Init()
    {
        lock (initLock)
        {
            if (inited)
                return IJL_OK;

            pjcore = Marshal.AllocHGlobal(Marshal.SizeOf(jcore));
            Marshal.StructureToPtr(jcore, pjcore, true);
            lastErrCode = ijlInit(pjcore);
            if (lastErrCode == IJL_OK)
            {
                jcore = (TJPEG_CORE_PROPERTIES)Marshal.PtrToStructure(pjcore, typeof(TJPEG_CORE_PROPERTIES));
                jcore.DIBChannels = 3;
                jcore.DIBColor = TIJL_COLOR.IJL_BGR;

                jcore.JPGChannels = 3;
                jcore.JPGColor = TIJL_COLOR.IJL_YCBCR;
                jcore.jprops.processor_type = TPROCESSOR_TYPE.IJL_NEW_PROCESSOR;

                inited = true;
            }

            return lastErrCode;
        }
    }

    public static int RawToJpg(byte[] raw, int width, int height, out byte[] jpg, bool bottomUp = true, uint CompressionQuality = 75)
    {
        jpg = new byte[0];
        if (lastErrCode == IJL_OK)
        {
            IntPtr buffIn = Marshal.AllocCoTaskMem(raw.Length);
            IntPtr buffOut = Marshal.AllocCoTaskMem(raw.Length);
            Marshal.Copy(raw, 0, buffIn, raw.Length);
            try
            {
                lock (initLock)
                {
                    jcore.DIBBytes = buffIn;
                    jcore.DIBHeight = bottomUp ? -height : height;
                    jcore.DIBWidth = (uint)width;
                    jcore.DIBPadBytes = (uint)IJL_DIB_PAD_BYTES(Convert.ToInt32(jcore.DIBWidth), Convert.ToInt32(jcore.DIBChannels));

                    jcore.JPGFile = (IntPtr)0;
                    jcore.JPGBytes = buffOut;
                    jcore.JPGSizeBytes = (uint)raw.Length;
                    jcore.JPGWidth = (uint)width;
                    jcore.JPGHeight = (uint)height;
                    jcore.jquality = CompressionQuality;
                 

                    Marshal.StructureToPtr(jcore, pjcore, true);

                    if (inited)
                        lastErrCode = ijlWrite(pjcore, TIJLIOType.IJL_JBUFF_WRITEWHOLEIMAGE);
                    else
                        lastErrCode = IJL_NOT_INITED;

                    if (lastErrCode == IJL_OK)
                    {
                        jcore = (TJPEG_CORE_PROPERTIES)Marshal.PtrToStructure(pjcore, typeof(TJPEG_CORE_PROPERTIES));

                        jpg = new byte[(int)jcore.JPGSizeBytes];
                        Marshal.Copy(buffOut, jpg, 0, jpg.Length);
                    }
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffOut);
                Marshal.FreeCoTaskMem(buffIn);
            }

            return lastErrCode;
        }
        else
            return lastErrCode;
    }

    public static int RawToJpg(byte[] raw, int width, int height, string FileName, bool bottomUp = true, uint CompressionQuality = 75)
    {
        if (lastErrCode == IJL_OK)
        {
            IntPtr buff = Marshal.AllocCoTaskMem(raw.Length);
            Marshal.Copy(raw, 0, buff, raw.Length);
            try
            {
                lock (initLock)
                {
                    jcore.DIBBytes = buff;
                    jcore.DIBHeight = bottomUp ? -height : height;
                    jcore.DIBWidth = (uint)width;
                    jcore.DIBPadBytes = (uint)IJL_DIB_PAD_BYTES(Convert.ToInt32(jcore.DIBWidth), Convert.ToInt32(jcore.DIBChannels));

                    jcore.JPGFile = (IntPtr)Marshal.StringToHGlobalAnsi(FileName);
                    jcore.JPGBytes = (IntPtr)0;
                    jcore.JPGWidth = (uint)width;
                    jcore.JPGHeight = (uint)height;
                    jcore.jquality = CompressionQuality;

                    Marshal.StructureToPtr(jcore, pjcore, true);

                    if (inited)
                        lastErrCode = ijlWrite(pjcore, TIJLIOType.IJL_JFILE_WRITEWHOLEIMAGE);
                    else
                        lastErrCode = IJL_NOT_INITED;
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buff);
            }
            return lastErrCode;
        }
        else
            return lastErrCode;
    }

    public static int JpgToRaw(byte[] jpg, out byte[] raw, out int width, out int height, bool bottomUp = true)
    {
        raw = new byte[0];
        width = 0;
        height = 0;
        if (lastErrCode == IJL_OK)
        {
            IntPtr buffIn = Marshal.AllocCoTaskMem(jpg.Length);
            Marshal.Copy(jpg, 0, buffIn, jpg.Length);
            try
            {
                lock (initLock)
                {
                    jcore.JPGFile = (IntPtr)0;
                    jcore.JPGBytes = buffIn;
                    jcore.JPGSizeBytes = (uint)jpg.Length;
                    Marshal.StructureToPtr(jcore, pjcore, true);
                    lastErrCode = ijlRead(pjcore, TIJLIOType.IJL_JBUFF_READPARAMS);
                    if (lastErrCode == IJL_OK)
                    {
                        jcore = (TJPEG_CORE_PROPERTIES)Marshal.PtrToStructure(pjcore, typeof(TJPEG_CORE_PROPERTIES));

                        width = (int)jcore.JPGWidth;
                        height = (int)jcore.JPGHeight;

                        jcore.DIBChannels = 3;
                        jcore.DIBColor = TIJL_COLOR.IJL_RGB;
                        jcore.DIBWidth = (uint)width;
                        jcore.DIBHeight = bottomUp ? -height : height;
                        jcore.DIBPadBytes = (uint)IJL_DIB_PAD_BYTES(width, (int)jcore.DIBChannels);

                        int rawSize = width * height * 4 + 1;
                        IntPtr buffOut = Marshal.AllocCoTaskMem(rawSize);
                        jcore.DIBBytes = buffOut;
                        try
                        {
                            Marshal.StructureToPtr(jcore, pjcore, true);

                            if (inited)
                                lastErrCode = ijlRead(pjcore, TIJLIOType.IJL_JBUFF_READWHOLEIMAGE);
                            else
                                lastErrCode = IJL_NOT_INITED;

                            if (lastErrCode == IJL_OK)
                            {
                                raw = new byte[rawSize];
                                Marshal.Copy(buffOut, raw, 0, rawSize);
                            }
                        }
                        finally
                        {
                            Marshal.FreeCoTaskMem(buffOut);
                        }
                    }
                }
            }
            finally
            {
                Marshal.FreeCoTaskMem(buffIn);
            }

            return lastErrCode;
        }
        else
            return lastErrCode;
    }

    public static int Free()
    {
        lock (initLock)
        {
            if (inited == false)
                return IJL_OK;

            try
            {
                lastErrCode = ijlFree(pjcore);
                inited = lastErrCode != IJL_OK;
            }
            finally
            {
                Marshal.FreeHGlobal(pjcore);
            }
            return lastErrCode;
        }
    }

    public static TIJLibVersion GetLibVersion()
    {
        return (TIJLibVersion)Marshal.PtrToStructure(ijlGetLibVersion(), typeof(TIJLibVersion));
    }

    public static string GetLastErrorStr()
    {
        return Marshal.PtrToStringAnsi(ijlErrorStr(lastErrCode));
    }

    private const int IJL_DIB_ALIGN = sizeof(int) - 1;

    private static int IJL_DIB_UWIDTH(int width, int nchannels)
    {
        return width * nchannels;
    }

    private static int IJL_DIB_AWIDTH(int width, int nchannels)
    {
        return (IJL_DIB_UWIDTH(width, nchannels) + IJL_DIB_ALIGN) & (IJL_DIB_ALIGN ^ (-1));
    }

    private static int IJL_DIB_PAD_BYTES(int width, int nchannels)
    {
        return IJL_DIB_AWIDTH(width, nchannels) - IJL_DIB_UWIDTH(width, nchannels);
    }
}

