using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pause : MonoBehaviour
{
    public GameObject pausedmenu;

    public void ClickPause ()
    {
        pausedmenu.SetActive(true);
        Time.timeScale = 0;
    }
}
