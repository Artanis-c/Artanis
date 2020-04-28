using Artanis.Core.Attribute;
using Artanis.Core.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// SQL 构造帮助类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SqlUtil: ISqlUntil
    {
        /// <summary>
        /// 构造SQL字段
        /// </summary>
        /// <param name="propertyInfos">实体属性</param>
        /// <returns></returns>
        public string BuildSqlFiled<T>(PropertyInfo[] propertyInfos)
        {
            Type type = typeof(T);
            #region 缓存校验
            if (StringCacheUntil.ExitsKey(type.FullName))
            {
                return StringCacheUntil.GetCache(type.FullName);
            }
            #endregion

            StringBuilder sqlFiled = new StringBuilder();
            sqlFiled.Append("(");
            int length = propertyInfos.Length - 1;
            #region 拼接Sql
            for (int i = 0; i <= length; i++)
            {
                PropertyInfo property = propertyInfos[i];
                //判断字段是否是自增主键，如果是自增主键直接跳过
                TableId tableId = property.GetCustomAttribute<TableId>();
                if (tableId != null)
                {
                    if (tableId._idType == Enum.IdTypeEnum.AUTO)
                    {
                        continue;
                    }
                }
                TableFiled tableFiled = property.GetCustomAttribute<TableFiled>();
                //最后一个字段不加,
                if (i < length)
                {
                    //如果不是数据库字段直接跳过
                    if (tableFiled != null)
                    {
                        if (!tableFiled.Exits)
                        {
                            continue;
                        }
                        sqlFiled.Append("`");
                        sqlFiled.Append(tableFiled.FiledName);
                        sqlFiled.Append("`");
                        sqlFiled.Append(",");
                    }
                    else
                    {
                        sqlFiled.Append("`");
                        sqlFiled.Append(property.Name);
                        sqlFiled.Append("`");
                        sqlFiled.Append(",");
                    }
                }
                else
                {
                    //如果不是数据库字段直接跳过
                    if (tableFiled != null)
                    {
                        if (!tableFiled.Exits)
                        {
                            continue;
                        }
                        sqlFiled.Append("`");
                        sqlFiled.Append(tableFiled.FiledName);
                        sqlFiled.Append("`");
                    }
                    else
                    {
                        sqlFiled.Append("`");
                        sqlFiled.Append(property.Name);
                        sqlFiled.Append("`");
                    }
                }

            }
            #endregion
            sqlFiled.Append(")");
            //加入缓存
            string res = sqlFiled.ToString();
            StringCacheUntil.AddCache(type.FullName, res);
            return res;
        }

        /// <summary>
        /// 构造SQL参数化
        /// </summary>
        /// <param name="propertyInfos"></param>
        /// <returns></returns>
        public string BuildSqlParms<T>(PropertyInfo[] propertyInfos)
        {
            Type type = typeof(T);
            #region 缓存校验
            if (StringCacheUntil.ExitsKey(type.FullName))
            {
                return StringCacheUntil.GetCache(type.FullName);
            }
            #endregion

            #region 拼接参数化
            StringBuilder paramsSql = new StringBuilder();
            paramsSql.Append("VALUES( ");
            int size = propertyInfos.Length - 1;
            for (int i = 0; i <= size; i++)
            {
                PropertyInfo property = propertyInfos[i];
                //判断字段是否是自增主键，如果是自增主键直接跳过
                TableId tableId = property.GetCustomAttribute<TableId>();
                if (tableId != null)
                {
                    if (tableId._idType == Enum.IdTypeEnum.AUTO)
                    {
                        continue;
                    }
                }
                //校验是否是表字段
                TableFiled tableFiled = property.GetCustomAttribute<TableFiled>();
                if (tableFiled != null)
                {
                    if (!tableFiled.Exits)
                    {
                        continue;
                    }
                }
                if (i < size)
                {
                    paramsSql.Append("@");
                    paramsSql.Append(property.Name);
                    paramsSql.Append(",");
                }
                else
                {
                    paramsSql.Append("@");
                    paramsSql.Append(property.Name);
                }
            }
            #endregion
            //加入缓存
            string res = paramsSql.ToString();
            StringCacheUntil.AddCache(type.FullName, res);
            return res;
        }


        /// <summary>
        /// 获取数据库实体的表名
        /// </summary>
        /// <returns></returns>
        public string GetTableName<T>()
        {
            Type type = typeof(T);
            //检查缓存是否存在
            if (StringCacheUntil.ExitsKey(type.FullName))
            {
                return StringCacheUntil.GetCache(type.FullName);
            }
            else
            {
                //获取特性
                TableName tableNameAttr = type.GetCustomAttribute<TableName>();
                string tableName;
                if (tableNameAttr != null)
                {
                    tableName = tableNameAttr._TableName;
                }
                else
                {
                    tableName = type.Name;
                }
                //加入缓存
                StringCacheUntil.AddCache(type.FullName, tableName);
                return tableName;
            }
        }
    }
}
