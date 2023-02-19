using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using AmongUsToolbox.Windows.Properties;
using Ionic.Zip;
using MetroFramework.Controls;
using Newtonsoft.Json;
using Label = System.Windows.Forms.Label;

namespace AmongUsToolbox.Modules;

public class Github
{
    private static readonly Regex UrlRegex = new(@"^(?:https://)github.com[:/](.*)/(.*)$", RegexOptions.IgnoreCase);
    private static readonly Regex RepositoryRegex = new(@"^([a-z\d](?:[a-z\d]|-(?:(?:.+?)[a-z\d])){0,38})\/(.+)$", RegexOptions.IgnoreCase);

    public static RepositoryInfo Parse(string value)
    {
        var repository = new RepositoryInfo();
        var urlMatch = UrlRegex.Match(value);
        var repositoryMatch = RepositoryRegex.Match(value);
        
        Console.WriteLine(value);
        Console.WriteLine(repositoryMatch.Success);
        Console.WriteLine(UrlRegex.ToString());
        Console.WriteLine(RepositoryRegex.ToString());
        
        if (!urlMatch.Success && !repositoryMatch.Success) return repository;
        
        repository.Owner = repositoryMatch.Groups[1].Value;
        repository.Name = repositoryMatch.Groups[2].Value;

        return repository;
    }

    public static async Task<Release> GetLatestRelease(RepositoryInfo repository)
    {
        var httpClient = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.github.com/repos/{repository.Owner}/{repository.Name}/releases/latest");
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("AmongUsToolbox", "1.0"));
        request.Headers.UserAgent.Add(new ProductInfoHeaderValue("(+https://github.com/goeno/Among-Us-Toolbox)"));
        request.Headers.Add("User-Agent", "AmongUsToolbox/1.0.0 (https://github.com/goeno/Among-Us-Toolbox/; contact@goeno.fr)");
        Console.WriteLine(request.RequestUri);
        Console.WriteLine(request.Headers.ToString());
        var response = await httpClient.SendAsync(request);
        return response.StatusCode != HttpStatusCode.OK ? null : JsonConvert.DeserializeObject<Release>(await response.Content.ReadAsStringAsync());
    }
    
    
    public static void CreateModDirectory(string owner, string repository, string zipPath, MetroProgressBar progressBar,
        Label progressLabel)
    {
        var modDir = Path.Combine("mods", owner.ToLower(), repository.ToLower());
        Directory.CreateDirectory(Path.Combine("mods", owner.ToLower()));
        if (Directory.Exists(modDir))
        {
            Directory.Delete(modDir, true);
        }
        Directory.CreateDirectory(modDir);
        var zipFile = new ZipFile(zipPath);
        zipFile.ExtractProgress += (e, sender) =>
        {
            progressBar.Value = sender.TotalBytesToTransfer == 0 ? 0 : (int)(sender.BytesTransferred / sender.TotalBytesToTransfer * 100);
            progressLabel.Text = @$"{Resources.Extracting}: {sender.BytesTransferred/1000} Kb / {sender.TotalBytesToTransfer/1000} Kb";
        };
        zipFile.ExtractAll(modDir);
        zipFile.Dispose();
        File.Delete(zipPath);
    }

    public static async Task<string> DownloadAsset(Asset asset, MetroProgressBar progressBar, Label progressLabel)
    {
        if (asset?.DownloadUrl == null) return null;

        using var wc = new WebClient();

        wc.Headers.Add("User-Agent",
            "User-Agent: AmongUsToolbox/1.0.0 (https://github.com/goeno/Among-Us-Toolbox/; contact@goeno.fr)");

        var filename = $"downloads/{Path.GetFileName(asset.DownloadUrl)}";

        wc.DownloadProgressChanged += (e, sender) =>
        {
            progressBar.Value = sender.ProgressPercentage;
            progressLabel.Text = @$"{Resources.Download}: {sender.BytesReceived/1000} Kb / {sender.TotalBytesToReceive/1000} Kb";
        };

        await wc.DownloadFileTaskAsync(asset.DownloadUrl, filename);

        return filename;
    }

    public struct RepositoryInfo
    {
        public string Owner;
        public string Name;
    }
    
    public class Release
    {
        [JsonProperty(PropertyName = "assets")]
        public List<Asset> Assets = new();
        [JsonProperty(PropertyName = "id")]
        public int Id;

        public Asset GetZipAsset()
        {
            return Assets.Find(asset => asset.DownloadUrl.EndsWith(".zip"));
        }
    }
    
    public class Asset
    {
        [JsonProperty(PropertyName = "name")]
        public string Name;
        [JsonProperty(PropertyName = "browser_download_url")]
        public string DownloadUrl;
    }
}

