using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public int maxLevel;
    public int level;


    public LevelButton levelBtnPrefab;
    public RectTransform levelContainer;

    public List<LevelButton> levelbuttons = new List<LevelButton>();
    //Þimdi level managerdaki leveli prefsdeki deðere göre deðiþtirelim
    //Bide button componentini kullanmýycaz. Birek script ile iþlemler yapýlacak.
    //þimdi þöyle bir þey yapýcaz. Ýlk levelleri bi listeye alýcaz

    void Start()
    {
        
        level = PlayerPrefs.GetInt("LevelCount", 1);
        PlayerPrefs.SetInt("MaxLevel", maxLevel);
        //i deðeri ilk levelin idsinden baþlamalý
        
        for (int i = 0; i < maxLevel; i++)
        {
            LevelButton lvl = Instantiate(levelBtnPrefab, levelContainer);
            lvl.SetButtonValue(i+1);
            if (i > level-1)
            {
                lvl.isActive = false;
            }
            if(i < level - 1)//Burda yýldýzlamayý otomatik yaptýk. O yüzden 4cü leveli kaydetmeli ancak oraya gidememeliyiz
            {
                lvl.isFinish = true;
            }
            levelbuttons.Add(lvl);
        }
    }
    public void StartLevel()
    {
        if (level <= maxLevel)
        {
            SceneManager.LoadScene(level);

        }
        else
        {
            SceneManager.LoadScene(level - 1);
        }
    }
}
