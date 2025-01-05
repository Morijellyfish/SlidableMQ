using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerKey : MonoBehaviour
{
    [SerializeField] char ch;

    public void Input()
    {
        TypingManager.CheckType(ch);
    }
}
