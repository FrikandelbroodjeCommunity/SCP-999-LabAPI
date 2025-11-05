using System;
using CommandSystem;
using FrikanUtils.Utilities;

namespace SCP_999.Commands;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class TeleportCommand : ICommand
{
    public string Command => "scp999";
    public string[] Aliases => Array.Empty<string>();
    public string Description => "Teleports SCP-999 to you";

    public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
    {
        if (!sender.TryGetPlayer(out var player, out response))
        {
            return false;
        }

        if (EventHandler.Instance == null || EventHandler.Instance.Dummy.IsDestroyed)
        {
            response = "No SCP-999 was spawned during this round";
            return false;
        }

        EventHandler.Instance.Dummy.Position = player.Position;

        response = "SCP-999 was teleported to you";
        return true;
    }
}