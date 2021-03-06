﻿using System;
using System.Collections.Concurrent;
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
    /// 字符串缓存
    /// </summary>
    public static  class StringCacheUntil
    {
        /// <summary>
        /// 线程安全字典类
        /// </summary>
        private static ConcurrentDictionary<string, string> _cache;

        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AddCache(string key, string value)
        {
            return _cache.TryAdd(key, value);
        }

        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetCache(string key)
        {
            string value;
            bool res = _cache.TryGetValue(key, out value);
            if (res)
            {
                return value;
            }
            //default关键字会对引用类型返回null，对值类型返回0
            return default;
        }

        /// <summary>
        /// 判断key是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool ExitsKey(string key)
        {
            return _cache.ContainsKey(key);
        }

        /// <summary>
        /// 移除缓存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool RemoveKey(string key)
        {
            string value;
            return _cache.TryRemove(key, out value);
        }
    }
}
