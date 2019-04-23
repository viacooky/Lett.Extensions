# System.Data

## System.Data.DataRow

### Methods

| Method                                       | Description                                    |
| -------------------------------------------- | ---------------------------------------------- |
| `Cell<T>(string columnName)`                 | 获取当前行中某个列的值,失败则返回 default(T)   |
| `Cell<T>(string columnName, Func<T> func)`   | 获取当前行中某个列的值,失败则返回 func         |
| `Cell<T>(string columnName, T defaultValue)` | 获取当前行中某个列的值,失败则返回 defaultValue |

### Examples

```C#

```

## System.Data.DataTable

### Methods

| Method                                 | Description                                                                         |
| -------------------------------------- | ----------------------------------------------------------------------------------- |
| `HasRows()`                            | 是否存在数据行                                                                      |
| `FirstRow()`                           | 获取首行, 不存在数据行时，抛出 LettExtensionsDataTableException                     |
| `LastRow()`                            | 获取末行, 不存在数据行时，抛出 LettExtensionsDataTableException                     |
| `RowsEnumerable()`                     | 获取 DataRow 可枚举对象                                                             |
| `ColumnsEnumerable()`                  | 获取 DataColumn 可枚举对象                                                          |
| `GetColumnDataType(string columnName)` | 获取 Column 的数据类型，columnName 不存在时，抛出 LettExtensionsDataTableException  |
| `GetColumnDataType(int index)`         | 获取 Column 的数据类型，index 超出数组范围时，抛出 LettExtensionsDataTableException |

### Examples

```C#

```
