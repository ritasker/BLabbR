using Build;
using CliWrap.Exceptions;
using Microsoft.Extensions.Logging;
using static Build.Helpers;
using static Bullseye.Targets;

var logger = GetLogger();
var settings = await Settings.Load();
var run = GetCliRunner();
var srcDir = settings.RootDirectory.GetSubDirectory("src");

logger.LogInformation($"srcDir={srcDir}");

Target(
    "build",
    new[]
    {
        Path.Join(srcDir.ToString(), "GabbR")
    },
    async projectPath => { await run("dotnet", $"build {projectPath} -c Release"); }
);

Target("default", DependsOn("build"));

await RunTargetsAndExitAsync(args, ex => ex is CommandExecutionException);