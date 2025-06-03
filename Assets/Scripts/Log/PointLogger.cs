using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PointLogger : MonoBehaviour
{
    static public Vector2 Point_L;
    static public Vector2 Point_R;

    [SerializeField] GameObject Head;
    [SerializeField] GameObject LeftHand;
    [SerializeField] GameObject RightHand;

    static public bool TriggerL = false;
    static public bool TriggerR = false;

    bool Saved = false;
    string tmplog = "";

    private void Start()
    {
        Debug.Log("path : " + Application.persistentDataPath);
    }

    void FixedUpdate()
    {
        char target = TaskManager.Target;

        //保存状態の確認
        if (target == ' ')
        {
            if (!Saved)
            {
                FileSave();
            }
        }
        if (TypingManager.time == 0)
        {
            Saved = false;
        }

        //TimeUp
        if (TypingManager.time >= 600) //10min
        {
            return;
        }
        //ログの必要無し
        if (target == ' ' || TypingManager.time == 0)
        {
            return;
        }

        //TargetPosの計算
        Vector2 targetPos = Vector2.zero;
        Vector2 targetIndex = KeyBoard_Array.KeyPositions[target];
        switch (GameMode.mode)
        {
            case GameMode.InputMode.SlideKeys:
                targetPos.x = targetIndex.x;
                targetPos.y = targetIndex.y;
                break;
            case GameMode.InputMode.PointKeys:
                targetPos.x = 0.43f + (Mathf.Abs(targetIndex.x) - 1) * 0.7f;
                targetPos.x *= targetIndex.x < 0 ? -1 : 1;
                targetPos.y = targetIndex.y * 0.7f;
                break;
            case GameMode.InputMode.StickKeys:
                break;
            case GameMode.InputMode.Keyboard:
                break;
            default:
                break;
        }

        //タイプ可能か確認
        bool typable_L = false;
        bool typable_R = false;
        switch (GameMode.mode)
        {
            case GameMode.InputMode.SlideKeys:
                typable_L = target == LeftHand.GetComponent<Hand_Cont_SlideKeys>().selectingChar;
                typable_R = target == RightHand.GetComponent<Hand_Cont_SlideKeys>().selectingChar;
                break;
            case GameMode.InputMode.PointKeys:
                typable_L = Mathf.Abs(Point_L.x - targetPos.x) <= 0.25f && Mathf.Abs(Point_L.y - targetPos.y) <= 0.25f;
                typable_R = Mathf.Abs(Point_R.x - targetPos.x) <= 0.25f && Mathf.Abs(Point_R.y - targetPos.y) <= 0.25f;
                break;
            case GameMode.InputMode.StickKeys:
                break;
            case GameMode.InputMode.Keyboard:
                break;
            default:
                break;
        }

        Debug.Log("typable_L : " + typable_L + ", typable_R : " + typable_R);

        //ログ
        string log = $"";
        log += $"{Point_L.x:F3},{Point_L.y:F3},{Point_R.x:F3},{Point_R.y:F3},{targetPos.x},{targetPos.y},";
        log += $"{target},{TaskManager.TaskCount},{TypingManager.time:F4},{GameMode.mode.ToString()},";
        log += $"{typable_L},{typable_R},";
        log += $"{Head.transform.position},{Head.transform.rotation},";
        log += $"{TriggerL},{LeftHand.transform.position},{LeftHand.transform.rotation},";
        log += $"{TriggerR},{RightHand.transform.position},{RightHand.transform.rotation}";
        log += "\r\n";
        tmplog += log;
        //Debug.Log(log);
    }

    void FileSave()
    {
        string path = Path.Combine(Application.persistentDataPath, DateTime.Now.ToString("yyyyMMddHHmmss-") + "log.csv");
        Saved = true;
        string firstLine = $"";
        firstLine += $"Lx,Ly,Rx,Ry,Tx,Ty,";
        firstLine += $"Target,TaskCount,Time,InputMode,";
        firstLine += $"TypeableL,TypeableR,";
        firstLine += $"HeadPosition,HeadRotation,";
        firstLine += $"LTrigger,LHandP,LHandR,";
        firstLine += $"RTrigger,RHandP,RHandR";
        firstLine += $"\r\n";
        tmplog = firstLine + tmplog;
        File.AppendAllText(path, tmplog);
        tmplog = "";
        Debug.Log("Saved");
    }
}
