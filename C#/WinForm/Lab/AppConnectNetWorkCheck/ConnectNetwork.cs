using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Net.NetworkInformation;

namespace AppConnectNetWorkCheck
{
    //是否联网核心类
    public static class ConnectNetwork
    {
        /// <summary>
        ///  是否联网
        /// </summary>
        public static bool IsConnectNetwork { get; set; }
        /// <summary>
        ///  app.config中的url
        /// </summary>
        public static string ConfigUrl { get; set; }


        [DllImport("winInet")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        //检测本机是否联网
        public static bool ConnectNetworkCheck()
        {
            int dwFlag = 0;
            //dwFlag 1:调制解调器 2:网卡
            if (!InternetGetConnectedState(ref dwFlag, 0))
                IsConnectNetwork = false;
            //(?<=://)   [a-zA-Z\.0-9-_]+   (?=[:,\/])
            //释义 : 左侧以 :// 开始,右侧以 :,\/ 之一的字符结束 
            if (ConfigUrl.Length > 16)
                ConfigUrl = Regex.Match(ConfigUrl, @"(?<=://)[a-zA-Z\.0-9-_]+(?=[:,\/])").Value.ToString();

            Ping ping = new Ping();
            PingReply pr = ping.Send(ConfigUrl);
            if (pr.Status == IPStatus.Success || pr.Status == IPStatus.TimedOut)
            {
                IsConnectNetwork = true;
                return true;
            }

            IsConnectNetwork = false;
            return false;
        }
    }
}
