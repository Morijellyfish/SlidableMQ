using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if(target == ' ')
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
        if(TypingManager.time >= 100)
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
        if (GameMaster.SlideMode)
        {
            targetPos.y = targetIndex.y;
        }
        else
        {
            targetPos.x = 0.43f + (Mathf.Abs(targetIndex.x) - 1) * 0.7f;
            targetPos.x *= targetIndex.x < 0 ? -1 : 1;
            targetPos.y = targetIndex.y * 0.7f;
        }

        //ログ
        string log = $"{Point_L.x:F3},{Point_L.y:F3},{Point_R.x:F3},{Point_R.y:F3},{targetPos.x},{targetPos.y},{target},{TypingManager.time:F4},{GameMaster.SlideMode},";
        log += $"{Head.transform.position},{Head.transform.rotation},";
        log += $"{TriggerL},{LeftHand.transform.position},{LeftHand.transform.rotation},";
        log += $"{TriggerR},{RightHand.transform.position},{RightHand.transform.rotation}";
        log += "\r\n";
        tmplog += log;
        Debug.Log(log);
    }

    void FileSave()
    {
        string path = Path.Combine(Application.persistentDataPath, System.DateTime.Now.ToString("yyyyMMddHHmmss-") + "log.csv");
        Saved = true;
        tmplog = "Lx,Ly,Rx,Ry,Tx,Ty,Target,Time,SlideMode,HeadP,HeadR,LTrigger,LHandP,LHandR,RTrigger,RHandP,RHandR\r\n" + tmplog;
        File.AppendAllText(path, tmplog);
        tmplog = "";
        Debug.Log("Saved");
    }
}
