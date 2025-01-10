using log4net;
using WavingBot.Plugin;

namespace WavingBot;

public class WavingBot
{
    public static readonly string Version = "0.0.1";
    internal static readonly ILog Logger = LogManager.GetLogger("WavingBot");
    public PluginManager PluginManager { get; } = new();
    
    public void Init()
    {
        Logger.Info($"WavingBot v{Version} starting up...");
        PluginManager.RegisterAllPlugins();
    }
}