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
}