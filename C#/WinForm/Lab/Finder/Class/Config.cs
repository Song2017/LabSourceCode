using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finder
{
    //配置实例
    public class Config
    {
        //是否启用
        public bool Enabled { get; private set; }

        //服务端IP
        public string Server { get; private set; }

        //端口
        public string Port { get; private set; }

        //用户名
        public string UserName { get; private set; }

        //密码
        public string Pwd { get; private set; }

        //数据库
        public string Alias { get; private set; }

        //服务端目录
        public string Prj { get; private set; }

        //客户端工作目录
        public string WorkDir { get; private set; }

        //构造
        public Config()
        {
            this.Enabled = Globalspace.Enabled;
            this.Server = Globalspace.Server;
            this.Port = Globalspace.Port;
            this.UserName = Globalspace.UserName;
            this.Pwd = Globalspace.Pwd;
            this.Alias = Globalspace.Alias;
            this.Prj = Globalspace.Prj;
            this.WorkDir = Globalspace.WorkDir;
        }
    }
}
