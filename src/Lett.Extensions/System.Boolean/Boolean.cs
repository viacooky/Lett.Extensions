using System;

namespace Lett.Extensions
{
    /// <summary>
    ///     bool 扩展方法
    /// </summary>
    public static class BooleanExtensions
    {
        /// <summary>
        ///     结果为 True 时，执行方法
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action">执行的方法</param>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var condition = true;
        /// var rs = "";
        /// condition.IfTrue(() => rs = "it is true"); // rs == "it is true";
        ///
        /// var condition = false;
        /// var rs = "";
        /// condition.IfTrue(() => rs = "it is true"); // rs == "";
        ///         ]]>
        ///     </code>
        /// </example>
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this) action();
        }

        /// <summary>
        ///     <para>结果为 True 时，返回参数 </para>
        ///     <para>结果为 False 时，返回参数类型默认值</para>
        /// </summary>
        /// <param name="this"></param>
        /// <param name="result">参数</param>
        /// <typeparam name="T">参数类型</typeparam>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var condition = true;
        /// var rs = "";
        /// rs = condition.IfTrue("it is true"); // rs == "it is true";
        /// 
        /// var condition = false;
        /// var rs = "";
        /// rs = condition.IfTrue("it is true"); // rs == null == default(string)
        ///         ]]>
        ///     </code>
        /// </example>
        public static T IfTrue<T>(this bool @this, T result)
        {
            return @this ? result : default;
        }

        /// <summary>
        ///     结果为 False 时，执行方法
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="action">执行的方法</param>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var condition = true;
        /// var rs = "";
        /// condition.IfFalse(() => rs = "it is false"); // rs == "";
        ///
        /// var condition = false;
        /// var rs = "";
        /// condition.IfFalse(() => rs = "it is false"); // rs == "it is false";
        ///         ]]>
        ///     </code>
        /// </example>
        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this) action();
        }

        /// <summary>
        ///     <para>结果为 False 时，返回参数</para>
        ///     <para>结果为 True 时，返回参数类型默认值</para>
        /// </summary>
        /// <param name="this">结果</param>
        /// <param name="result">参数</param>
        /// <typeparam name="T">参数类型</typeparam>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// var condition = true;
        /// var rs = "";
        /// rs = condition.IfFalse("it is false"); // rs == null == default(string)
        /// 
        /// var condition = false;
        /// var rs = "";
        /// rs = condition.IfFalse("it is false"); // rs == "it is false"
        ///         ]]>
        ///     </code>
        /// </example>
        public static T IfFalse<T>(this bool @this, T result)
        {
            return !@this ? result : default;
        }
    }
}