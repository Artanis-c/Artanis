using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artanis.Core.Util
{
    public static class DynamicUtil
    {

        public static string parseDynamicToString(dynamic type)
        {
            if (type == null)
            {
                return "";
            }
            string json = JsonConvert.SerializeObject(type);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            StringBuilder sb = new StringBuilder();
            int size = dict.Count - 1;
            int i = 0;
            foreach (var item in dict)
            {
                i++;
                if (i < size)
                {
                    sb.Append(item.Key);
                    sb.Append("=@");
                    sb.Append(item.Key);
                    sb.Append(" AND ");
                }
                else
                {
                    sb.Append(item.Key);
                    sb.Append("=@");
                    sb.Append(item.Key);
                }
            }
            return sb.ToString();
        }

        public static string parseDynamicToString(dynamic type,string sp)
        {
            if (type == null)
            {
                return "";
            }
            string json = JsonConvert.SerializeObject(type);
            Dictionary<string, string> dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            StringBuilder sb = new StringBuilder();
            int size = dict.Count - 1;
            int i = 0;
            foreach (var item in dict)
            {
                i++;
                if (i < size)
                {
                    sb.Append(item.Key);
                    sb.Append("=@");
                    sb.Append(item.Key);
                    sb.Append(sp);
                }
                else
                {
                    sb.Append(item.Key);
                    sb.Append("=@");
                    sb.Append(item.Key);
                }
            }
            return sb.ToString();
        }
    }
}
