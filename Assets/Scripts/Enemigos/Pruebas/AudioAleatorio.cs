using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAleatorio : MonoBehaviour
{
    new AudioSource audio;
    [SerializeField] AudioClip[] clips;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();   
    }

    // Update is called once per frame  
    public void Play()
    {
       
        if (!audio.isPlaying)
        {
            audio.clip = clips[0];
            audio.pitch = 1f + Random.Range(-0.25f, 0.25f);
            audio.volume = 1f + Random.Range(-0.25f, 0.25f);
            audio.Play();
            
        }
    }
}
