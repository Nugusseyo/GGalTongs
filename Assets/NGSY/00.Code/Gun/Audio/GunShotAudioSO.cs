using System.Collections.Generic;
using UnityEngine;

namespace NGSY._03.SO.AudioSO
{
    [CreateAssetMenu(fileName = "GunShotSO", menuName = "SO/Audio/GunShot", order = 0)]
    public class GunShotAudioSO : ScriptableObject
    {
        public List<AudioClip> ShotAudioClips = new List<AudioClip>();
    }
}