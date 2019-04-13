# System.Object

## System.Object

### Methods

| Method                              | Description                                          |
| ----------------------------------- | ---------------------------------------------------- |
| `To<T>()`                           | 对象转换,失败则返回 default(T)                       |
| `To<T>(Func<T> func)`               | 对象转换,失败则返回 func                             |
| `To<T>(T defaultValue)`             | 对象转换,失败则返回 defaultValue                     |
| `IsAssignableFrom<T>()`             | 返回 `object.IsAssignableFrom(typeof(T))`            |
| `IsAssignableFrom(Type targetType)` | 返回 `object.GetType().IsAssignableFrom(targetType)` |
| `As<T>()`                           | 对象强转换,失败则返回 default(T)                     |
| `As<T>(Func<T> func)`               | 对象强转换,失败则返回 func                           |
| `As<T>(T defaultValue)`             | 对象强转换,失败则返回 defaultValue                   |
| `DeepClone<T>()`                    | 深复制                                               |
| `IsDBNull()`                        | 是否 DBNull                                          |

### Examples

```C#

```
