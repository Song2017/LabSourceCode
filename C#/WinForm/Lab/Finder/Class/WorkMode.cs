using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finder
{
    /// <summary>
    /// 工作模式
    /// </summary>
    public enum WorkMode : int
    {
        /// <summary>
        /// 多行单个
        /// </summary>
        MultiLine = 1,
        /// <summary>
        /// 单行多个
        /// </summary>
        SingleLine = 2,
    }
}
