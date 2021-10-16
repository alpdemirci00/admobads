using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class altin : MonoBehaviour
{
    public bool oyunaktif = true;
    public int altınsayısı = 0;


    public void altınarttır()
    {
        altınsayısı = altınsayısı + 1;
       
        PlayerPrefs.SetInt("altınsayısıs", altınsayısı);
        //altınsayısı = PlayerPrefs.GetInt("altın");  altın artıyor burda 
    }

}