using System;
using System.Collections.Generic;
using System.Reflection;
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
namespace Artanis.Core.Util
{
    /// <summary>
    /// SQL构造接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ISqlUntil
    {
        /// <summary>
        /// 构造SQL字段
        /// </summary>
        /// <param name="propertyInfos"></param>
        /// <returns></returns>
         string BuildSqlFiled<T>(PropertyInfo[] propertyInfos);

        /// <summary>
        /// 构造SQL参数化
        /// </summary>
        /// <param name="propertyInfos"></param>
        /// <returns></returns>
        string BuildSqlParms<T>(PropertyInfo[] propertyInfos);

        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns></returns>
        public string GetTableName<T>();
    }
}
