namespace Lett.Extensions
{
    /// <summary>
    ///     int 扩展方法
    /// </summary>
    public static partial class IntExtensions
    {
        /// <summary>
        ///     私有方法，转换为 long
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        private static long ToLong(this int @this)
        {
            return @this;
        }
    }
}