using NGSY._03.SO.AudioSO;
using UnityEngine;

public class GunFireAudioClip : MonoBehaviour
{
    public GunShotAudioSO gunShotAudioSO;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayShotSound()
    {
        audioSource.clip = gunShotAudioSO.ShotAudioClips[Random.Range(0, gunShotAudioSO.ShotAudioClips.Count)];
        audioSource.Play();
    }
}
