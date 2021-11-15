using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QQRobot.Mirai.NetWinForm.Helper
{
    /// <summary>
    /// 公共工具类
    /// </summary>
    public class CommonUtils
    {
        /// <summary>  
        /// DateTime时间格式转换为Unix时间戳格式  
        /// </summary>  
        /// <param name="time">时间</param>  
        /// <returns>long</returns>  
        public static long ConvertDateTimeToInt(System.DateTime time)
        {
            long t = (time.Ticks - 621356256000000000) / 10000;
            return t;
        }
        /// <summary>
        /// html格式文本转纯文本
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlToText(string str) {
            str = str.Replace("\n/g", "");
            str = str.Replace("\r/g", "");
            return str;
        }

    }
}
