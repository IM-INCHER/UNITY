using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource BgmSource;
    public AudioClip playSound;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public AudioClip employSound;
    public AudioClip UpgradeTrueSound;
    public AudioClip UpgradeFalseSound;
    public AudioClip UpgradeSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        BgmSource = GetComponent<AudioSource>();
    }

    public void PlaySound()
    {
        BgmSource.clip = playSound;
        BgmSource.Play();
    }
    public void AudioPlay(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.PlayOneShot(audioClip);
    }
}
