using Artanis.Core.DI;
using Artanis.Core.Model;
using Artanis.Core.Until;
using Artanis.Core.Util;
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
namespace Artanis.Core.Handler.Impl
{
    public class MySqlHandler : ISqlHandler
    {
        private readonly ISqlUntil sqlUntil = DIContainer.GetService<ISqlUntil>();
        public string Delete<T>(dynamic condition)
        {
            string tableName = sqlUntil.GetTableName<T>();
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM ")
                .Append(tableName)
                .Append(" WHERE 1=1 ")
                .Append(DynamicUtil.parseDynamicToString(condition));
            return sql.ToString();
        }

        public string GetEntity<T>(dynamic condition)
        {
            string tableName = sqlUntil.GetTableName<T>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ")
                .Append(tableName)
                .Append(" WHERE 1=1 ")
                .Append(DynamicUtil.parseDynamicToString(condition));
            return sql.ToString();
        }

        public string GetEntity<T>(string sqlCondition)
        {
            AssertUntil.AssertString(sqlCondition);
            string tableName = sqlUntil.GetTableName<T>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM ")
                .Append(tableName)
                .Append(" WHERE 1=1 ")
                .Append(sqlCondition);
            return sql.ToString();
        }

        public string Insert<T>()
        {
            string tableName = sqlUntil.GetTableName<T>();
            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO ")
                .Append(sqlUntil.BuildSqlFiled<T>(propertyInfos))
                .Append(sqlUntil.BuildSqlParms<T>(propertyInfos));
            return sql.ToString();
        }

        public string Update<T>(dynamic parms, string condition)
        {
            string tableName = sqlUntil.GetTableName<T>();
            StringBuilder sql = new StringBuilder();
            sql.Append("UPDATE  ")
                .Append(tableName)
                .Append(" SET ")
                .Append(DynamicUtil.parseDynamicToString(parms))
                .Append(" WHERE 1=1  ")
                .Append(condition);
            return sql.ToString();
        }
    }
}
