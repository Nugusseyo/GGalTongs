using System.Collections;
using NGSY._03.SO.AudioSO;
using UnityEngine;

public class BackGroundMusicPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    public GunShotAudioSO BGMSO;

    private void OnEnable()
    {
        StartCoroutine(PlayBGM());
    }

    private IEnumerator PlayBGM()
    {
        audioSource.clip = BGMSO.ShotAudioClips[Random.Range(0, BGMSO.ShotAudioClips.Count)];
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
        StartCoroutine(PlayBGM());
    }
}
