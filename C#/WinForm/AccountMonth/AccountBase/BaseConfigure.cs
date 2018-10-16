using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;


namespace AccountBase
{
    public static class BaseConfigure
    {
        //获取配置文件中的strKey的值
        //返回默认值: strDefault
        public static string GetConfig(string strKey, string strDefault)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection ass = cfg.AppSettings;

            if (ass != null || ass.Settings != null || ass.Settings[strKey] != null)
                return ass.Settings[strKey].Value;
            else
                SaveConfing(strKey, strDefault);

            return strDefault;
        }

        //保存配置文件
        public static void SaveConfing(string strKey, string strDefault)
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection ass = cfg.AppSettings;

            foreach (string str in ass.Settings.AllKeys)
                if (str.Equals(strKey))
                    ass.Settings.Remove(str);

            ass.Settings.Add(strKey, strDefault);
            cfg.Save(ConfigurationSaveMode.Modified);
        }

      

       


    }
}
