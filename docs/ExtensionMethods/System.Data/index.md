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

| Method             | Description                                                     |
| ------------------ | --------------------------------------------------------------- |
| `HasRows()`        | 是否存在数据行                                                  |
| `FirstRow()`       | 获取首行, 不存在数据行时，返回 LettExtensionsDataTableException |
| `LastRow()`        | 获取末行, 不存在数据行时，返回 LettExtensionsDataTableException |
| `RowsEnumerable()` | 获取 DataRow 可枚举对象                                         |

### Examples

```C#

```
