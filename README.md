# Lett.Extensions

![Build Status](https://dev.azure.com/viacooky/Lett.Extensions/_apis/build/status/Lett.Extensions%20Push%20NuGet?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Lett.Extensions.svg)](https://www.nuget.org/packages/Lett.Extensions/)
![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/viacooky/Lett.Extensions/9.svg)
![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/viacooky/Lett.Extensions/9/master.svg?color=9cf)
![GitHub](https://img.shields.io/github/license/viacooky/Lett.Extensions.svg)
[![996.icu](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)

---

Common C# extensions methods collection

NuGet: https://www.nuget.org/packages/Lett.Extensions/

Project Site https://viacooky.github.io/Lett.Extensions/

## How to use

- Package Manager

  `Install-Package Lett.Extensions`

- Nuget cli

  `nuget install Lett.Extensions`

- .Net cli

  `dotnet add package Lett.Extensions`

## Documents

- [System.Collections.Generic](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Collections.Generic/)
- [System.Data](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Data/)
- [System.DateTime](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.DateTime/)
- [System.Enum](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Enum/)
- [System.Int32](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Int32/)
- [System.Object](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Object/)
- [System.String](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.String/)
- [System.Type](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Type/)

[more...](https://viacooky.github.io/Lett.Extensions/)

## Change log

### 0.1.5 (2019-04-24)

#### Features / 新增功能

- DataRow.Cell<T>() 系列方法，增加泛型约定为 实现了 IConvertible 接口的类型 如：Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等
- 增加 Object.To<T>() 方法的泛型约束为 实现了 IConvertible 接口的类型 如：Boolean, Byte, Char, DateTime, System.DBNull, Decimal, Double, System.Enum, Int16, Int32, Int64, SByte, Single, String, UInt16, UInt32, UInt64 等
- 增加 DataTable DataRow 转换实体方法
- 增加 DataColumnCollectionTest.AddRange 方法
- 获取 DataColumn 可枚举对象 ColumnsEnumerable()
- 获取 Column 的数据类型 GetColumnDataType(string columnName)
- 获取 Column 的数据类型 GetColumnDataType(int index)

### 0.1.4 (2019-04-14)

#### Features / 新增功能

- 增加 Object.IsDBNull 方法

#### Refactored / 优化重构

- 调整 Int32.GetEnumDescription()方法位置，使用无感知

[more...](https://viacooky.github.io/Lett.Extensions/CHANGELOG.html)

## Thanks

Inspired by [Z.ExtensionMethods](https://github.com/zzzprojects/Z.ExtensionMethods)
