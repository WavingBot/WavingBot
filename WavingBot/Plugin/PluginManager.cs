using System.Reflection;

namespace WavingBot.Plugin;

public class PluginManager
{
    public List<IPlugin> Plugins { get; } = new();

    public void RegisterAllPlugins()
    {
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
                    Plugins.Add(plugin);
                }
            }
            catch (Exception ex)
            {
                WavingBot.Logger.Error($"Failed to load plugin from {file}: {ex.Message}");
            }
        }
    }
}