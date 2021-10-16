using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ses : MonoBehaviour
{
    public GameObject sesacık, seskapalı;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("sesdurum", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sesdurum") == 1)
        {
            sesacık.SetActive(true);
            seskapalı.SetActive(false);
        }
        else
        {
            sesacık.SetActive(false);
            seskapalı.SetActive(true);
        }
    }
    public void sesdurum (string durum)
    {
        if (durum == "acık")
        {
            sesacık.SetActive(false);
            seskapalı.SetActive(true);
            PlayerPrefs.SetInt("sesdurum",0);
        }
        else if (durum == "kapalı")
        {
            sesacık.SetActive(true);
            seskapalı.SetActive(false);
            PlayerPrefs.SetInt("sesdurum", 1);
        }
    }
}
