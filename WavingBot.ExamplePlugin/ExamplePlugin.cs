using System.Diagnostics.CodeAnalysis;
using log4net;
using WavingBot.Plugin;

namespace WavingBot.ExamplePlugin;

[SuppressMessage("Style", "CS0169", Justification = "ExamplePlugin is used by the plugin system.")]
public class ExamplePlugin : IPlugin
{
    public string Name => "Example Plugin";
    public string Version => "0.0.1";
    public string Description => "An example plugin for WavingBot.";
    public ILog Logger => LogManager.GetLogger(Name);
    
    public void OnLoad()
    {
        Logger.Info($"{Name} v{Version} loaded successfully.");
    }

    public void OnUnload()
    {
        Logger.Info($"{Name} v{Version} unloaded successfully.");
    }
}
