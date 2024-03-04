using Microsoft.Extensions.Configuration;

namespace Build;

public class Settings {
    public DirectoryInfo RootDirectory { get; set; }
    
    public static async Task<Settings> Load()
    {
        var config = new ConfigurationBuilder()
            .Build();

        var settings = new Settings();
        config.Bind(settings);
        settings.RootDirectory = GetRootDirectory();
        
        return settings;
    }

    private static DirectoryInfo GetRootDirectory()
    {
        var dirInfo = new DirectoryInfo(AppContext.BaseDirectory);
        while (dirInfo != null)
        {
            if (dirInfo.Name == "GabbR")
            {
                return dirInfo;
            }

            dirInfo = dirInfo.Parent;
        }

        throw new InvalidOperationException("GabbR dir not found");
    }
}