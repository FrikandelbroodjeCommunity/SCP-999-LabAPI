using System;
using System.Linq;
using FrikanUtils.Npc.Following;
using LabApi.Features.Wrappers;
using PlayerRoles;
using UnityEngine;

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
            foreach (var player in Player.List.Where(x => x.IsPlayer && x.Team != Team.SCPs))
            {
                if (Vector3.Distance(player.Position, Npc.Dummy.Position) > Range) continue;
                player.Heal(HealAmount);

                if (!needsNewTarget) continue;

                player.SendHint(Scp999.Instance.Config.FollowText, 10);
                Npc.TargetPlayer = player;
                needsNewTarget = false;
            }
        }
    }
}