using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Audio : MonoBehaviour
{
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private float _pitch;

    public void PlayKey()
    {
        _audioSource.pitch = _pitch;
        _audioSource.PlayOneShot(_audioClip);
    }
}
