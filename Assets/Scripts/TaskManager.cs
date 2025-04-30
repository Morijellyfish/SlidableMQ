using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

static public class TaskManager
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

    //タスクのシャッフル,重複無し
    static public void ShuffleTasks()
    {
        System.Random rng = new System.Random();
        TaskTexts = TaskTexts.OrderBy(a => rng.Next()).ToArray();
    }

    //タスクの設定
    public static void SetTaskNumber(int number)
    {
        TaskNumber = number;
        TaskText = TaskTexts[number];
        TaskCount = 0;
        TypingManager.instance.SetTaskTexts(TaskTexts[number]);
    }

    //入力チェックと進行
    static public void CheckType(char c)
    {
        if (c != '\0')
        {
            if (CheckInput(c))
            {
                TaskCount++;
                TypingManager.instance.PlayAudio();
                if (TaskCount == TaskText.Length)
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

    //次のタスクへ
    static public void NextTask()
    {
        if (TaskNumber + 1 >= TaskTexts.Length) //終了
        {
            TypingManager.instance.MessageField.text = "下に表示されるテキストを入力してください\r\n" + $"Finish!";
            return;
        }
        else //次のタスク
        {
            SetTaskNumber(TaskNumber + 1);
        }
    }
}
