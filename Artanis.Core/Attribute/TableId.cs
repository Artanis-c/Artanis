using Artanis.Core.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
    /// 数据库主键特性
    /// </summary>
    /// 
    [AttributeUsage(AttributeTargets.Property)]
    public class TableId : System.Attribute
    {
        public IdTypeEnum _idType { get; set; }

        public TableId(IdTypeEnum idType)
        {
            this._idType = idType;
        }


    }
}
