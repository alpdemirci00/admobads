using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour
{
    public void clickcontine ()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
