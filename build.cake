#tool Cake.CoreCLR
// ------------------------------------------------------------------
// 参数定义
// ------------------------------------------------------------------
var target = Argument("target", "Default"); // 任务命名
var configuration = Argument("configuration", "Release"); // 编译配置
var packVer = Argument("packVer", "0.0.1"); // NuGet 版本
var buildProj = "./src/Lett.Extensions/Lett.Extensions.csproj"; // project 文件
var testProj = "./src/Lett.Extensions.Test/Lett.Extensions.Test.csproj"; // test project 文件
var releasePath = Directory("./src/Lett.Extensions/bin") + Directory(configuration); // 编译目录
var nugetPackBuilPath = Directory("./nugetPacks"); // nuget包编译目录
var testResultPath = "../../TestResults/coverage.xml"; // 测试结果目录

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
        .Append($"/p:Version={packVer}")
        .Append($"/p:AssemblyVersion={packVer}")
    });
  });

Task("Testing")
  .Does(() => {
    Information($"测试:{testProj}");
    // XUnit2("./src/Lett.Extensions.Test/bin/Release/**/*.Test.dll", new XUnit2Settings{
    //   //Parallelism = ParallelismOption.,
    //       XmlReport = true,
    //       OutputDirectory = "./testReport",
    // });
    DotNetCoreTest(testProj, new DotNetCoreTestSettings {
      Configuration = configuration,
        NoBuild = false,
        ArgumentCustomization = args => args
        .Append("/p:CollectCoverage=true")
        //.Append($"/p:CoverletOutputFormat=opencover")
        .Append($"/p:CoverletOutput={testResultPath}")
    });
  });

Task("Upload-Coverage-Report")
    .Does(() => {
    // Codecov("./TestResults/coverage.xml","8446c608-924a-43e3-b49c-fe6a44607e40");
  });
Task("PackNuGet")
  .Does(() => {
    Information($"打包NuGet:{buildProj}");
    DotNetCorePack(buildProj, new DotNetCorePackSettings {
      Configuration = configuration,
        OutputDirectory = nugetPackBuilPath,
        IncludeSymbols = true,
        ArgumentCustomization = args => args
        .Append($"/p:Version={packVer}")
        .Append($"/p:AssemblyVersion={packVer}")
    });
  });


// ------------------------------------------------------------------
// 启动任务
// ------------------------------------------------------------------
Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Testing")
  .Does(() => {
    Information("默认构建完成");
  });

Task("Publish")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Testing")
  .IsDependentOn("PackNuGet")
  .Does(() => {
    Information("发布完成");
  });

Task("tt")
  // .IsDependentOn("Clean")
  // .IsDependentOn("Restore")
  // .IsDependentOn("Build")
  .IsDependentOn("Testing")
  .IsDependentOn("Upload-Coverage-Report")
  .Does(() => {
    Information("脚本测试");

  });

RunTarget(target);
