using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMode.mode == GameMode.InputMode.SlideKeys)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
