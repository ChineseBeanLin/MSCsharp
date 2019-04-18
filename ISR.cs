using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace NCHUVA.MSC.ISR
{
    #region ISR enum
    public enum AudioStatus
    {

        MSP_AUDIO_SAMPLE_FIRST = 1, //第一块音频
        MSP_AUDIO_SAMPLE_CONTINUE = 2, //还有后继音频
        MSP_AUDIO_SAMPLE_LAST = 4 //最后一块音频

    }

    public enum EpStatus
    {
        MSP_EP_LOOKING_FOR_SPEECH = 0, //还没有检测到音频的前端点。
        MSP_EP_IN_SPEECH = 1, //已经检测到了音频前端点，正在进行正常的音频处理。
        MSP_EP_AFTER_SPEECH = 3, //检测到音频的后端点，后继的音频会被MSC忽略。
        MSP_EP_TIMEOUT = 4, //超时。
        MSP_EP_ERROR = 5, //    出现错误。
        MSP_EP_MAX_SPEECH = 6 //  音频过大。

    }

    public enum RsltStatus
    {
        MSP_REC_STATUS_SUCCESS = 0, //识别成功，此时用户可以调用QISRGetResult来获取（部分）结果。
        MSP_REC_STATUS_NO_MATCH = 1, //识别结束，没有识别结果。
        MSP_REC_STATUS_INCOMPLETE = 2, //正在识别中。
        MSP_REC_STATUS_COMPLETE = 5 //识别结束。
    }
    #endregion 
    public class ISRDLL
    {
        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr QISRSessionBegin(string grammarList, string _params, ref int errorCode);
        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QISRAudioWrite(string sessionID, byte[] waveData, uint waveLen, int audioStatus, ref int epStatus, ref int recogStatus);
        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern IntPtr QISRGetResult(string sessionID, ref int rsltStatus, int waitTime, ref int errorCode);
        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QISRSessionEnd(string sessionID, string hints);
        [DllImport("msc.dll", CallingConvention = CallingConvention.Winapi)]
        public static extern int QISRGetParam(string sessionID, string paramName, string paramValue, ref uint valueLen);
    }
}
