using System.Collections;
using System.Collections.Generic;
using System;

public class KeyInput
{

    /*
    [DllImport("user32.dll")]
    static extern void SendInput(int nInputs, ref INPUT pInputs, int cbsize);

    [StructLayout(LayoutKind.Sequential)]
    struct MOUSEINPUT
    {
        public int dx;
        public int dy;
        public uint mouseData;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct KEYBDINPUT
    {
        public short wVk;
        public short wScan;
        public uint dwFlags;
        public uint time;
        public IntPtr dwExtraInfo;
    };

    [StructLayout(LayoutKind.Sequential)]
    struct HARDWAREINPUT
    {
        public int uMsg;
        public short wParamL;
        public short wParamH;
    };

    [StructLayout(LayoutKind.Explicit)]
    struct INPUT
    {
        [FieldOffset(0)]
        public uint type;
        [FieldOffset(8)]
        public MOUSEINPUT mi;
        [FieldOffset(8)]
        public KEYBDINPUT ki;
        [FieldOffset(8)]
        public HARDWAREINPUT hi;
    };

    //KeyDown
    public void InputKD(short KeyCode)
    {
        INPUT input = new INPUT
        {
            // 1はキーボードを入力
            type = 1,
            ki = new KEYBDINPUT()
            {
                wVk = KeyCode,//KeyNum
                wScan = 0,
                dwFlags = 0,//keyDown
                time = 1,
                dwExtraInfo = (IntPtr)0
            },
        };
        SendInput(1, ref input, Marshal.SizeOf(input));
    }

    //KeyUp
    public void InputKU(short KeyCode)
    {
        INPUT input = new INPUT
        {
            // 1はキーボードを入力
            type = 1,
            ki = new KEYBDINPUT()
            {
                wVk = KeyCode,//KeyNum
                wScan = 0,
                dwFlags = 2,//keyUp
                time = 1,
                dwExtraInfo = (IntPtr)0
            },
        };
        SendInput(1, ref input, Marshal.SizeOf(input));
    }
    */
}
