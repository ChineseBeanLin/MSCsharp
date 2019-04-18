using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace NCHUVA.MSC.TTS
{

    #region TTS枚举常量
    /// <summary>
    /// vol参数的枚举常量
    /// </summary>
    public enum EnuVol
    {
        x_soft,
        soft,
        medium,
        loud,
        x_loud
    }

    /// <summary>
    /// speed语速参数的枚举常量
    /// </summary>
    public enum EnuSpeed
    {
        x_slow,
        slow,
        medium,
        fast,
        x_fast
    }
    /// <summary>
    /// speeker朗读者枚举常量
    /// </summary>
    public enum EnuSpeeker
    {
        小燕_青年女声_中英文_普通话 = 0,
        小宇_青年男声_中英文_普通话,
        凯瑟琳_青年女声_英语,
        亨利_青年男声_英语,
        玛丽_青年女声_英语,
        小研_青年女声_中英文_普通话,
        小琪_青年女声_中英文_普通话,
        小峰_青年男声_中英文_普通话,
        小梅_青年女声_中英文_粤语,
        小莉_青年女声_中英文_台普,
        小蓉_青年女声_汉语_四川话,
        小芸_青年女声_汉语_东北话,
        小坤_青年男声_汉语_河南话,
        小强_青年男声_汉语_湖南话,
        小莹_青年女声_汉语_陕西话,
        小新_童年男声_汉语_普通话,
        楠楠_童年女声_汉语_普通话,
        老孙_老年男声_汉语_普通话
    }

    public enum SynthStatus
    {
        MSP_TTS_FLAG_STILL_HAVE_DATA = 1,
        MSP_TTS_FLAG_DATA_END = 2,
        MSP_TTS_FLAG_CMD_CANCELED = 0
    }
    #endregion
    public class TTSDll
    {

        #region TTS dll import

        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr QTTSSessionBegin(string _params, ref int errorCode);

        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QTTSTextPut(string sessionID, string textString, uint textLen, string _params);

        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr QTTSAudioGet(string sessionID, ref uint audioLen, ref SynthStatus synthStatus, ref int errorCode);

        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QTTSGetParam(string sessionID, string paramName, string paramValue, ref uint valueLen);

        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QTTSSessionEnd(string sessionID, string hints);
        #endregion
    }
}