using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudio : MonoBehaviour
{

    public AudioSource audio;

    // Awake is when the gameobject is checked/instantiated ingame
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.Play(0);
    }

   
}
