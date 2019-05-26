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
        ///     管道操作 - action
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new MyClass();
        /// var rs = obj1.Pipe(o => { o.Name += "pipe1";})
        ///              .Pipe(o => { o.Name += "_pipe2";})
        ///              .Pipe(o => { o.Name += "_pipe3";})
        ///              .Pipe(o => { o.Name += "_pipe4";})
        ///              .Pipe(o => { o.Name += "_pipe5";});
        ///
        /// // rs.Name == "pipe1_pipe2_pipe3_pipe4_pipe5";
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Pipe<T>(this T @this, Action<T> action)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            action(@this);
            return @this;
        }

        /// <summary>
        ///     管道操作 - func
        /// </summary>
        /// <param name="this"></param>
        /// <param name="func"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var obj1 = new MyClass();
        /// var rs2 = obj1.Pipe(o => { o.Name += "pipe1";})
        ///               .Pipe(o => { o.Name += "_pipe2";})
        ///               .Pipe(o => { o.Name += "_pipe3";})
        ///               .Pipe(o => { o.Name += "_pipe4";})
        ///               .Pipe(o => { o.Name += "_pipe5";})
        ///               .Pipe(o => o.Name.Replace("pipe", "")); // pipe func  return: o.Name.Replace("pipe", "");
        /// Assert.AreEqual(rs2, "1_2_3_4_5");
        ///         ]]>
        ///     </code>
        /// </example>
        public static TResult Pipe<TSource, TResult>(this TSource @this, Func<TSource, TResult> func)
        {
            if (@this == null) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            return func(@this);
        }
    }
}