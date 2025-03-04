using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD_Main : MonoBehaviour
{
    [SerializeField] public RawImage CursorL;
    [SerializeField] public RawImage CursorR;

    static public HUD_Main instance;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (GameMode.mode == GameMode.InputMode.SlideKeys)
        {
            gameObject.SetActive(true);
        }
        else if (GameMode.mode == GameMode.InputMode.StickKeys)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
