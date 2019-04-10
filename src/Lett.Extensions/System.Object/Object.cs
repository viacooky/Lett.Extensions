using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     深复制
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static T DeepClone<T>(this T @this)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, @this);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}