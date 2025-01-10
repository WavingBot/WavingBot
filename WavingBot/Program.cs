using System.Reflection;
using log4net;
using log4net.Config;
using WavingBot.Plugin;

[assembly: XmlConfigurator(ConfigFile = "log4net.xml", Watch = true)]
namespace WavingBot;

internal static class Program
{
    public static void Main(string[] args)
    {
        (new WavingBot()).Init();
    }
}