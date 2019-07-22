using System;
using System.IO;

namespace Lett.Extensions
{
    /// <summary>
    ///     Stream 扩展方法
    /// </summary>
    public static class StreamExtensions
    {
        /// <summary>
        ///     <para>保存至文件</para>
        ///     <para><see cref="FileMode" />默认: <see cref="FileMode.Create" /></para>
        ///     <para>缓冲区大小默认: 81920</para>
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
        public static void SaveToFile(this Stream @this, string filePath)
        {
            @this.SaveToFile(filePath, FileMode.Create);
        }

        /// <summary>
        ///     <para>保存至文件</para>
        ///     <para>缓冲区大小默认: 81920</para>
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
        public static void SaveToFile(this Stream @this, string filePath, FileMode fileMode)
        {
            @this.SaveToFile(filePath, fileMode, 81920);
        }

        /// <summary>
        ///     保存至文件
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
        public static void SaveToFile(this Stream @this, string filePath, FileMode fileMode, int bufferSize)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), "is null");
            if (filePath.IsNull()) throw new ArgumentNullException(nameof(filePath), "is null");
            if (filePath.IsEmpty()) throw new ArgumentException(nameof(filePath), $"{nameof(filePath)} empty string");
            if (bufferSize < 1) throw new ArgumentOutOfRangeException(nameof(bufferSize), $"{nameof(bufferSize)} must greater than zero");
            var dirPath = Path.GetDirectoryName(filePath) ?? throw new ArgumentNullException(nameof(filePath), $"{nameof(filePath)} can not find directory name");
            if (!Directory.Exists(dirPath)) Directory.CreateDirectory(dirPath);
            using (var fs = new FileStream(filePath, fileMode)) { @this.CopyTo(fs, bufferSize); }
        }
    }
}