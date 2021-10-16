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
        //rengi hallettik �imdi t�klaman�n �n�ne ge�elim
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
        //get component komutlar�n� silicem prefabda eklenmesi gerekenleri en iyisi elle ekleyelim
        btnText.text = level.ToString();//Text icerisine int de�er giremezsin o y�zden tostring ile d�n��t�rmen gerek
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        //Bunun i�ine ne yazarsak butona t�klad���m�zda uygulanacak
        if (isActive)
        {
            SceneManager.LoadScene(level);
        }
        //bu levellerin idleri ile �al��acak
        //K���k bi�ey yapal�m her buton kodu level say�s�n� kendisi yazs�n oyun a��ld���nda
    }
}
