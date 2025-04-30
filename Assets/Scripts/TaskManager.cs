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
    public static char Target //log�p
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

    //�^�X�N�̃V���b�t��,�d������
    static public void ShuffleTasks()
    {
        System.Random rng = new System.Random();
        TaskTexts = TaskTexts.OrderBy(a => rng.Next()).ToArray();
    }

    //�^�X�N�̐ݒ�
    public static void SetTaskNumber(int number)
    {
        TaskNumber = number;
        TaskText = TaskTexts[number];
        TaskCount = 0;
        TypingManager.instance.SetTaskTexts(TaskTexts[number]);
    }

    //���̓`�F�b�N�Ɛi�s
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

    //���̃^�X�N��
    static public void NextTask()
    {
        if (TaskNumber + 1 >= TaskTexts.Length) //�I��
        {
            TypingManager.instance.MessageField.text = "���ɕ\�������e�L�X�g����͂��Ă�������\r\n" + $"Finish!";
            return;
        }
        else //���̃^�X�N
        {
            SetTaskNumber(TaskNumber + 1);
        }
    }
}
