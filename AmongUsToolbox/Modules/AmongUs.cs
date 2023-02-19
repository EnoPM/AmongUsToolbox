using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Newtonsoft.Json;

namespace AmongUsToolbox.Modules;

public static class AmongUs
{
    private const string AmongUsExecutable = "Among Us.exe";
    private const string RegionInfoFileName = "regionInfo.json";

    private static bool _filterProcess(Process process)
    {
        try
        {
            if (process.MainModule == null) return false;
            return process.MainModule.FileName == GetExecutablePath();
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static bool IsRunning()
    {
        return Config.Data.AmongUsFolderPath != null &&
               Process.GetProcesses().Any(_filterProcess);
    }

    public static string GetExecutablePath()
    {
        return Path.Combine(Config.Data.AmongUsFolderPath, AmongUsExecutable);
    }

    public static string GetRegionInfoFilePath()
    {
        return Path.Combine(Helpers.GetLocalLowDirectoryPath(), "Innersloth", "Among Us", RegionInfoFileName);
    }

    public static RegionsConfig GetLocalRegions()
    {
        RegionsConfig t = new RegionsConfig();
        if (File.Exists(GetRegionInfoFilePath()))
            t = JsonConvert.DeserializeObject<RegionsConfig>(File.ReadAllText(GetRegionInfoFilePath()));
        return t;
    }

    public static void UninstallMod()
    {
        if (Config.Data.Mods.CurrentModIdx != 0)
        {
            var mod = Config.Data.Mods.Mods.Find(mod => mod.Id == Config.Data.Mods.CurrentModIdx);
            var modDir = Path.Combine("mods", mod.Owner.ToLower(), mod.Repository.ToLower());
            var files = Directory.GetFiles(modDir);
            var directories = Directory.GetDirectories(modDir);
            foreach (var filePath in files)
            {
                var file = new FileInfo(filePath);
                var targetPath = Path.Combine(Config.Data.AmongUsFolderPath, file.Name);
                if (!File.Exists(targetPath)) continue;
                File.Delete(targetPath);
            }

            foreach (var directoryPath in directories)
            {
                var directory = new DirectoryInfo(directoryPath);
                var targetPath = Path.Combine(Config.Data.AmongUsFolderPath, directory.Name);
                if (!Directory.Exists(targetPath)) continue;
                Directory.Delete(targetPath);
            }
            foreach (var fileName in files)
            {
                
                var filePath = Path.Combine(Config.Data.AmongUsFolderPath, fileName);
                if (!File.Exists(filePath)) continue;
                File.Delete(filePath);
            }
        }

        Config.Data.Mods.CurrentModIdx = 0;
        Config.Data.Save();
    }

    public static void InstallMod(int modId)
    {
        if (Config.Data.Mods.CurrentModIdx == modId) return;
        UninstallMod();
        if (modId == 0) return;

        var mod = Config.Data.Mods.Mods.Find(mod => mod.Id == modId);
        var modDir = Path.Combine("mods", mod.Owner.ToLower(), mod.Repository.ToLower());
        var files = Directory.GetFiles(modDir);
        var directories = Directory.GetDirectories(modDir);
        foreach (var filePath in files)
        {
            var file = new FileInfo(filePath);
            var targetPath = Path.Combine(Config.Data.AmongUsFolderPath, file.Name);
            if (Helpers.IsDirectoryWritable(Config.Data.AmongUsFolderPath))
            {
                CreateSymbolicLink(targetPath, file.FullName, SymbolicLink.File);
            }
        }

        foreach (var directoryPath in directories)
        {
            var directory = new DirectoryInfo(directoryPath);
            var targetPath = Path.Combine(Config.Data.AmongUsFolderPath, directory.Name);
            if (Helpers.IsDirectoryWritable(Config.Data.AmongUsFolderPath))
            { 
                CreateSymbolicLink(targetPath, directory.FullName, SymbolicLink.Directory);
            }
        }

        Config.Data.Mods.CurrentModIdx = modId;
        Config.Data.Save();
    }

    [DllImport("kernel32.dll")]
    public static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName,
        SymbolicLink dwFlags);

    public enum SymbolicLink
    {
        File = 0,
        Directory = 1
    }
}