# Change log / 更新日志

## 0.1.6 (2019-04-25)

### Features / 新增功能

- 增加 String.IsNullOrWhiteSpace() 是否 null 或空白
- 增加 String.ContainsAll() 是否全部包含，默认不区分大小写
- 增加 String.ContainsAny() 是否包含任意一个，默认不区分大小写

## 0.1.5 (2019-04-24)

### Features / 新增功能

- DataRow.Cell<T>() 系列方法，增加泛型约定为 实现了 IConvertible 接口的类型 如：Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等
- 增加 Object.To<T>() 方法的泛型约束为 实现了 IConvertible 接口的类型 如：Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等
- 增加 DataTable DataRow 转换实体方法
- 增加 DataColumnCollectionTest.AddRange 方法
- 获取 DataColumn 可枚举对象 ColumnsEnumerable()
- 获取 Column 的数据类型 GetColumnDataType(string columnName)
- 获取 Column 的数据类型 GetColumnDataType(int index)

## 0.1.4 (2019-04-14)

### Features / 新增功能

- 增加 Object.IsDBNull 方法

### Refactored / 优化重构

- 调整 Int32.GetEnumDescription()方法位置，使用无感知

---

## X.X.X (2019-04-13)

### Features / 新增功能

-

### Changed / 变更

-

### Fixed / 修复

-

### Removed / 删除

-

### Deprecated / 即将删除

-

### Refactored / 优化重构

-
