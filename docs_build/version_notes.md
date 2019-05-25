# Version Notes

### 0.2.2 (2019-05-26)

#### Features / 新增功能

- 增加`DateTime` 扩展方法
  - `Tomorrow(DateTime)` 获取明天的 DateTime
  - `Yesterday(DateTime)` 获取昨天的 DateTime
- 增加`Object` 扩展方法
  - `IsClass(Object)` 当前对象类型是否 Class
  - `IsArray(Object)` 当前对象类型是否 Array
  - `IsSerializable(Object)` 当前对象类型是否可序列化的
  - `IsValueType(Object)` 当前对象类型是否值类型
  - `IsEnum(Object)` 当前对象类型是否枚举

### 0.2.1 (2019-05-24)

#### Features / 新增功能

- 增加`DateTime`扩展方法:
  - `IsBetween(DateTime startDateTime, DateTime endDateTime)` 是否在指定日期之间
  - `StartOfMonth(DateTime)` 获取月的开始 DateTime (year-month-day 00:00:00.000)
  - `EndOfMonth(DateTime)` 获取月的结束 DateTime (year-month-day 23:59:59.999)
  - `StartOfYear(DateTime)` 获取年的开始 DateTime (year-month-day 00:00:00.000)
  - `EndOfYear(DateTime)` 获取年的结束 DateTime (year-month-day 23:59:59.999)
  - `IsToday(DateTime)` 是否当天
  - `IsWeekDay(DateTime)` 是否工作日 (周一至周五)
- 增加`Object`扩展方法:
  - `In<T>(T, IEnumerable<T>)` 当前对象是否存在于 items 集合内
  - `In<T>(T, IEnumerable<T>, IEqualityComparer<T>)` 当前对象是否存在于 items 集合内

### 0.2.0 (2019-05-21)

#### Features / 新增功能

- 增加`IEnumerable<T>`扩展方法：
  - `ContainsAny(IEnumerable<T> items)` 是否包含任一元素
  - `ContainsAll(IEnumerable<T> items)` 是否包含全部元素
- 增加`DateTime`扩展方法:
  - `SetTime(int hour, int minute, int second, int millisecond = 0)` 设置 DateTime 的 time 部分
  - `StartOfDay()` 获取 DateTime 的开始 (year-month-day 00:00:00.000)
  - `EndOfDay()` 获取 DateTime 的结束 (year-month-day 23:59:59.999)
  - `StartOfWeek()` 获取本周开始的 DateTime (year-month-day 00:00:00.000)
  - `EndOfWeek()` 获取本周结束的 DateTime (year-month-day 23:59:59.999)

#### Changed / 变更

- 移除`DateTime`扩展方法:
  - `RemoveTimePart()` 移除时间部分

### 0.1.9 (2019-05-18)

#### Features / 新增功能

- 增加`DateTime`扩展方法:
  - `RemoveTimePart()` 移除时间部分
- 增加`Array`扩展方法
  - `ClearAll()` 全部清除
  - `ContainsIndex(int index)` 是否包含索引
  - `Sort()` 排序
  - `Reverse()` 反转
  - `Find()` 返回数组中的第一个匹配元素
  - `FindLast()` 返回数组中的最后一个匹配元素
  - `FindAll()` 返回数组中所有匹配的元素
  - `FindIndex()` 返回数组中的第一个匹配元素的索引
  - `FindLastIndex()` 返回数组中的最后一个匹配元素的索引
  - `ForEach()` 对指定数组的每个元素执行指定操作

### 0.1.8 (2019-05-13)

#### Features / 新增功能

- 增加`string`扩展方法:
  - `ToBytes(Encoding encoding = null)` 转换为 byte 数组
  - `IsLike(string pattern)` \*通配符比较是否相似 (特殊字符 用 \ 转义)
  - `RegexIsMatch(string pattern)` 正则表达式 - 是否匹配
  - `RegexMatches(string pattern)` 正则表达式匹配 - 所有匹配对象
  - `RegexMatch(string pattern)` 正则表达式匹配 - 单个匹配对象
  - `RegexSplit(string pattern)` 正则表达式拆分字符串
  - `RegexReplace(string pattern, string replacement)` 正则表达式替换字符串
  - `RegexReplace(string pattern, MatchEvaluator evaluator)` 正则表达式替换字符串
