using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelSelect : MonoBehaviour
{
    public int noOfLevels;
    public GameObject levelButton;
    public RectTransform ParentPanel;
    public int levelReached;
    public int kiwis;

    private int index = 0;

    public int neededKiwis = 5;

    List<GameObject> buttons = new List<GameObject>();

    private void Awake()
    {
        LevelButtons();
    }



    void LevelButtons()
    {
        if (PlayerPrefs.HasKey("level"))
        {
            levelReached = PlayerPrefs.GetInt("level");
        }
        else
        {
            PlayerPrefs.SetInt("level", 1);
            levelReached = PlayerPrefs.GetInt("level");
        }

        for (int i = 0; i < noOfLevels; i++)
        {
            int x = new int();
            x = i + 1;
            GameObject lvlbutton = Instantiate(levelButton);
            lvlbutton.transform.SetParent(ParentPanel, false);
            Text buttontext = lvlbutton.GetComponentInChildren<Text>();
            buttontext.text = (i + 1).ToString();

            lvlbutton.gameObject.GetComponent<Button>().onClick.AddListener(delegate
            {
                LevelSelected(x);
            });

            //if (i + 1 > levelReached)
            //{
            //    lvlbutton.GetComponent<Button>().interactable = false;
            //}

            buttons.Add(lvlbutton);
        }
    }






    void LevelSelected(int index)
    {
        PlayerPrefs.SetInt("levelSelected", index);
        Debug.Log("Level Selected: " + index.ToString());
        StartCoroutine(LoadDelay(index));
    }

    private IEnumerator LoadDelay(int index)
    {
        yield return new WaitForSeconds(2f);
        LoadLevels(index);
    }

    void LoadLevels(int index)
    {
        SceneManager.LoadScene("Level " + index);
    }

    //public void CheckForNextLevel()
    //{

    //    kiwis = PlayerPrefs.GetInt("Kiwis");

    //    Debug.Log(kiwis);


    //    if (kiwis >= neededKiwis)
    //    {
    //        Debug.Log("Unlock Level");
    //        UnlockNextLevel();
    //    }

    //}


    //void UnlockNextLevel()
    //{
    //    Debug.Log("unlocked");
    //    kiwis = 0;
    //    neededKiwis++;
    //    index++;
    //    buttons[index].GetComponent<Button>().interactable = true;
    //    Debug.Log(buttons[index].name);
    //}
}
