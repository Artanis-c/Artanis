using Artanis.Core.Model;
using System;
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
namespace Artanis.Core.Handler
{
    public interface ISqlHandler
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        string Insert<T>(T entity);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="parms">要修改的字段</param>
        /// <param name="condition">修改的条件字符串不带where</param>
        /// <returns></returns>
        string Update<T>(dynamic parms, string condition);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        string Delete<T>(dynamic condition);

        /// <summary>
        /// 获取实体，包含全部字段
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        string GetEntity<T>(dynamic condition);

        /// <summary>
        /// 获取实体，包含全部字段
        /// </summary>
        /// <param name="sqlCondition">字符串查询条件，不带where</param>
        /// <returns></returns>
        string GetEntity<T>(string sqlCondition);

    }
}
