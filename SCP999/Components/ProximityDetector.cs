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

    private static Config Config => Scp999.Instance.Config;

    private float _healTimer = Config.HealInterval;

    private void Update()
    {
        _healTimer -= Time.deltaTime;

        if (_healTimer < 0)
        {
            _healTimer = Config.HealInterval;

            var needsNewTarget = Npc.TargetPlayer == null;
            foreach (var player in Player.List.Where(x => x.IsPlayer && x.Team != Team.SCPs))
            {
                if (Vector3.Distance(player.Position, Npc.Dummy.Position) > Config.HealRange) continue;
                player.Heal(Config.HealAmount);

                if (!needsNewTarget) continue;

                player.SendHint(Config.FollowText, 10);
                Npc.TargetPlayer = player;
                needsNewTarget = false;
            }
        }
    }
}