using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenuController : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioClip buttonSound;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    public void ButtonPress()
    {
        GetComponent<AudioSource>().PlayOneShot(buttonSound);
    }
}
