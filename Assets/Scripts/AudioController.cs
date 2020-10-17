using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {
    private AudioSource myAudioSource;
    // Use this for initialization
    void Start () {
        myAudioSource = GetComponent<AudioSource>();
    }

    public void PlayBoing()
    {
        myAudioSource.Play();
    }
}
