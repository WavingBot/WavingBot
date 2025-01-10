using System.Reflection;
using log4net;
using log4net.Config;
using WavingBot.Plugin;

[assembly: XmlConfigurator(ConfigFile = "log4net.xml", Watch = true)]
namespace WavingBot;

internal class Program
{
    public static readonly string Version = "0.0.1";
    internal static readonly ILog Logger = LogManager.GetLogger("WavingBot");
    
    public static void Main(string[] args)
    {
        Logger.Info($"WavingBot v{Version} starting up...");
        
        // scan all dll file in the plugins directory
        Directory.CreateDirectory("plugins");
        foreach (string file in Directory.GetFiles("plugins", "*.dll"))
        {
            try
            {
                Assembly assembly = Assembly.LoadFrom(file);
                foreach (Type type in assembly.GetTypes())
                {
                    if (!type.GetInterfaces().Contains(typeof(IPlugin))) return;
                    IPlugin plugin = (IPlugin)Activator.CreateInstance(type);
                    plugin.OnLoad();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load plugin from {file}: {ex.Message}");
            }
        }
    }
}