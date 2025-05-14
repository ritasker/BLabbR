using CliWrap;
using Microsoft.Extensions.Logging;

namespace Build;

public static class Helpers {
    public static ILogger GetLogger() =>
        LoggerFactory
            .Create(builder =>
            {
                builder.AddSimpleConsole(
                    options =>
                    {
                        options.IncludeScopes = true;
                        options.SingleLine = true;
                        options.TimestampFormat = "HH:mm:ss ";
                    }
                );
            })
            .CreateLogger("BLabbR.Build");

    public static Func<string, string, Task<CommandResult>> GetCliRunner()
    {
        var standardPipelineTarget = PipeTarget.ToStream(Console.OpenStandardOutput());
        var errorPipeTarget = PipeTarget.ToStream(Console.OpenStandardError());

        // Wrap CliWrap with defaults
        Task<CommandResult> Run(string targetFilePath, string arguments) =>
            Cli.Wrap(targetFilePath)
                .WithStandardOutputPipe(standardPipelineTarget!)
                .WithStandardErrorPipe(errorPipeTarget!)
                .WithArguments(arguments)
                .ExecuteAsync();

        return Run;
    }

    public static DirectoryInfo GetSubDirectory(this DirectoryInfo? directoryInfo, string subDirectoryName)
    {
        var subdirectory = Path.Combine(directoryInfo.FullName, subDirectoryName);
        return new DirectoryInfo(subdirectory);
    }
}