- 增加`byte[]`扩展方法:
  - `ToString(Encoding encoding)` 转换为字符串
- 增加`ICollection`扩展方法:
  - `AddIfNotContains<T>(@this, T item)` 如果不包含，则添加
  - `AddIfNotContains<T>(ICollection<T> items)` 如果不包含，则添加
- 增加`bool`扩展方法:
  - `IfTrue(Action action)` 结果为 True 时，执行方法
  - `IfTrue(T result)` 结果为 True 时，返回参数 (结果为 False 时，返回参数类型默认值)
  - `IfFalse(Action action)` 结果为 False 时，执行方法
  - `IfTrue(T result)` 结果为 False 时，返回参数 (结果为 True 时，返回参数类型默认值)
- 增加`int`扩展方法:
  - `IsEven()` 是否偶数
  - `IsOdd()` 是否奇数
  - `Times(Action action)` 执行次数操作，次数基于原 int 值
  - `Times(Action<int> action)` 执行次数操作，次数基于原 int 值
  - `IsInRange(int min, int max)` 是否在指定范围内
- 增加`long`扩展方法:
  - `IsEven()` 是否偶数
  - `IsOdd()` 是否奇数
  - `Times(Action action)` 执行次数操作，次数基于原 int 值
  - `Times(Action<long> action)` 执行次数操作，次数基于原 int 值
  - `IsInRange(long min, long max)` 是否在指定范围内

#### Changed / 变更

- 对扩展方法类名进行规范重命名
  - 统一命名空间 `Lett.Extensions.Exceptions`
  - `IEnumerableExtensions` IEnumerable 扩展方法
  - `DataColumnCollectionExtensions` DataColumnCollection 扩展方法
  - `DataRowExtensions` DataRow 扩展方法
  - `DataTableExtensions` DataTable 扩展方法
  - `DateTimeExtensions` DateTime 扩展方法
  - `EnumExtensions` Enum 扩展方法
  - `IntExtensions` int 扩展方法
  - `ObjectExtensions` object 扩展方法
  - `StringExtensions` string 扩展方法
  - `TypeExtensions` type 扩展方法
- 类名变更：
  - `LettExtensionsDataTableException` -> `DataTableException`

### 0.1.7 (2019-04-28)

#### Features / 新增功能

- 增加 `System.String` 拓展方法
  - `Format(object[] args)` 格式化
  - `Left(int length)` 从左侧返回指定长度的字符串
  - `Right(int length)` 从右侧返回指定长度的字符串

### 0.1.6 (2019-04-25)

#### Features / 新增功能

- 增加 `String.IsNullOrWhiteSpace()` 是否 null 或空白
- 增加 `String.ContainsAll()` 是否全部包含，默认不区分大小写
- 增加 `String.ContainsAny()` 是否包含任意一个，默认不区分大小写

### 0.1.5 (2019-04-24)

#### Features / 新增功能

- 增加 DataTable DataRow 转换实体方法
- 增加 DataColumnCollectionTest.AddRange 方法
- 获取 DataColumn 可枚举对象 `ColumnsEnumerable()`
- 获取 Column 的数据类型 `GetColumnDataType(string columnName)`
- 获取 Column 的数据类型 `GetColumnDataType(int index)`

#### Changed / 变更

- `DataRow.Cell<T>()` 系列方法，泛型约定调整为 实现了 `IConvertible` 接口的类型
- `Object.To<T>()` 方法的泛型约定调整为 实现了 `IConvertible` 接口的类型
- 实现了 `IConvertible` 接口的类型 如：Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等

### 0.1.4 (2019-04-14)

#### Features / 新增功能

- 增加 Object.IsDBNull 方法

#### Refactored / 优化重构

- 调整 Int32.GetEnumDescription()方法位置，使用无感知

---

### X.X.X (2019-04-13)

#### Features / 新增功能

-

#### Changed / 变更

-

#### Fixed / 修复

-

#### Removed / 删除

-

#### Deprecated / 即将删除

-

#### Refactored / 优化重构

-
