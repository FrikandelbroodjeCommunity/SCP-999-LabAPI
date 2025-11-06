using System;
using System.Collections.Generic;
using FrikanUtils.FileSystem;
using FrikanUtils.ProjectMer;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;
using ProjectMER.Features.Serializable.Schematics;

namespace SCP_999;

public class Scp999 : Plugin<Config>
{
    public override string Name => "SCP-999";
    public override string Description => "Adds SCP-999 which follows and heals nearby players";
    public override string Author => "gamendegamer321";
    public override Version Version => new(1, 0, 0);
    public override Version RequiredApiVersion => new(LabApiProperties.CompiledVersion);

    public static Scp999 Instance { get; private set; }

    internal static SchematicObjectDataList Schematic;
    internal static string[] IdlePaths;
    internal static string[] WalkingPaths;

    public override void Enable()
    {
        Instance = this;
        EventHandler.RegisterEvents();

        Load();
    }

    public override void Disable()
    {
        EventHandler.UnregisterEvents();
    }

    private async void Load()
    {
        Schematic = await MerUtilities.LoadFullSchematic(Config.SchematicName, Config.SchematicFolder);

        var files = new List<string>();
        foreach (var filename in Config.IdleFiles)
        {
            var path = await FileHandler.SearchFullPath(filename, Config.AudioFolder);
            if (path != null) files.Add(path);
        }

        IdlePaths = files.ToArray();
        files.Clear();

        foreach (var filename in Config.WalkingFiles)
        {
            var path = await FileHandler.SearchFullPath(filename, Config.AudioFolder);
            if (path != null) files.Add(path);
        }

        WalkingPaths = files.ToArray();
    }
}