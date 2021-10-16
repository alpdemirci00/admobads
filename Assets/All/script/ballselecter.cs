using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballselecter : MonoBehaviour
{
    public int currentballındex = 0;
    public GameObject[] balls;
    // Start is called before the first frame update
    void Start()
    {
        currentballındex = PlayerPrefs.GetInt("selectedball", 0);
        foreach (GameObject ball in balls)
            ball.SetActive(false);
        balls[currentballındex].SetActive(true);


    }
}
