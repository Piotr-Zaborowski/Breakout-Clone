using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtonArray;


    private void ButtonUpdate()
    {
        for (int i=0; i<levelButtonArray.Length; i++)
        {
            if(i==GameManager.Instance.Level)
            {
                levelButtonArray[i].gameObject.SetActive(false);
                ColorBlock colors = levelButtonArray[i].colors;
                colors.normalColor = Color.red;
                colors.highlightedColor = new Color32(255, 100, 100, 255);
                levelButtonArray[i].colors = colors;
                levelButtonArray[i].gameObject.SetActive(true);
            }
            else
            {
                ColorBlock colors = levelButtonArray[i].colors;
                colors.normalColor = Color.white;
                colors.highlightedColor = new Color32(225, 225, 225, 255);
                levelButtonArray[i].colors = colors;
            }
            

        }
    }

    private void Start()
    {
        ButtonUpdate();
        for (int i = 0; i < levelButtonArray.Length; i++)
        {
            int tmp = i;
            levelButtonArray[i].onClick.AddListener(() => SelectLevel(tmp));
        }
    }


    private void FixedUpdate()
    {

    }

    void SelectLevel(int i)
    {
        //Debug.Log(i);
        GameManager.Instance.Level = i;
        ButtonUpdate();
    }

}
