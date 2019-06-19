using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySFX : MonoBehaviour
{
    public AudioClip SFXClip;
    public AudioSource SFXSource;
    public bool playSFX;
    // Start is called before the first frame update
    void Start()
    {
        SFXSource.clip = SFXClip;
        playSFX = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (playSFX)
        {
            SFXSource.Play();
            playSFX = false;
        }
    }
}
