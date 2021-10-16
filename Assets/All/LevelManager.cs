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
    //�imdi level managerdaki leveli prefsdeki de�ere g�re de�i�tirelim
    //Bide button componentini kullanm�ycaz. Birek script ile i�lemler yap�lacak.
    //�imdi ��yle bir �ey yap�caz. �lk levelleri bi listeye al�caz

    void Start()
    {
        
        level = PlayerPrefs.GetInt("LevelCount", 1);
        PlayerPrefs.SetInt("MaxLevel", maxLevel);
        //i de�eri ilk levelin idsinden ba�lamal�
        
        for (int i = 0; i < maxLevel; i++)
        {
            LevelButton lvl = Instantiate(levelBtnPrefab, levelContainer);
            lvl.SetButtonValue(i+1);
            if (i > level-1)
            {
                lvl.isActive = false;
            }
            if(i < level - 1)//Burda y�ld�zlamay� otomatik yapt�k. O y�zden 4c� leveli kaydetmeli ancak oraya gidememeliyiz
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
