[![GitHub release](https://flat.badgen.net/github/release/FrikandelbroodjeCommunity/SCP-999-LabAPI/)](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest)
[![LabAPI Version](https://flat.badgen.net/static/LabAPI%20Version/v1.1.4)](https://github.com/northwood-studios/LabAPI)
[![License](https://flat.badgen.net/github/license/FrikandelbroodjeCommunity/SCP-999-LabAPI/)](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/blob/master/LICENSE)

# About SCP-999

Plugin for SCP-650 schematic of MER plugin based on Exiled framework of SCP: Secret Laboratory.

Every round SCP-650 will spawn somewhere in Site-02, attempting to jumpscare its personnel.
If SCP-650 sees you, it will start chasing you, constantly sneaking up behind you.

> [!TIP]
> You can prevent SCP-650 from teleporting by looking at them, however this does not work if you are targeted by
> SCP-650.

# Installation

> [!IMPORTANT]
> **Required dependencies:**
> - [FrikanUtils](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils/README.md)
> - [FrikanUtils-ProjectMer](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils-ProjectMer/README.md)
> - [FrikanUtils-Audio](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils-Audio/README.md)
> - [NVorbis](https://github.com/NVorbis/NVorbis/releases/tag/v0.10.5)
> - [ProjectMER](https://github.com/Michal78900/ProjectMER/releases/latest)

Install the dependencies above, together with
the [latest release](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest) of the SCP-999 plugin
and place them in your LabAPI plugin folder.

The plugin requires SCP-999 to be provided as a schematic, download it from
the [releases page](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest) and place it in the
correct folder. By default, this will be <code>Configs/{port/global}/FrikanUtils/Maps/SCP-999-3D.zip</code>.

# Config

| Config                                       | Default       | Meaning                                                                                                                                                                                                                    |
|----------------------------------------------|---------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| `schematic_folder`                           | `Maps`        | Folder used by the FrikanUtils file system to search for the schematic.                                                                                                                                                    |
| `schematic_name`                             | `SCP650.json` | Name of the SCP-999 schematic file.                                                                                                                                                                                        |
| `offset`                                     | ...           | The offset of the SCP-999 schematic relative to the spawned NPC.                                                                                                                                                           |
| `inverted_animation_controls`                | `true`        | Whether to use the pause command to start the animation.                                                                                                                                                                   |           
| `follow_text`                                | ...           | Text shown when SCP-999 starts following a player.                                                                                                                                                                         |
| `idle_files`                                 | `[]`          | Audio files that can be randomly played while SCP-999 is standing idling. Leave empty to not play a sound while idling.                                                                                                    |
| `walking_files`                              | `[]`          | Audio files that can be randomly played while SCP-999 is walking. Leave empty to not play a sound while walking.                                                                                                           |
| `audio_folder`                               | `Audio`       | Folder used by the FrikanUtils file system to search for the audio files.                                                                                                                                                  |
| `min_time`                                   | `45`          | Minimum amount of time in seconds between playing audio files.                                                                                                                                                             |
| `max_time`                                   | `75`          | Maximum amount of time in seconds between playing audio files.                                                                                                                                                             |
