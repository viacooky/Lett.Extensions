using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lett.Extensions
{
    /// <summary>
    ///     Object 扩展方法
    /// </summary>
    public static partial class ObjectExtensions
    {
        /// <summary>
        ///     深复制
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T">
        ///     泛型约束 需要支持序列化 Serializable
        /// </typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentException"><paramref name="this" /> 需要支持序列化 Serializable</exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// [Serializable]
        /// private class MyClass
        /// {
        ///     public string Name { get; set; }
        /// }
        /// var obj = new MyClass{Name = "aa"};
        /// var rs = obj.DeepClone();
        /// // obj.Name == rs.Name
        /// // obj != rs
        ///         ]]>
        ///     </code>
        /// </example>
        public static T DeepClone<T>(this T @this)
        {
            if (!typeof(T).IsSerializable) throw new ArgumentException("类型需要支持序列化", nameof(@this));

            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, @this);
                stream.Seek(0, SeekOrigin.Begin);
                return (T) formatter.Deserialize(stream);
            }
        }

        /// <summary>
        ///     指定类型的实例是否能分配给当前类型实例
        /// </summary>
        /// <param name="this"></param>
        /// <param name="targetType">指定类型</param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this object @this, Type targetType)
        {
            return @this.GetType().IsAssignableFrom(targetType);
        }
    }
}