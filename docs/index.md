# Lett.Extensions

![Build Status](https://dev.azure.com/viacooky/Lett.Extensions/_apis/build/status/Lett.Extensions%20Push%20NuGet?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Lett.Extensions.svg)](https://www.nuget.org/packages/Lett.Extensions/)
![Azure DevOps tests (compact)](https://img.shields.io/azure-devops/tests/viacooky/Lett.Extensions/9.svg)
![Azure DevOps coverage (branch)](https://img.shields.io/azure-devops/coverage/viacooky/Lett.Extensions/9/master.svg?color=9cf)
![GitHub](https://img.shields.io/github/license/viacooky/Lett.Extensions.svg)
[![996.icu](https://img.shields.io/badge/link-996.icu-red.svg)](https://996.icu)

Common C# extension methods collection

NuGet: [https://www.nuget.org/packages/Lett.Extensions/](https://www.nuget.org/packages/Lett.Extensions/)

GitHub: [https://github.com/viacooky/Lett.Extensions/](https://github.com/viacooky/Lett.Extensions/)

## How to use

- Package Manager

  `Install-Package Lett.Extensions`

- Nuget cli

  `nuget install Lett.Extensions`

- .Net cli

  `dotnet add package Lett.Extensions`

## Extension Methods

- [System.Array](./ExtensionMethods/System.Array/index.md)
- [System.Byte](./ExtensionMethods/System.Byte/index.md)
- [System.Collections.Generic](./ExtensionMethods/System.Collections.Generic/index.md)
- [System.Data](./ExtensionMethods/System.Data/index.md)
- [System.DateTime](./ExtensionMethods/System.DateTime/index.md)
- [System.Enum](./ExtensionMethods/System.Enum/index.md)
- [System.Int32](./ExtensionMethods/System.Int32/index.md)
- [System.Int32](./ExtensionMethods/System.Int64/index.md)
- [System.Object](./ExtensionMethods/System.Object/index.md)
- [System.String](./ExtensionMethods/System.String/index.md)
- [System.Type](./ExtensionMethods/System.Type/index.md)

## Change Logs

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

### 0.1.8 (2019-05-13)

#### Features / 新增功能

- 增加`string`扩展方法
- 增加`byte[]`扩展方法
- 增加`ICollection`扩展方法
- 增加`bool`扩展方法
- 增加`int`扩展方法
- 增加`long`扩展方法

#### Features / 新增功能

- 增加`string`扩展方法
- 增加`byte[]`扩展方法
- 增加`ICollection`扩展方法
- 增加`bool`扩展方法
- 增加`int`扩展方法
- 增加`long`扩展方法

#### Changed / 变更

- 对扩展方法类名进行规范重命名

### 0.1.7 (2019-04-28)

#### Features / 新增功能

- 增加 `System.String` 拓展方法

### 0.1.6 (2019-04-25)

#### Features / 新增功能

- 增加 `System.String` 拓展方法

[more...](./CHANGELOG.md)
