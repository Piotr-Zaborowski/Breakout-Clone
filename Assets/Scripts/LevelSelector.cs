using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public void ZeroClicked()
    {
        GameManager.Instance.Level = 0;
    }


    public void OneClicked()
    {
        GameManager.Instance.Level = 1;
    }
    public void TwoClicked()
    {
        GameManager.Instance.Level = 2;
    }
}
