using System.IO;
using System.Runtime.Serialization;
using System.Xml;

namespace SLAM
{
    public class XmlSerialization
    {
        public static string Serialize<T>(T obj)
        {
            var serializer = new DataContractSerializer(obj.GetType());
            using (var writer = new StringWriter())
            {
                using (var stm = new XmlTextWriter(writer))
                {
                    serializer.WriteObject(stm, obj);
                    return writer.ToString();
                }
            }
        }

        public static T Deserialize<T>(string serialized)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (var reader = new StringReader(serialized))
            {
                using (var stm = new XmlTextReader(reader))
                {
                    return (T)serializer.ReadObject(stm);
                }
            }
        }
    }
}