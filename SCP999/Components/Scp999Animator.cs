using System;
using FrikanUtils.Npc.Enums;
using FrikanUtils.Npc.Following;
using ProjectMER.Features.Objects;
using UnityEngine;

namespace SCP_999.Components;

public class Scp999Animator : MonoBehaviour
{
    [NonSerialized] public SchematicObject Schematic;
    [NonSerialized] public FollowingNpc Npc;
    [NonSerialized] public Vector3 Offset;

    [NonSerialized] public Animator Animator;
    [NonSerialized] public bool HasAnimator;
    [NonSerialized] public bool InvertedControls;

    private bool _animationPlaying = true;

    private void Update()
    {
        Schematic.Position = Npc.Dummy.Position + Offset;
        Schematic.Rotation = Quaternion.Euler(0, Npc.Dummy.LookRotation.y, 0);

        if (HasAnimator)
        {
            if (Npc.State == NpcState.Paused && _animationPlaying)
            {
                ToggleAnimation(false);
                _animationPlaying = false;
            }
            else if (Npc.State != NpcState.Paused && !_animationPlaying)
            {
                ToggleAnimation(true);
                _animationPlaying = true;
            }
        }
    }

    private void ToggleAnimation(bool target)
    {
        if (target ^ InvertedControls)
        {
            Animator.StartPlayback();
        }
        else
        {
            Animator.StopPlayback();
        }
    }
}