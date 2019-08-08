using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lett.Extensions
{
    /// <summary>
    ///     Stream 扩展方法
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///     <para>保存为文件</para>
        ///     <para>FileMode.<see cref="FileMode.Create" /> | bufferSize: 81920</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="filePath"></param>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var ms = new MemoryStream(myBytes);
        /// ms.SaveToFile(filePath);
        ///         ]]>
        ///     </code>
        /// </example>
        public static void SaveAsFile(this Stream @this, string filePath)
        {
            @this.SaveAsFile(filePath, FileMode.Create);
        }

        /// <summary>
        ///     <para>保存为文件</para>
        ///     <para>bufferSize: 81920</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileMode">文件打开方式</param>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="filePath" /> is null</exception>
        /// <exception cref="System.NotSupportedException"><paramref name="filePath" /> is not supported </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var ms = new MemoryStream(myBytes);
        /// ms.SaveToFile(filePath, FileMode.Append);
        ///         ]]>
        ///     </code>
        /// </example>
        public static void SaveAsFile(this Stream @this, string filePath, FileMode fileMode)
        {
            @this.SaveAsFile(filePath, fileMode, 81920);
        }

        /// <summary>
        ///     保存为文件
        /// </summary>
        /// <param name="this"></param>
        /// <param name="filePath">文件路径</param>
        /// <param name="fileMode">文件打开方式</param>
        /// <param name="bufferSize">缓冲区大小</param>
        /// <exception cref="ArgumentNullException"><paramref name="this" /> is null</exception>
        /// <exception cref="ArgumentNullException"><paramref name="filePath" /> is null</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="bufferSize" />must greater than zero</exception>
        /// <exception cref="System.NotSupportedException"><paramref name="filePath" /> is not supported </exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var ms = new MemoryStream(myBytes);
        /// ms.SaveToFile(filePath, FileMode.Append, 1024);
        ///         ]]>
        ///     </code>
        /// </example>
        public static void SaveAsFile(this Stream @this, string filePath, FileMode fileMode, int bufferSize)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), "is null");
            if (filePath.IsNull()) throw new ArgumentNullException(nameof(filePath), "is null");
            if (filePath.IsEmpty()) throw new ArgumentException(nameof(filePath), $"{nameof(filePath)} empty string");
            if (bufferSize < 1) throw new ArgumentOutOfRangeException(nameof(bufferSize), $"{nameof(bufferSize)} must greater than zero");
            var dirPath = Path.GetDirectoryName(filePath) ?? throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} can not find directory name");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            using (var fs = new FileStream(filePath, fileMode)) { @this.CopyTo(fs, bufferSize); }
        }

        /// <summary>
        ///     <para>反序列化</para>
        ///     <para>formatter: <see cref="BinaryFormatter" /></para>
        ///     <para>类型转换失败，返回 <c>default(T)</c></para>
        ///     <para></para>
        /// </summary>
        /// <param name="this"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
        /// var rs = fs.Deserialize<MyClass>();
        ///         ]]>
        ///     </code>
        /// </example>
        public static T Deserialize<T>(this Stream @this)
        {
            return @this.Deserialize<T>(new BinaryFormatter());
        }

        /// <summary>
        ///     <para>反序列化</para>
        ///     <para>类型转换失败，返回 <c>default(T)</c></para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="formatter">格式化器</param>
        /// <typeparam name="T">类型</typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(this Stream @this, IFormatter formatter)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (formatter.IsNull()) throw new ArgumentNullException(nameof(formatter), $"{nameof(formatter)} is null");
            return formatter.Deserialize(@this).As<T>();
        }
    }
}