using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sesdurum : MonoBehaviour
{
    AudioSource seskontrol;
    // Start is called before the first frame update
    void Start()
    {
        seskontrol=GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 1)
        {
            seskontrol.mute = false;
        }
        else
            seskontrol.mute = true;
    }
}
