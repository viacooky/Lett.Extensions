using System.Text;

namespace Lett.Extensions
{
    /// <summary>
    ///     Bytes 扩展方法 - 转换
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     转换为字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="encoding">编码格式</param>
        /// <returns></returns>
        public static string ToString(this byte[] @this, Encoding encoding)
        {
            encoding = encoding ?? Encoding.UTF8;
            return encoding.GetString(@this);
        }
    }
}