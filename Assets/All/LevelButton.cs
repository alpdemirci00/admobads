using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour, IPointerClickHandler
{
    public int level;
    public bool isActive;
    public bool isFinish;
    public Text btnText;
    public Image btnImg;
    public Image starImg;

    public Color activeColor;
    public Color pasifColor;

    //bu objeyi olustururken kodu bir fonksiyon ile otomatik doldurucaz

    public void SetButtonValue(int value)
    {
        level = value;
    }

    private void Start()
    {
        //rengi hallettik þimdi týklamanýn önüne geçelim
        if (isFinish)
        {
            starImg.gameObject.SetActive(true);
        }
        else
        {
            starImg.gameObject.SetActive(false);
        }
        if (isActive)
        {
            btnImg.color = activeColor;
        }
        else
        {
            btnImg.color = pasifColor;
        }
        //get component komutlarýný silicem prefabda eklenmesi gerekenleri en iyisi elle ekleyelim
        btnText.text = level.ToString();//Text icerisine int deðer giremezsin o yüzden tostring ile dönüþtürmen gerek
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Bunun içine ne yazarsak butona týkladýðýmýzda uygulanacak
        if (isActive)
        {
            SceneManager.LoadScene(level);
        }
        //bu levellerin idleri ile çalýþacak
        //Küçük biþey yapalým her buton kodu level sayýsýný kendisi yazsýn oyun açýldýðýnda
    }
}
