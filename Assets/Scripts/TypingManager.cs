using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    [SerializeField] TMP_Text TimeField;
    [SerializeField] TMP_Text TaskField;
    [SerializeField] TMP_Text InputField;
    [SerializeField] public TMP_Text MessageField;
    static public TypingManager instance;
    static public double time = 0;
    double preTime = 0;

    void Start()
    {
        time = 0;
        instance = this;
        TaskManager.SetTaskNumber(0);
    }

    void Update()
    {
        //Timer
        if (TaskManager.TaskCount != 0 && TaskManager.TaskCount != TaskManager.TaskText.Length)
        {
            time += Time.timeAsDouble - preTime;
            TimeField.text = time.ToString(".000");
        }
        preTime = Time.timeAsDouble;

        //Typing(Keyboard)
        char c = GetCharFromKeyCode();
        TaskManager.CheckType(c);

        //TaskFinish
        if (TaskManager.TaskCount != 0)
        {
            InputField.text = TaskManager.TaskText.Substring(0, TaskManager.TaskCount);
        }
    }


    public void SetTaskTexts(string tasktext)
    {
        MessageField.text = "下に表示されるテキストを入力してください\r\n" + $"{TaskManager.TaskNumber + 1}/{TaskManager.TaskTexts.Length}";
        InputField.text = "";
        TaskField.text = tasktext;
    }

    char GetCharFromKeyCode()
    {
        if (Input.GetKeyDown(KeyCode.A)) { return 'a'; }
        if (Input.GetKeyDown(KeyCode.B)) { return 'b'; }
        if (Input.GetKeyDown(KeyCode.C)) { return 'c'; }
        if (Input.GetKeyDown(KeyCode.D)) { return 'd'; }
        if (Input.GetKeyDown(KeyCode.E)) { return 'e'; }
        if (Input.GetKeyDown(KeyCode.F)) { return 'f'; }
        if (Input.GetKeyDown(KeyCode.G)) { return 'g'; }
        if (Input.GetKeyDown(KeyCode.H)) { return 'h'; }
        if (Input.GetKeyDown(KeyCode.I)) { return 'i'; }
        if (Input.GetKeyDown(KeyCode.J)) { return 'j'; }
        if (Input.GetKeyDown(KeyCode.K)) { return 'k'; }
        if (Input.GetKeyDown(KeyCode.L)) { return 'l'; }
        if (Input.GetKeyDown(KeyCode.M)) { return 'm'; }
        if (Input.GetKeyDown(KeyCode.N)) { return 'n'; }
        if (Input.GetKeyDown(KeyCode.O)) { return 'o'; }
        if (Input.GetKeyDown(KeyCode.P)) { return 'p'; }
        if (Input.GetKeyDown(KeyCode.Q)) { return 'q'; }
        if (Input.GetKeyDown(KeyCode.R)) { return 'r'; }
        if (Input.GetKeyDown(KeyCode.S)) { return 's'; }
        if (Input.GetKeyDown(KeyCode.T)) { return 't'; }
        if (Input.GetKeyDown(KeyCode.U)) { return 'u'; }
        if (Input.GetKeyDown(KeyCode.V)) { return 'v'; }
        if (Input.GetKeyDown(KeyCode.W)) { return 'w'; }
        if (Input.GetKeyDown(KeyCode.X)) { return 'x'; }
        if (Input.GetKeyDown(KeyCode.Y)) { return 'y'; }
        if (Input.GetKeyDown(KeyCode.Z)) { return 'z'; }
        //上記以外のキーが押された場合は「null文字」を返す。
        return '\0';
    }
}