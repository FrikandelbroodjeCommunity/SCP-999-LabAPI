using System.Linq;
using CustomPlayerEffects;
using FrikanUtils.Audio;
using FrikanUtils.Npc.Enums;
using FrikanUtils.Npc.Following;
using FrikanUtils.ProjectMer;
using LabApi.Events.Handlers;
using LabApi.Features.Wrappers;
using MapGeneration;
using MEC;
using PlayerRoles;
using ProjectMER.Features.Extensions;
using ProjectMER.Features.Objects;
using SCP_999.Components;
using UnityEngine;
using PrimitiveObjectToy = AdminToys.PrimitiveObjectToy;

namespace SCP_999;

public static class EventHandler
{
    internal static FollowingNpc Instance;

    private static readonly Vector3 Offset = new(0, 0.5f, -6.5f);

    public static void RegisterEvents()
    {
        ServerEvents.RoundStarted += RoundStarted;
    }

    public static void UnregisterEvents()
    {
        ServerEvents.RoundStarted -= RoundStarted;
    }

    private static void RoundStarted()
    {
        Instance?.Destroy(DestroyReason.Removal);
        Instance = new FollowingNpc("SCP-999-internal", null)
        {
            WalkSpeed = 2.4f,
            SprintSpeed = 3.9f,
            OutOfRangeAction = OutOfRangeAction.StopFollowing,
            ReachTargetAction = ReachTargetAction.Pause
        };

        var detector = Instance.Dummy.GameObject.AddComponent<ProximityDetector>();
        detector.Npc = Instance;

        var room = Room.Get(RoomName.HczWaysideIncinerator).First();

        Timing.CallDelayed(1f, () =>
        {
            Instance.Dummy.SetRole(RoleTypeId.Tutorial);
            Instance.Dummy.Scale = new Vector3(0.4f, 0.4f, 0.4f);
            Instance.Dummy.Position = room.GetAbsolutePosition(Offset);
            Instance.Dummy.IsGodModeEnabled = true;
            Instance.Dummy.EnableEffect<Invisible>();
        });

        Timing.CallDelayed(5f, () =>
        {
            var spawned = Scp999.Schematic.SpawnSchematic(Instance.Dummy.Position, Instance.Dummy.Rotation);
            SetupAnimator(Instance, spawned);
        });
    }


    private static void SetupAnimator(FollowingNpc npc, SchematicObject obj)
    {
        foreach (var block in obj.AttachedBlocks)
        {
            if (block.TryGetComponent(out PrimitiveObjectToy toy))
            {
                toy.syncInterval = .1f;
            }
        }

        var animator = obj.gameObject.AddComponent<Scp999Animator>();
        animator.Npc = npc;
        animator.Schematic = obj;
        animator.Offset = Scp999.Instance.Config.Offset;
        animator.Animator = obj.AnimationController.Animators.FirstOrDefault();
        animator.HasAnimator = animator.Animator != null;
        animator.InvertedControls = Scp999.Instance.Config.InvertedAnimationControls;

        if (!(Scp999.IdlePaths.IsEmpty() && Scp999.WalkingPaths.IsEmpty()))
        {
            animator.AudioPlayer = new PlayerSpeakerAudioPlayer(npc.Dummy);
        }
    }
}