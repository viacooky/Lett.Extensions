namespace Lett.Extensions
{
    public static partial class Extensions
    {
        /// <summary>
        ///     格式化
        /// </summary>
        /// <param name="this"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string Format(this string @this, params object[] args)
        {
            return string.Format(@this, args);
        }

        /// <summary>
        ///     从左侧返回指定长度的字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length"></param>
        /// <exception cref="System.ArgumentOutOfRangeException">length 参数不允许小于0</exception>
        /// <returns></returns>
        public static string Left(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(0, length) : @this;
        }

        /// <summary>
        ///     从右侧返回指定长度的字符串
        /// </summary>
        /// <param name="this"></param>
        /// <param name="length"></param>
        /// <exception cref="System.ArgumentOutOfRangeException">length 参数不允许小于0</exception>
        /// <returns></returns>
        public static string Right(this string @this, int length)
        {
            return @this != null && @this.Length > length ? @this.Substring(@this.Length - length) : @this;
        }
    }
}