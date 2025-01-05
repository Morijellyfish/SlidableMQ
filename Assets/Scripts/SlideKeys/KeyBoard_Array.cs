using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoard_Array : MonoBehaviour
{
    static public short[,] KeyBoard = new short[3, 10]
    {
        {0x51,0x57,0x45,0x52,0x54 ,0x59,0x55,0x49,0x4F,0x50},
        {0x41,0x53,0x44,0x46,0x47 ,0x48,0x4A,0x4B,0x4C,0xBA},
        {0x5A,0x58,0x43,0x56,0x42 ,0x4E,0x4D,0xBC,0xBE,0xBF}
    };

    static public char[,] chKeyBoard = new char[3, 10]
    {
        {'q','w','e','r','t','y','u','i','o','p'},
        {'a','s','d','f','g','h','j','k','l',';'},
        {'z','x','c','v','b','n','m',',','.','/'}
    };
    static public Dictionary<char, Vector2> KeyPositions = new Dictionary<char, Vector2>()
    {
        { 'q', new Vector2(-5,01) },
        { 'w', new Vector2(-4,01) },
        { 'e', new Vector2(-3,01) },
        { 'r', new Vector2(-2,01) },
        { 't', new Vector2(-1,01) },
        { 'y', new Vector2(01,01) },
        { 'u', new Vector2(02,01) },
        { 'i', new Vector2(03,01) },
        { 'o', new Vector2(04,01) },
        { 'p', new Vector2(05,01) },

        { 'a', new Vector2(-5,00) },
        { 's', new Vector2(-4,00) },
        { 'd', new Vector2(-3,00) },
        { 'f', new Vector2(-2,00) },
        { 'g', new Vector2(-1,00) },
        { 'h', new Vector2(01,00) },
        { 'j', new Vector2(02,00) },
        { 'k', new Vector2(03,00) },
        { 'l', new Vector2(04,00) },
        { ';', new Vector2(05,00) },

        { 'z', new Vector2(-5,-1) },
        { 'x', new Vector2(-4,-1) },
        { 'c', new Vector2(-3,-1) },
        { 'v', new Vector2(-2,-1) },
        { 'b', new Vector2(-1,-1) },
        { 'n', new Vector2(01,-1) },
        { 'm', new Vector2(02,-1) },
        { ',', new Vector2(03,-1) },
        { '.', new Vector2(04,-1) },
        { '/', new Vector2(05,-1) }
    };

}
