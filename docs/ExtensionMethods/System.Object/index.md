# System.Object

## System.Object

### Methods

| Method                              | Description                                                                                                                                                                                                                 |
| ----------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| `To<T>()`                           | 对象转换, 失败则返回 default(T) (泛型约束为实现了 IConvertible 的类型: Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等)   |
| `To<T>(Func<T> func)`               | 对象转换, 失败则返回 func (泛型约束为实现了 IConvertible 的类型: Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等)         |
| `To<T>(T defaultValue)`             | 对象转换, 失败则返回 defaultValue (泛型约束为实现了 IConvertible 的类型: Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等) |
| `IsAssignableFrom<T>()`             | 返回 `object.IsAssignableFrom(typeof(T))`                                                                                                                                                                                   |
| `IsAssignableFrom(Type targetType)` | 返回 `object.GetType().IsAssignableFrom(targetType)`                                                                                                                                                                        |
| `As<T>()`                           | 对象强转换, 失败则返回 default(T)                                                                                                                                                                                           |
| `As<T>(Func<T> func)`               | 对象强转换, 失败则返回 func                                                                                                                                                                                                 |
| `As<T>(T defaultValue)`             | 对象强转换, 失败则返回 defaultValue                                                                                                                                                                                         |
| `DeepClone<T>()`                    | 深复制                                                                                                                                                                                                                      |
| `IsDBNull()`                        | 是否 DBNull                                                                                                                                                                                                                 |

### Examples

```C#

```
