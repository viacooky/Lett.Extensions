#tool "nuget:?package=JetBrains.dotCover.CommandLineTools"
#tool nuget:?package=Codecov
#addin nuget:?package=Cake.Codecov
#tool "nuget:?package=xunit.runner.console"
// ------------------------------------------------------------------
// 参数定义
// ------------------------------------------------------------------
var target = Argument("target", "Default");// 任务命名
var configuration = Argument("configuration", "Release"); // 编译配置
var buildProj = "./src/Lett.Extensions/Lett.Extensions.csproj"; // project 文件
var testProj = "./src/Lett.Extensions.Test/Lett.Extensions.Test.csproj"; // test project 文件
var releasePath = Directory("./src/Lett.Extensions/bin") + Directory(configuration); // 编译目录

// ------------------------------------------------------------------
// 子任务
// ------------------------------------------------------------------

Task("Clean") 
  .Does(() =>
{
  Information("清理");
  DotNetCoreClean(buildProj);
  DotNetCoreClean(testProj);
  CleanDirectories(releasePath);
});

Task("Restore") 
  .Does(() =>
{
  Information("还原Nuget包");
  DotNetCoreRestore(buildProj);
  DotNetCoreRestore(testProj);
});

Task("Build")
  .Does(() =>
{
  Information($"编译:{buildProj}");
  DotNetCoreBuild(buildProj,  new DotNetCoreBuildSettings
     {
         Configuration = configuration,
     });
  DotNetCoreBuild(testProj,  new DotNetCoreBuildSettings
  {
      Configuration = configuration,
  });
});

Task("Testing")
  .Does(() =>
{
  Information($"测试:{testProj}");
  // XUnit2("./src/Lett.Extensions.Test/bin/Release/**/*.Test.dll", new XUnit2Settings{
  //   //Parallelism = ParallelismOption.,
  //       XmlReport = true,
  //       OutputDirectory = "./testReport",
  // });
  DotNetCoreTest(testProj, new DotNetCoreTestSettings
     {
         Configuration = configuration,
     });
});

Task("Upload-Coverage")
    .Does(() =>
{
    // Upload a coverage report by providing the Codecov upload token.
    Codecov("coverage.xml", "8446c608-924a-43e3-b49c-fe6a44607e40");
});

// ------------------------------------------------------------------
// 启动配合
// ------------------------------------------------------------------
Task("Default")
  .IsDependentOn("Clean")
  .IsDependentOn("Restore")
  .IsDependentOn("Build")
  .IsDependentOn("Testing")
  // .IsDependentOn("Upload-Coverage")
  .Does(() =>
{
  Information("默认构建完成");
});

RunTarget(target);
