using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AppConnectNetWorkCheck
{
    public static class PubTools
    {
        //获取当前app基目录
        public static string AppCurrentPath = System.AppDomain.CurrentDomain.BaseDirectory.ToStringEx();

        //读写App.config
        /// <summary>
        /// 获取配置表数值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">值</param>
        /// <returns></returns>
        public static string GetConfig(string key, string defaultValue)
        {
            string strConfigRtn = string.Empty;

            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection ass = cfg.AppSettings;
            if (ass == null || ass.Settings == null || ass.Settings.Count == 0 || ass.Settings[key] == null)
            {
                strConfigRtn = defaultValue;
                SaveConfig(key, defaultValue);
            }
            else
            {
                strConfigRtn = ass.Settings[key].Value.ToStringEx();
            }

            return strConfigRtn.ToStringEx();
        }
        /// <summary>
        ///  保存配置数据
        /// </summary>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        public static void SaveConfig(string key, string defaultValue)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection ass = config.AppSettings;
            for (int i = 0; i < ass.Settings.AllKeys.Length; i++)
                if (key.ToStringEx().Equals(ass.Settings.AllKeys[i]))
                    ass.Settings.Remove(key);
            ass.Settings.Add(key, defaultValue);
            config.Save(ConfigurationSaveMode.Modified);
            //用xml操作 
        }

        //获取客户机配置






        //方法拓展
        /// <summary>
        ///  拓展 tostring
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringEx(this object value)
        {
            return value.IsNullOrDBNull() ? String.Empty : Convert.ToString(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrDBNull(this object value)
        {
            return value == null || value == DBNull.Value;
        }

    }
}
