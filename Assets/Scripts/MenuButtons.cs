using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PointMode()
    {
        GameMaster.SlideMode = false;
        SceneManager.LoadScene("Simple");
    }

    public void SlideMode()
    {
        GameMaster.SlideMode = true;
        SceneManager.LoadScene("Simple");
    }
}
