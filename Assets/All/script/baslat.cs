using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class baslat : MonoBehaviour
{
    private int levelNumber;
    public GameObject [] bolumler;

    private void Start()
    {

        SceneManager.LoadScene("");
        levelNumber = PlayerPrefs.GetInt("levelName");
    bolumler[levelNumber].SetActive(true);



}

    // Oyunu kazandığında çağırın
    private void Win()
    {


        levelNumber++;
        PlayerPrefs.SetInt("levelName", levelNumber);




}
}
