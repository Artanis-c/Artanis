using System;
using System.Collections;
using System.Collections.Generic;
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
    /// 断言工具类
    /// </summary>
    public static class AssertUntil
    {
        /// <summary>
        /// 字符串非空断言
        /// </summary>
        /// <param name="agr"></param>
        public static void AssertString(String agr)
        {
            if (string.IsNullOrWhiteSpace(agr))
            {
                throw new ArgumentNullException("请传入有效的数据库表名");
            }
        }

        /// <summary>
        /// int 值有效性断言
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public static bool AssertInt(int req)
        {
            if (req <= 0)
            {
                return false;
            }
            return true;
        }

    }
}
