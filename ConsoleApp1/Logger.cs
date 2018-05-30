using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace Tools
{
    public class Logger
    {
        log4net.ILog logger = log4net.LogManager.GetLogger("stock");

        public void AppendInfo(object content)
        {
            logger.Info(content);
            Console.WriteLine(content);
        }
        public void Err(object content)
        {
            logger.Error(content);
            Console.WriteLine(content);
        }
    }
    public static class JsonHelper
    {
        private const string document = "Exception";

        /// <summary>
        /// Json.Net实现将数据序列化为JSON字符串
        /// </summary>
        /// <param name="source">数据源</param>
        /// <param name="isFormat">是否格式化（默认：false）</param>
        /// <param name="ignoreNull">是否忽略空值（默认：false）</param>
        /// <param name="includeType">是否包含类型（默认：false）</param>
        /// <param name="loopHandling">跳过循环引用（默认：false）</param>
        /// <returns></returns>
        public static string ToJson(this object source, bool isFormat = false, bool ignoreNull = false, bool includeType = false, bool loopHandling = false)
        {
            try
            {
                Newtonsoft.Json.Formatting formatting = isFormat ? Newtonsoft.Json.Formatting.Indented : Newtonsoft.Json.Formatting.None;

                if (source is XmlDocument)
                    return JsonConvert.SerializeXmlNode((XmlDocument)source, formatting);


                JsonSerializerSettings settings = new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = loopHandling ? ReferenceLoopHandling.Ignore : ReferenceLoopHandling.Serialize,
                    //PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    MissingMemberHandling = MissingMemberHandling.Ignore,
                    NullValueHandling = ignoreNull ? NullValueHandling.Ignore : NullValueHandling.Include,
                    TypeNameHandling = includeType ? TypeNameHandling.Auto : TypeNameHandling.None,
                    DateFormatString = "yyyy-MM-dd HH:mm:ss"
                };
                return JsonConvert.SerializeObject(source, formatting, settings);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// Json.Net实现反序列化到实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObj"></param>
        /// <returns></returns>
        public static T To<T>(this object jsonObj)
        {
            if (jsonObj == null)
                return default(T);
            if (jsonObj is string && string.IsNullOrWhiteSpace(jsonObj.ToString()))
                return default(T);
            try
            {
                if (jsonObj is string && !string.IsNullOrWhiteSpace(jsonObj.ToString()))
                    return JsonConvert.DeserializeObject<T>(jsonObj.ToString());
                return JsonConvert.DeserializeObject<T>(jsonObj.ToJson());
            }
            catch (Exception ex)
            {
                return default(T);
            }
        }

        /// <summary>
        /// 从配置文件中读取配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static T ReadTo<T>(this string filePath)
        {
            return File.ReadAllText(filePath).To<T>();
        }

        public static T ReadTo<T>(this string filePath, string searchKey)
        {
            return JObject.Parse(File.ReadAllText(filePath)).SelectToken(searchKey, false).ToObject<T>();
        }
    }


}