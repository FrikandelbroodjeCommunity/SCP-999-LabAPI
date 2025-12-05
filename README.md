[![GitHub release](https://flat.badgen.net/github/release/FrikandelbroodjeCommunity/SCP-999-LabAPI/)](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest)
[![LabAPI Version](https://flat.badgen.net/static/LabAPI%20Version/v1.1.4)](https://github.com/northwood-studios/LabAPI)
[![License](https://flat.badgen.net/github/license/FrikandelbroodjeCommunity/SCP-999-LabAPI/)](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/blob/master/LICENSE)

# About SCP-999

The Site-02 staff has been a bit distracted by SCP-999. Because of this the 05-councel has decided that SCP-999 should
be incinerated, however, the guards tasks with this could not do it to the cute monster. Ever since then 999 has been
waiting patiently next to the incinerator.

Everyone that gets close to SCP-999, except for other SCPs, experience a healing effect. SCP-999 will attempt
to stay close to these people out of fear of being left alone again.

# Installation

> [!IMPORTANT]
> **Required dependencies:**
> - [FrikanUtils](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils/README.md)
> - [FrikanUtils-ProjectMer](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils-ProjectMer/README.md)
> - [FrikanUtils-Audio](https://github.com/FrikandelbroodjeCommunity/FrikanUtils/blob/master/FrikanUtils-Audio/README.md)
> - [ProjectMER](https://github.com/Michal78900/ProjectMER/releases/latest)
> - [NVorbis](https://github.com/NVorbis/NVorbis/releases/tag/v0.10.5) (Place in the dependencies folder `LabAPI/dependencies/{port/global}`)

Install the dependencies above, together with
the [latest release](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest) of the SCP-999 plugin
and place them in your LabAPI plugin folder.

The plugin requires SCP-999 to be provided as a schematic, download it from
the [releases page](https://github.com/FrikandelbroodjeCommunity/SCP-999-LabAPI/releases/latest) and place it in the
correct folder. By default, this will be <code>LabAPI/configs/{port/global}/FrikanUtils/Maps/SCP-999-3D.zip</code>.

# Config

| Config                        | Default       | Meaning                                                                                                                              |
|-------------------------------|---------------|--------------------------------------------------------------------------------------------------------------------------------------|
| `schematic_folder`            | `Maps`        | Folder used by the FrikanUtils file system to search for the schematic.                                                              |
| `schematic_name`              | `SCP650.json` | Name of the SCP-999 schematic file.                                                                                                  |
| `offset`                      | ...           | The offset of the SCP-999 schematic relative to the spawned NPC.                                                                     |
| `inverted_animation_controls` | `true`        | Whether to use the pause command to start the animation.                                                                             |           
| `follow_text`                 | ...           | Text shown when SCP-999 starts following a player.                                                                                   |
| `idle_files`                  | `[]`          | Audio files that can be randomly played while SCP-999 is standing idling. Leave empty to not play a sound while idling.              |
| `walking_files`               | `[]`          | Audio files that can be randomly played while SCP-999 is walking. Leave empty to not play a sound while walking.                     |
| `audio_folder`                | `Audio`       | Folder used by the FrikanUtils file system to search for the audio files.                                                            |
| `min_time`                    | `45`          | Minimum amount of time in seconds between playing audio files.                                                                       |
| `max_time`                    | `75`          | Maximum amount of time in seconds between playing audio files.                                                                       |
| `heal_interval`               | `5`           | Time in seconds between players being healed. Also, only each time the players are healed, can SCP-999 pick a new target it follows. |
| `heal_amount`                 | `5`           | Amount of HP gathered at each interval.                                                                                              |
| `heal_range`                  | `5`           | The range players need to be within to experience the healing effect. Also the range SCP-999 starts following players.               |
