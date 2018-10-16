using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;

namespace AccountBase
{
    //操作xml数据
    public class XmlData
    {
        //读取xml文件
        public string XmlFileName { get; set; }
        public string User { get; set; }
        public string Pswd { get; set; }
        private string strXmlFilePath;
        XmlDocument xmlDoct = new XmlDocument();

        //保存数据到xml文件
        public XmlData(string strUser, string strPswd)
        {
            Init(strUser, strPswd);
            SaveXmlFile();
        }
        //改写默认构造函数
        public XmlData()
        {
            Init(null, null);
        }

        //判断并创建配置xml文件
        private void Init(string strUser, string strPswd)
        {
            this.User = strUser ?? string.Empty;
            this.Pswd = strPswd ?? string.Empty;

            if ((XmlFileName ?? string.Empty).Length <= 0)
                strXmlFilePath = System.Windows.Forms.Application.StartupPath + @"\Configure.xml";
            else
                strXmlFilePath = System.Windows.Forms.Application.StartupPath + XmlFileName;

            if (!System.IO.File.Exists(strXmlFilePath))
                CreateXmlFile();
        }

        //insert
        private void CreateXmlFile()
        {
            xmlDoct = new XmlDocument();
            XmlDeclaration dec = xmlDoct.CreateXmlDeclaration("1.0", "UTF-8", null);
            xmlDoct.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = xmlDoct.CreateElement("root");
            xmlDoct.AppendChild(root);

            //创建元素cfg并设置3个属性(defaultvalue : sa ,123)
            XmlElement xeLgnCfg = xmlDoct.CreateElement("cfg");
            xeLgnCfg.SetAttribute("lgn", "lgncfg");
            xeLgnCfg.SetAttribute("user", User.Length <= 0 ? "sa" : User);
            xeLgnCfg.SetAttribute("password", Pswd.Length <= 0 ? "123" : Pswd);

            root.AppendChild(xeLgnCfg);
            xmlDoct.Save(strXmlFilePath);
            //<?xml version="1.0" encoding="UTF-8"?>
            //<root>
            //  <cfg lgn="lgncfg" user="sa" password="123" />
            //</root>

            ////创建节点（二级）
            //XmlNode node = xmlDoct.CreateElement("Seconde");
            ////创建节点（三级）
            //XmlElement element1 = xmlDoct.CreateElement("Third1");
            //element1.SetAttribute("Name", "Sam");
            //element1.SetAttribute("ID", "665");
            //element1.InnerText = "Sam Comment";
            //node.AppendChild(element1);
            //XmlElement element2 = xmlDoct.CreateElement("Third2");
            //element2.SetAttribute("Name", "Round");
            //element2.SetAttribute("ID", "678");
            //element2.InnerText = "Round Comment";
            //node.AppendChild(element2);
            //root.AppendChild(node);
            //xmlDoct.Save(strXmlFilePath);

            //<?xml version="1.0" encoding="UTF-8"?>
            //<root>
            //  <cfg lgn="lgncfg" user="sa" password="123" />
            //  <Seconde>
            //    <Third1 Name="Sam" ID="665">Sam Comment</Third1>
            //    <Third2 Name="Round" ID="678">Round Comment</Third2>
            //  </Seconde>
            //</root>
        }

        //delete
        public void DeleteXmlFile()
        {
            if (User == null || Pswd == null)
                return;
            xmlDoct.Load(strXmlFilePath);
            XmlNode xn = xmlDoct.DocumentElement;
            foreach (XmlElement xe in xn)
                if (xe.Name.Equals("cfg"))
                    if (xe.Attributes["lgn"].Value.Equals("lgncfg"))
                        if (xe.Attributes["user"].Value == User)
                            xn.RemoveChild(xe);
 
            xmlDoct.Save(strXmlFilePath);
        }

        //save
        private void SaveXmlFile()
        {
            if (User == null || Pswd == null)
                return;
            xmlDoct.Load(strXmlFilePath);
            XmlNode xn = xmlDoct.DocumentElement;
            foreach (XmlElement xe in xn)
                if (xe.Name.Equals("cfg"))
                    if (xe.Attributes["lgn"].Value.Equals("lgncfg"))
                    {
                        xe.Attributes["user"].Value = User;
                        xe.Attributes["password"].Value = Pswd;
                    }

            xmlDoct.Save(strXmlFilePath);
        }

        //select
        public DataTable ReadXmlToDataTable()
        {
            DataTable dt = new DataTable();
            if (dt.Columns.Count <= 0)
            {
                dt.Columns.Add("user");
                dt.Columns.Add("pswd");
            }

            xmlDoct.Load(strXmlFilePath);
            XmlNodeList xnl = xmlDoct.DocumentElement.ChildNodes;
            foreach (XmlElement xe in xnl)
                if (xe.Name.Equals("cfg"))
                    if (xe.Attributes["lgn"].Value.Equals("lgncfg"))
                        dt.Rows.Add(xe.Attributes["user"].Value ?? string.Empty, xe.Attributes["password"].Value ?? string.Empty);
            dt.AcceptChanges();
            return dt;
        }

    }
}
