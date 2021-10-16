using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour,IPointerClickHandler
{
    public int level;
    public void Finish()
    {

        //�imdi bunu b�yle yazarsak ve kullanmaya kalkarsak bir s�k�nt� ��kar.
        //��yle bir s�k�nt�. E�er biz en son 5ci leveli bitirdiysek ve 6c� leveli a�t�ysak ard�ndan gelip 3c� leveli bitirirsek kod gidip 3c� leveli bitirdiyimizi kayeder. O y�zden bunu s�n�rl�ycaz.
        //Burdaki 1 default value. E�er bo� d�nerse prefs o zaman 1 de�eri al�cak
        //Tabi �imdi bunu �al��t�r�rken hata al�caz.
        if (level < PlayerPrefs.GetInt("MaxLevel"))
        {
            if (PlayerPrefs.GetInt("LevelCount", 1) == level)//e�er level 1 ise
            {
                PlayerPrefs.SetInt("LevelCount", level + 1); //level 2yi kaydet. +1 yap�ca��ma 2 yapm���m
                Debug.Log("Level" + PlayerPrefs.GetInt("LevelCount") + " kaydedildi.");
                //Leveli kayetmiycek ��nk� mant�ken biz ikinci levele girememeliyiz. 
                //O y�zden level kaydederken s�rdaki leveli a�mal�z
            }
            //B�ylelikle Finish fonksiyonu �a��r�l�nca level kaydedilsede edilmesede ge�i� yap�lacak
           // SceneManager.LoadScene(level + 1);
        }
        else {
            if (PlayerPrefs.GetInt("LevelCount", 1) == level)//e�er level 1 ise
            {
                PlayerPrefs.SetInt("LevelCount", level + 1); //level 2yi kaydet. +1 yap�ca��ma 2 yapm���m
                Debug.Log("Level" + PlayerPrefs.GetInt("LevelCount") + " kaydedildi.");
                //Leveli kayetmiycek ��nk� mant�ken biz ikinci levele girememeliyiz. 
                //O y�zden level kaydederken s�rdaki leveli a�mal�z
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Finish();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //�uan e�er biri bu kodun bulundu�u objeye temas ederse yine ayn� �eyler olucak
        if (collision.gameObject.CompareTag("Player"))
        {
            Finish();   
        }
    }
}
