using System;
using System.Linq;
using FrikanUtils.Npc.Following;
using LabApi.Features.Wrappers;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;

namespace SCP_999.Components;

public class ProximityDetector : MonoBehaviour
{
    [NonSerialized] public FollowingNpc Npc;

    private const int HealTime = 10;
    private const int HealAmount = 5;
    private const int Range = 5;

    private float _healTimer = HealTime;

    private void Update()
    {
        _healTimer -= Time.deltaTime;

        if (_healTimer < 0)
        {
            _healTimer = HealTime;

            var needsNewTarget = Npc.TargetPlayer == null;
            foreach (var player in Player.List.Where(x => x.IsPlayer))
            {
                if (Vector3.Distance(player.Position, Npc.Dummy.Position) > Range) continue;
                player.Heal(HealAmount);

                if (!needsNewTarget) continue;

                Logger.Info($"Set new target: {player.LogName}");
                player.SendHint("<size=25><color=yellow>SCP-999 likes you!</color></size>", 10);
                Npc.TargetPlayer = player;
                needsNewTarget = false;
            }
        }
    }
}