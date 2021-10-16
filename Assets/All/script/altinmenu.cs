using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class altinmenu : MonoBehaviour
{
    public Text parat;
    public int para;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        para = PlayerPrefs.GetInt("altınsayısıs");
        parat.text = "" + para;
    }
}
