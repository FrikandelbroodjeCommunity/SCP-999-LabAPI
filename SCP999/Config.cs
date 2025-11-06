using System;
using System.ComponentModel;
using UnityEngine;

namespace SCP_999;

public class Config
{
    [Description("Name of the schematic zip file withouth the .zip extension")]
    public string SchematicName { get; set; } = "SCP-999-3D";

    [Description("The folder to look in for the schematic")]
    public string SchematicFolder { get; set; } = "Maps";

    [Description("The offset SCP-999 has to the NPC that controls them")]
    public Vector3 Offset { get; set; } = new(0, -.4f, 0);

    [Description("Whether to use inverted animation controls")]
    public bool InvertedAnimationControls { get; set; } = true;

    [Description("Text to show the player when SCP-999 starts following them")]
    public string FollowText { get; set; } = "<size=25><color=yellow>SCP-999 likes you!</color></size>";

    [Description("Audio files that can be played while SCP-999 is idle")]
    public string[] IdleFiles { get; set; } = Array.Empty<string>();

    [Description("Audio files that can be played while SCP-999 is walking")]
    public string[] WalkingFiles { get; set; } = Array.Empty<string>();

    [Description("The folder to look in for the audio files")]
    public string AudioFolder { get; set; } = "Audio";

    [Description("The minimum amount of time in seconds between audio files being played")]
    public int MinTime { get; set; } = 45;

    [Description("The maximum amount of time in seconds between audio files being played")]
    public int MaxTime { get; set; } = 75;
}