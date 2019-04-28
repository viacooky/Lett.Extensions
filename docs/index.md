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

- [System.Collections.Generic](./ExtensionMethods/System.Collections.Generic/index.md)
- [System.Data](./ExtensionMethods/System.Data/index.md)
- [System.DateTime](./ExtensionMethods/System.DateTime/index.md)
- [System.Enum](./ExtensionMethods/System.Enum/index.md)
- [System.Int32](./ExtensionMethods/System.Int32/index.md)
- [System.Object](./ExtensionMethods/System.Object/index.md)
- [System.String](./ExtensionMethods/System.String/index.md)
- [System.Type](./ExtensionMethods/System.Type/index.md)

## Change Logs

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

[more...](./CHANGELOG.md)
