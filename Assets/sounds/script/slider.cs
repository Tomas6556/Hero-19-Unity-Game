using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class slider : MonoBehaviour
{
    public AudioMixerGroup Mixer;

    public void ToggleMusic(bool enabled)
    {
        if (enabled)
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        else 
            Mixer.audioMixer.SetFloat("MusicVolume", -80);

        PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    }

    public void ChanelVolume(float volume)
    {
        Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }
}
