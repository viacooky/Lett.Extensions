#module nuget:?package=Cake.DotNetTool.Module&version=0.3.0
#tool dotnet:?package=coverlet.console&version=1.5.3
#tool nuget:?package=Cake.CoreCLR&version=0.33.0
#addin nuget:?package=Cake.DocFx&version=0.13.0
#tool nuget:?package=docfx.console&version=2.42.4
#tool nuget:?package=Codecov&version=1.7.2
#addin nuget:?package=Cake.Codecov&version=0.7.0
#addin nuget:?package=Cake.Coverlet&version=2.3.4
// ------------------------------------------------------------------
// 参数定义
// ------------------------------------------------------------------
var target = Argument("target", "Default"); // 
var configuration = Argument("configuration", "Release"); // 编译配置
var nugetVersion = Argument("nugetVersion", "0.0.1"); // NuGet 版本
var assemblyVerion = Argument("assemblyVerion", "0.0.0"); // assemblyVersion
var buildProj = "./src/Lett.Extensions/Lett.Extensions.csproj"; // project 文件
var testProj = "./src/Lett.Extensions.Test/Lett.Extensions.Test.csproj"; // test project 文件
var releasePath = Directory("./src/Lett.Extensions/bin") + Directory(configuration); // 编译目录
var nugetPackBuilPath = Directory("./nugetPacks"); // nuget包编译目录
var testResultPath = "./TestResults"; // 测试结果目录
// 测试结果
var converageReportPath = $"{testResultPath}/coverage"; // 覆盖率目录字符串
var converageReportDir = MakeAbsolute(Directory(converageReportPath)); // 覆盖率目录对象
var vsTestReportPath = $"{testResultPath}/vstest";
var vsTestReportDir = Directory(vsTestReportPath);
var vsTestReportFile = new FilePath($"{vsTestReportPath}/TestResult.xml");

// ------------------------------------------------------------------
// 子任务
// ------------------------------------------------------------------

Task("Clean")
  .Does(() => {
    Information("清理");
    DotNetCoreClean(buildProj);
    DotNetCoreClean(testProj);
    CleanDirectories(releasePath);
    CleanDirectories(nugetPackBuilPath);
    CleanDirectories(testResultPath);
  });

Task("Restore")
  .Does(() => {
    Information("还原Nuget包");
    DotNetCoreRestore(buildProj);
    DotNetCoreRestore(testProj);
  });

Task("Build")
  .Does(() => {
    Information($"编译:{buildProj}");
    DotNetCoreBuild(buildProj, new DotNetCoreBuildSettings {
      Configuration = configuration,
      ArgumentCustomization = args => args
      .Append($"/p:Version={nugetVersion}")
      .Append($"/p:AssemblyVersion={assemblyVerion}")
    });
  });

// ------------------------------------------------------------------
// Code quality
// ------------------------------------------------------------------

Task("dotNet-Test")
  .Does(() => {
    Information($"测试:{testProj}");
    // VSTEST
    var testSettings = new DotNetCoreTestSettings {
        Configuration = configuration,
        NoBuild = false,
        VSTestReportPath = vsTestReportFile,
    };
    DotNetCoreTest(testProj, testSettings);
  });

// 代码覆盖率
Task("Code-Converage")
    .Does(() => {
      EnsureDirectoryExists(converageReportPath);
      var coverletSettings = new CoverletSettings {
          CollectCoverage = true,
          CoverletOutputFormat = CoverletOutputFormat.opencover | CoverletOutputFormat.cobertura | CoverletOutputFormat.json,
          CoverletOutputDirectory = converageReportPath,
          CoverletOutputName = "Coverage"
      };
      DotNetCoreBuild(testProj, new DotNetCoreBuildSettings {Configuration = "Debug"});
      Coverlet(new FilePath(testProj), coverletSettings);
      // Codecov($"{curDir}/coverage.opencover.xml", "e94ad7ee-4f5b-4127-9f1d-2bd91e63cb11");
    });

// ------------------------------------------------------------------
// DocFx
// ------------------------------------------------------------------

Task("Docfx")
  .Does(() =>
{
  DocFxMetadata("./docfx/docfx.json");
  DocFxBuild("./docfx/docfx.json");
});

// ------------------------------------------------------------------
// publish
// ------------------------------------------------------------------

Task("PackNuGet")
  .Does(() => {
    Information($"打包NuGet:{buildProj}");
    DotNetCorePack(buildProj, new DotNetCorePackSettings {
      Configuration = configuration,
        OutputDirectory = nugetPackBuilPath,
        IncludeSymbols = false,
        ArgumentCustomization = args => args
        .Append($"/p:Version={nugetVersion}")
        .Append($"/p:AssemblyVersion={assemblyVerion}")
    });
  });

// ------------------------------------------------------------------
// 任务集
// ------------------------------------------------------------------
Task("Default")
  // .IsDependentOn("Clean")
  // .IsDependentOn("Restore")
  // .IsDependentOn("Build")
  // .IsDependentOn("dotNet-Test")
  // .IsDependentOn("Build-OpenCover")
  .Does(() => {
    Information("默认构建完成");
  });

Task("azure")
  .IsDependentOn("Clean")
  .IsDependentOn("Build")
  .IsDependentOn("PackNuGet") 
  .IsDependentOn("Docfx")
  .Does(() =>
{
  // test 和 Code Coverage 使用 Azure Pipelines 的 Task 完成
  // 每次都打NuGet包，使用 Azure Pipelines 手工发布
  Information("Azure任务完成");
});

Task("codecoverage")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("dotNet-Test")
  .IsDependentOn("Code-Converage")
  .Does(() => {
    Information("Code Coverage 生成完成");
  });

RunTarget(target);
