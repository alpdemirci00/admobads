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

        //Þimdi bunu böyle yazarsak ve kullanmaya kalkarsak bir sýkýntý çýkar.
        //Þöyle bir sýkýntý. Eðer biz en son 5ci leveli bitirdiysek ve 6cý leveli açtýysak ardýndan gelip 3cü leveli bitirirsek kod gidip 3cü leveli bitirdiyimizi kayeder. O yüzden bunu sýnýrlýycaz.
        //Burdaki 1 default value. Eðer boþ dönerse prefs o zaman 1 deðeri alýcak
        //Tabi þimdi bunu çalýþtýrýrken hata alýcaz.
        if (level < PlayerPrefs.GetInt("MaxLevel"))
        {
            if (PlayerPrefs.GetInt("LevelCount", 1) == level)//eðer level 1 ise
            {
                PlayerPrefs.SetInt("LevelCount", level + 1); //level 2yi kaydet. +1 yapýcaðýma 2 yapmýþým
                Debug.Log("Level" + PlayerPrefs.GetInt("LevelCount") + " kaydedildi.");
                //Leveli kayetmiycek çünkü mantýken biz ikinci levele girememeliyiz. 
                //O yüzden level kaydederken sýrdaki leveli açmalýz
            }
            //Böylelikle Finish fonksiyonu çaðýrýlýnca level kaydedilsede edilmesede geçiþ yapýlacak
           // SceneManager.LoadScene(level + 1);
        }
        else {
            if (PlayerPrefs.GetInt("LevelCount", 1) == level)//eðer level 1 ise
            {
                PlayerPrefs.SetInt("LevelCount", level + 1); //level 2yi kaydet. +1 yapýcaðýma 2 yapmýþým
                Debug.Log("Level" + PlayerPrefs.GetInt("LevelCount") + " kaydedildi.");
                //Leveli kayetmiycek çünkü mantýken biz ikinci levele girememeliyiz. 
                //O yüzden level kaydederken sýrdaki leveli açmalýz
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Finish();
    }

    private void OnCollisionEnter(Collision collision)
    {
        //þuan eðer biri bu kodun bulunduðu objeye temas ederse yine ayný þeyler olucak
        if (collision.gameObject.CompareTag("Player"))
        {
            Finish();   
        }
    }
}
