using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class menus : MonoBehaviour
{
    [Header("UIPages")]
    public GameObject CreaditScreen;
    public GameObject mainScreen;
    public GameObject bolumler;
    public void başla()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void bölümler ()
    {
        mainScreen.SetActive(false);
        bolumler.SetActive(true);
    }
    public void market ()
    {
        mainScreen.SetActive(false);
        CreaditScreen.SetActive(true);

    }
    public void market2menu()
    {
        mainScreen.SetActive(true);
        CreaditScreen.SetActive(false);
    }
    public void bolum2menu ()
    {
        mainScreen.SetActive(true);
        bolumler.SetActive(false);
    }
}
