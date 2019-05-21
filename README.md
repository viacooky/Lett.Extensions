![](docs/images/logo.png)

![Build Status](https://dev.azure.com/viacooky/Lett.Extensions/_apis/build/status/Lett.Extensions%20Push%20NuGet?branchName=master)
[![Nuget](https://img.shields.io/nuget/v/Lett.Extensions.svg)](https://www.nuget.org/packages/Lett.Extensions/)
![Nuget](https://img.shields.io/nuget/dt/Lett.Extensions.svg)
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

- [System.Array](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Array/)
- [System.Boolean](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Boolean/)
- [System.Byte](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Byte/)
- [System.Collections.Generic](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Collections.Generic/)
- [System.Data](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Data/)
- [System.DateTime](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.DateTime/)
- [System.Enum](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Enum/)
- [System.Int32](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Int32/)
- [System.Int32](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Int64/)
- [System.Object](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Object/)
- [System.String](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.String/)
- [System.Type](https://viacooky.github.io/Lett.Extensions/ExtensionMethods/System.Type/)

[more...](https://viacooky.github.io/Lett.Extensions/)

## Change log

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

- 增加`string`扩展方法
- 增加`byte[]`扩展方法
- 增加`ICollection`扩展方法
- 增加`bool`扩展方法
- 增加`int`扩展方法
- 增加`long`扩展方法

#### Changed / 变更

- 对扩展方法类名进行规范重命名

[more...](https://viacooky.github.io/Lett.Extensions/CHANGELOG.html)

## Thanks

Inspired by [Z.ExtensionMethods](https://github.com/zzzprojects/Z.ExtensionMethods)
