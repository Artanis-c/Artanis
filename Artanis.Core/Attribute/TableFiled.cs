using Artanis.Core.Until;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;

/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 *                                                                                 *
 *                                                                                 *
 * Author: Tom.cui                                                                 *
 *                                                                                 *
 * Date: 2020-04                                                                   *
 *                                                                                 *
 * Describe: 博客园地址：https://www.cnblogs.com/Tassdar/  本项目纯属个人爱好，    *
 * 喜欢的欢迎Start,不喜勿喷，欢迎提出优化建议，旨在为.net core 社区贡献一份力量    *
 *                                                                                 *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
namespace Artanis.Core.Attribute
{
    /// <summary>
    /// 数据库字段特性
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Property)]
    public class TableFiled : System.Attribute
    {
        /// <summary>
        /// 是否是表字段
        /// </summary>
        public bool Exits { get; set; } = true;

        /// <summary>
        ///  字段别名
        /// </summary>
        public string FiledName { get; set; }


        public TableFiled(bool exits)
        {
            this.Exits = exits;
        }

        public TableFiled(string filedName)
        {
            AssertUntil.AssertString(filedName);
            this.FiledName = filedName;
        }

        public TableFiled(bool exits,String filedName)
        {
            AssertUntil.AssertString(filedName);
            this.FiledName = filedName;
            this.Exits = exits;
        }
    }
}
