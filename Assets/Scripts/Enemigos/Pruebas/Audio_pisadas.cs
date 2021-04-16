using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_pisadas : MonoBehaviour
{
    new AudioSource audio;
    [SerializeField] Enemy_Animation_Controller controlador;
    // Start is called before the first frame update
    void Awake()
    {
        audio = GetComponent<AudioSource>();
        controlador.Walking_Audio += Walking_Audio;
    }
    public void Walking_Audio(bool x)
    {
        if (x&& !audio.isPlaying)
        {
            audio.pitch = 1f + Random.Range(-0.25f, 0.25f);
            audio.volume = 1f + Random.Range(-0.25f, 0.25f);
            audio.Play();
        }
        else audio.Stop();
    }

    // Update is called once per frame
   
}
