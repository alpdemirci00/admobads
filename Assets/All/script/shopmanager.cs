using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class shopmanager : MonoBehaviour
{
    public int currentballındex = 0;
    public GameObject[] ballmodels;
    public ballblueprint[] balls;
    public Button buybutton;
    public altin al;
    public int altın;
    public UnityEngine.UI.Text para;
    // Start is called before the first frame update
    void Start()
    {
        altın = PlayerPrefs.GetInt("altınsayısıs");
        foreach (ballblueprint ball in balls)
        {
            if (ball.price == 0)
                ball.isunlock = true;
            else
                ball.isunlock = PlayerPrefs.GetInt(ball.name, 0) == 0 ? false : true;
        }

        currentballındex = PlayerPrefs.GetInt("selectedball", 0);
        foreach (GameObject ball in ballmodels)
            ball.SetActive(false);
        ballmodels[currentballındex].SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
    public void changenest()
    {
        ballmodels[currentballındex].SetActive(false);

        currentballındex++;
        if (currentballındex == ballmodels.Length)
            currentballındex = 0;

        ballmodels[currentballındex].SetActive(true);
        ballblueprint c = balls[currentballındex];
        if (!c.isunlock)
            return;
        PlayerPrefs.SetInt("selectedball", currentballındex);
    }
    public void changenest1()
    {
        ballmodels[currentballındex].SetActive(false);

        currentballındex--;
        if (currentballındex == -1)
            currentballındex = ballmodels.Length - 1;

        ballmodels[currentballındex].SetActive(true);
        ballblueprint c = balls[currentballındex];
        if (!c.isunlock)
            return;
        PlayerPrefs.SetInt("selectedball", currentballındex);
    }
    public void Unlockball()
    {
        ballblueprint c = balls[currentballındex];

        if (altın >= c.price)
        {
        
            PlayerPrefs.SetInt(c.name, 1);
            PlayerPrefs.SetInt("selectedball", currentballındex);
            c.isunlock = true;
            altın = altın - c.price;
            PlayerPrefs.SetInt("altınsayısıs", altın);
        }
    }
    private void UpdateUI()
    {
        ballblueprint c = balls[currentballındex];
        if (c.isunlock)
        {
            buybutton.gameObject.SetActive(false);
        }
        else
        {
            buybutton.gameObject.SetActive(true);
            para.text = "Buy - " + c.price + " $";
            if (c.price < PlayerPrefs.GetInt("altınsayısıs", 0))
            {
                buybutton.interactable = true;
            }
            else
            {
                buybutton.interactable = false;
            }
        }
    }


}