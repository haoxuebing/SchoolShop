using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SchoolShop.FrameWork.Utility
{
    public class SerializeHelper
    {
        public static string SerializeToXml(object obj)
        {
            if (obj == null)
                return string.Empty;
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            StringBuilder sb = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(sb))
                xmlSerializer.Serialize((TextWriter)stringWriter, obj);
            return ((object)sb).ToString();
        }

        public static T DeserializeFromXml<T>(string xmlData)
        {
            if (string.IsNullOrEmpty(xmlData))
                return default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            T obj = default(T);
            using (TextReader textReader = (TextReader)new StringReader(xmlData))
            {
                obj = (T)xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }
            return obj;
        }

        public static string SerializeToJson(object obj)
        {
            if (obj == null)
                return string.Empty;
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
            {
                DateParseHandling = DateParseHandling.DateTime
            });
        }

        public static T DeserializeFromJson<T>(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData))
                return default(T);
            return JsonConvert.DeserializeObject<T>(jsonData, new JsonSerializerSettings()
            {
                DateParseHandling = DateParseHandling.DateTime
            });
        }

        public static string SerializeToBinaryString(object obj)
        {
            string str = (string)null;
            if (obj != null)
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    new BinaryFormatter().Serialize((Stream)memoryStream, obj);
                    str = Convert.ToBase64String(memoryStream.ToArray());
                }
            }
            return str;
        }

        public static T DeserializeFromBinaryString<T>(string binaryData)
        {
            T obj = default(T);
            if (!string.IsNullOrEmpty(binaryData))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    byte[] buffer = Convert.FromBase64String(binaryData);
                    memoryStream.Write(buffer, 0, buffer.Length);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    obj = (T)binaryFormatter.Deserialize((Stream)memoryStream);
                }
            }
            return obj;
        }

        public static List<Guid> GetListGuid(object obj)
        {
            List<Guid> list = new List<Guid>();
            if (obj.GetType().Equals(typeof(List<string>)))
                list = Enumerable.ToList<Guid>(Enumerable.Select<string, Guid>((IEnumerable<string>)obj, (Func<string, Guid>)(a => ConvertHelper.ToGuid((object)a))));
            else if (obj.GetType().Equals(typeof(string)))
            {
                Guid result = Guid.Empty;
                Guid.TryParse(obj.ToString(), out result);
                list.Add(result);
            }
            else
            {
                JArray jarray = (JArray)obj;
                for (int index = 0; index < jarray.Count; ++index)
                    list.Add(Guid.Parse(((object)jarray[index]).ToString()));
            }
            return list;
        }

        public static List<int> GetListInt(object obj)
        {
            List<int> list = new List<int>();
            if (obj.GetType().Equals(typeof(List<string>)))
            {
                list = Enumerable.ToList<int>(Enumerable.Select<string, int>((IEnumerable<string>)obj, (Func<string, int>)(a => ConvertHelper.ToInt((object)a))));
            }
            else
            {
                JArray jarray = (JArray)obj;
                for (int index = 0; index < jarray.Count; ++index)
                    list.Add(Convert.ToInt32(((object)jarray[index]).ToString()));
            }
            return list;
        }

        public static List<string> GetListString(object obj)
        {
            List<string> list = new List<string>();
            if (obj.GetType().Equals(typeof(List<string>)))
            {
                list = (List<string>)obj;
            }
            else
            {
                JArray jarray = (JArray)obj;
                for (int index = 0; index < jarray.Count; ++index)
                    list.Add(((object)jarray[index]).ToString());
            }
            return list;
        }
    }
}
