using System.Collections.Generic;

namespace Finder.Translators
{
    //数据源,必须包装为单一对象否则,.net自带Json转换器不识别,json.net的可以识别
    public class TranslatorDataSource
    {
        //翻译器
        private List<Translator> m_Trans = new List<Translator>();
        public List<Translator> Trans
        {
            get
            {
                return this.m_Trans;
            }
            set
            {
                this.m_Trans = value;
            }
        }

        //选中翻译器的ID
        private List<string> m_CheckedIds = new List<string>();
        public List<string> CheckedIds
        {
            get
            {
                return this.m_CheckedIds;
            }
            set
            {
                this.m_CheckedIds = value;
            }
        }
    }
}
