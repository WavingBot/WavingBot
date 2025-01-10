using log4net;

namespace WavingBot.Plugin;

public interface IPlugin
{
    string Name { get; }
    string Version { get; }
    string Description { get; }
    ILog Logger { get; }
    
    void OnLoad();
    void OnUnload();
}