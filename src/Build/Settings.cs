using Microsoft.Extensions.Configuration;

namespace Build;

public class Settings {
    public DirectoryInfo? RootDirectory { get; set; }
    
    public static Task<Settings> Load()
    {
        var config = new ConfigurationBuilder()
            .Build();

        var settings = new Settings();
        config.Bind(settings);
        settings.RootDirectory = GetRootDirectory();
        
        return Task.FromResult(settings);
    }

    private static DirectoryInfo? GetRootDirectory()
    {
        var dirInfo = new DirectoryInfo(AppContext.BaseDirectory);
        while (dirInfo != null)
        {
            if (dirInfo.Name == "BLabbR")
            {
                return dirInfo;
            }

            dirInfo = dirInfo.Parent;
        }

        throw new InvalidOperationException("BLabbR dir not found");
    }
}