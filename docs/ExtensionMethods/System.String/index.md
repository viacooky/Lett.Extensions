# System.String

## System.String

### Methods

| Method                                                                     | Description                               |
| -------------------------------------------------------------------------- | ----------------------------------------- |
| `IsEmail()`                                                                | 是否 Email                                |
| `IsUrl()`                                                                  | 是否 URL                                  |
| `IsUpper()`                                                                | 是否大写                                  |
| `IsLower()`                                                                | 是否小写                                  |
| `IgnoreCaseEquals(string value)`                                           | 忽略大小写比较                            |
| `Base64Encode()`                                                           | BASE64 编码, 失败返回 null                |
| `Base64Decode()`                                                           | BASE64 解码, 失败返回 null                |
| `IsNullOrWhiteSpace()`                                                     | 是否 null 或空白                          |
| `ContainsAll(IEnumerable<string> values, StringComparison comparisonType)` | 是否全部包含，默认不区分大小写            |
| `ContainsAny(IEnumerable<string> values, StringComparison comparisonType)` | 是否包含任意一个，默认不区分大小写        |
| `Format(object[] args)`                                                    | 格式化                                    |
| `Left(int length)`                                                         | 从左侧返回指定长度的字符串                |
| `Right(int length)`                                                        | 从右侧返回指定长度的字符串                |
| `ToBytes(Encoding encoding = null)`                                        | 转换为 byte 数组                          |
| `IsLike(string pattern)`                                                   | \*通配符比较是否相似 (特殊字符 用 \ 转义) |
| `RegexIsMatch(string pattern)`                                             | 正则表达式                                | 是否匹配 |
| `RegexMatches(string pattern)`                                             | 正则表达式匹配                            | 所有匹配对象 |
| `RegexMatch(string pattern)`                                               | 正则表达式匹配                            | 单个匹配对象 |
| `RegexSplit(string pattern)`                                               | 正则表达式拆分字符串                      |
| `RegexReplace(string pattern, string replacement)`                         | 正则表达式替换字符串                      |
| `RegexReplace(string pattern, MatchEvaluator evaluator)`                   | 正则表达式替换字符串                      |
