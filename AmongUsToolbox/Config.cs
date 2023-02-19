using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace AmongUsToolbox
{ 
    public class Config : AppSettings<Config>
    {
        public bool DebugMode = false;
        public string AmongUsFolderPath = null;
        public ModsConfig Mods = new();
        public RegionsConfig Regions = new();
        public bool UnsavedRegionsChanges = false;
    }

    public class ModsConfig
    {
        public int CurrentModIdx = 0;
        public List<ModConfig> Mods = new();

        public ModConfig GetCurrentMod()
        {
            return Mods.Find(mod => mod.Id == CurrentModIdx);
        }
    }

    public class ModConfig
    {
        public int? Id = null;
        public string Owner = null;
        public string Repository = null;

        public static ModConfig GetVanilla()
        {
            return new ModConfig { Id = 0, Owner = @"Innersloth", Repository = "Among Us"};
        }
    }

    public class RegionsConfig
    {
        public int CurrentRegionIdx = 0;
        public List<RegionConfig> Regions = new();
    }

    public class RegionConfig
    {
        [JsonProperty(PropertyName = "$type")]
        public string Type = "StaticHttpRegionInfo, Assembly-CSharp";

        public string Name;
        public string PingServer;
        public List<RegionServer> Servers = new ();
        public int TranslateName = 1500;
    }

    public class RegionServer
    {
        public string Name = "Http-1";
        public string Ip;
        public int Port;
        public bool UseDtls = true;
        public int Players = 0;
        public int ConnectionFailures = 0;
    }
    
    public class AppSettings<T> where T : new()
    {
        private const string DEFAULT_FILENAME = "settings.json";

        public static readonly T Data = Load();

        public void Save(string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
        }

        public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings));
        }

        private static T Load(string fileName = DEFAULT_FILENAME)
        {
            T t = new T();
            if(File.Exists(fileName))
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
            return t;
        }
    }
}