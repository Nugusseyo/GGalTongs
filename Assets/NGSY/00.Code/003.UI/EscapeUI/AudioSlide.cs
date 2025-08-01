using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSlide : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider slider;

    public void AudioControl()
    {
        float sound = slider.value;

        if (sound == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", sound);
    }
}
