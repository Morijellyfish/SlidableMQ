using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TypingManager : MonoBehaviour
{
    public static int TaskNumber = 0;
    public static string[] TaskTexts =
    {
       "banana", "dance", "jump", "chair", "kitten", "eagle", "quartz", "oxygen", "apple", "zebra", "silver", "friend"
    };

    public static string TaskText = "";
    public static int TaskCount = 0;
    public static char Target //log用
    {
        get
        {

            if (TaskCount >= TaskText.Length)
            {
                return ' ';
            }
            else
            {
                return TaskText[TaskCount];
            }
        }
    }

    [SerializeField] TMP_Text TimeField;
    [SerializeField] TMP_Text TaskField;
    [SerializeField] TMP_Text InputField;
    [SerializeField] TMP_Text MessageField;
    static public TypingManager typingManager;
    static public double time = 0;
    double preTime = 0;

    void Start()
    {
        TaskNumber = 0;
        typingManager = this;
        SetTask(TaskTexts[TaskNumber]);
    }

    void Update()
    {
        //Timer
        if (TaskCount != 0 && TaskCount != TaskText.Length)
        {
            time += Time.timeAsDouble - preTime;
            TimeField.text = time.ToString(".000");
        }
        preTime = Time.timeAsDouble;

        //Typing(Keyboard)
        char c = GetCharFromKeyCode();
        CheckType(c);

        //TaskFinish
        if (TaskCount != 0)
        {
            InputField.text = TaskText.Substring(0, TaskCount);
        }
    }

    static public void CheckType(char c)
    {
        if (c != '\0')
        {
            if (CheckInput(c))
            {
                TaskCount++;
                if(TaskCount == TaskText.Length)
                {
                    NextTask();
                }
            }
        }

        bool CheckInput(char c)
        {
            if (TaskCount >= TaskText.Length)
            {
                return false;
            }
            return c == TaskText[TaskCount];
        }
    }

    static public void NextTask()
    {
        if (TaskNumber + 1 >= TaskTexts.Length)
        {
            typingManager.MessageField.text = "下に表示されるテキストを入力してください\r\n" + $"Finish!";
            return;
        }
        else
        {
            TaskNumber++;
            typingManager.SetTask(TaskTexts[TaskNumber]);
        }
    }

    void SetTask(string tasktext)
    {
        MessageField.text = "下に表示されるテキストを入力してください\r\n" + $"{TaskNumber+1}/{TaskTexts.Length}";
        TaskCount = 0;
        InputField.text = "";
        TaskText = tasktext;

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