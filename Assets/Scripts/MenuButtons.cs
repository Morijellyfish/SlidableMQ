using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PointMode()
    {
        GameMode.mode = GameMode.InputMode.PointKeys;
        SceneManager.LoadScene("Simple");
    }

    public void SlideMode()
    {
        GameMode.mode = GameMode.InputMode.SlideKeys;
        SceneManager.LoadScene("Simple");
    }
}
