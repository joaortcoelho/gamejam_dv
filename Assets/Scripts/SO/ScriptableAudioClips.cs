using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/AudioClips", fileName = "New Scriptable AudioClips")]
public class ScriptableAudioClips : ScriptableObject
{
    [SerializeField] private AudioClip[] clips;

    public AudioClip[] Clips => clips;
}
