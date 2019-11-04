using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lett.Extensions
{
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        ///     返回当前目录的文件列表
        /// </summary>
        /// <param name="this"></param>
        /// <param name="searchOption">用于指定搜索操作是应仅包含当前目录还是应包含所有子目录的枚举值之一。</param>
        /// <param name="patterns">要与文件名匹配的搜索字符串。 此参数可以包含有效文本路径和通配符（* 和 ?）的组合，但不支持正则表达式。</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// directoryInfo.GetFiles(SearchOption.AllDirectories, "*.json");
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// directoryInfo.GetFiles(SearchOption.TopDirectoryOnly,"*.json");
        ///         ]]>
        ///     </code>
        /// </example>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// directoryInfo.GetFiles(SearchOption.AllDirectories,"*.json", "*.txt");
        ///         ]]>
        ///     </code>
        /// </example>
        public static FileInfo[] GetFiles(this DirectoryInfo @this, SearchOption searchOption, params string[] patterns)
        {
            if (@this.IsNull()) throw new ArgumentNullException(nameof(@this), $"{nameof(@this)} is null");
            if (patterns.IsNull()) throw new ArgumentNullException(nameof(patterns), $"{nameof(patterns)} is null");
            var fileInfoList = new List<FileInfo>();
            patterns.ForEach(pattern => fileInfoList.AddRange(@this.GetFiles(pattern, searchOption)));
            return fileInfoList.ToArray();
        }

        /// <summary>
        ///     返回当前目录的文件列表
        /// </summary>
        /// <param name="this"></param>
        /// <param name="searchOption">用于指定搜索操作是应仅包含当前目录还是应包含所有子目录的枚举值之一。</param>
        /// <param name="patterns">要与文件名匹配的搜索字符串。 此参数可以包含有效文本路径和通配符（* 和 ?）的组合，但不支持正则表达式。</param>
        /// <param name="excludeSelector">排除选择器</param>
        /// <returns></returns>
        /// <example>
        ///     <code>
        ///         <![CDATA[
        /// directoryInfo.GetFiles(SearchOption.AllDirectories, new[] {"*.*"}, fileInfo => fileInfo.Name.StartsWith("sub"));
        ///         ]]>
        ///     </code>
        /// </example>
        public static FileInfo[] GetFiles(this DirectoryInfo @this, SearchOption searchOption, string[] patterns, Func<FileInfo, bool> excludeSelector)
        {
            return @this.GetFiles(searchOption, patterns)
                        .Where(info => !excludeSelector(info))
                        .ToArray();
        }
    }
}