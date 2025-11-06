using System;
using FrikanUtils.Audio;
using FrikanUtils.Npc.Enums;
using FrikanUtils.Npc.Following;
using ProjectMER.Features.Objects;
using UnityEngine;
using Logger = LabApi.Features.Console.Logger;
using Random = System.Random;

namespace SCP_999.Components;

public class Scp999Animator : MonoBehaviour
{
    [NonSerialized] public SchematicObject Schematic;
    [NonSerialized] public FollowingNpc Npc;
    [NonSerialized] public Vector3 Offset;

    [NonSerialized] public Animator Animator;
    [NonSerialized] public bool HasAnimator;
    [NonSerialized] public bool InvertedControls;

    [NonSerialized] public PlayerSpeakerAudioPlayer AudioPlayer;

    private static Random _random = new();

    private float _timeUntilNextSound;
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

        if (Scp999.IdlePaths.IsEmpty() && Scp999.WalkingPaths.IsEmpty() || AudioPlayer.Playing)
        {
            return;
        }

        _timeUntilNextSound -= Time.deltaTime;
        if (_timeUntilNextSound <= 0)
        {
            _timeUntilNextSound = _random.Next(Scp999.Instance.Config.MinTime, Scp999.Instance.Config.MaxTime);

            var file = (_animationPlaying ? Scp999.WalkingPaths : Scp999.IdlePaths).RandomItem();
            AudioPlayer.QueueFile(file, 0);
            AudioPlayer.Play(0);
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