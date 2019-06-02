#tool Cake.CoreCLR
#addin "Cake.DocFx"
#tool "docfx.console"
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
var opencoverReportFile = $"{testResultPath}/converage/opencover.xml"; // 覆盖率
var vSTestReportFile = $"{testResultPath}/vstest.xml"; // 测试结果

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

Task("Testing-vstest")
  .Does(() => {
    Information($"测试:{testProj}");
    // VSTEST
    DotNetCoreTest(testProj, new DotNetCoreTestSettings {
        Configuration = configuration,
        NoBuild = false,
        VSTestReportPath = vSTestReportFile,
    });
  });

Task("CodeCoverage-openconver")
  .Does(() =>
{
    // code converage - open conver
    DotNetCoreTest(testProj, new DotNetCoreTestSettings{
          Configuration = configuration,
          NoBuild = false,
          ArgumentCustomization = args => args
            .Append("/p:CollectCoverage=true")
            .Append($"/p:CoverletOutputFormat=opencover")
            .Append($"/p:CoverletOutput=../../{opencoverReportFile}")
    });
});

Task("Upload-Coverage")
    .Does(() =>
{
    // Upload coverage reports.
    // Information($"upload {opencoverReportFile}");
    // var output = StartProcess("bash", "./upload.sh");
    // Information($"上传成功: {output}");
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
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Testing-vstest")
  .IsDependentOn("CodeCoverage-openconver")
  .IsDependentOn("Upload-Coverage")
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

Task("Test")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  // .IsDependentOn("Testing-vstest")
  // .IsDependentOn("CodeCoverage-openconver")
  // .IsDependentOn("PackNuGet")
  .IsDependentOn("Docfx")
  .Does(() => {
    Information("Test");
  });

RunTarget(target);
