using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMode
{
    public enum InputMode
    {
        SlideKeys, PointKeys, StickKeys, Keyboard 
    }
    static public InputMode mode = InputMode.Keyboard;
}
