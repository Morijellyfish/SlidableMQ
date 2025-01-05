using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class Hand_Cont_SlideKeys : MonoBehaviour
{
    [SerializeField] InputDeviceCharacteristics LR; //自分がどのコントローラーを管理するか
    [SerializeField] int Span; //左右で変える事は無いだろうけど

    public int input_Y;

    TMP_Text tmp; //手元の奴
    [SerializeField] RawImage Cursor;

    bool triggerValue = false;

    private void Start()
    {
        tmp = GetComponentInChildren<TMP_Text>();
        

    }

    int SelectedX = 0;
    void Update()
    {
        if(GameMaster.SlideMode == false)
        {
            tmp.gameObject.SetActive(false);
            this.enabled = false;
        }

        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);

        //Debug.DrawRay(transform.position, transform.forward, Color.red, 0.1f);

        foreach(var device in inputDevices)
        {
            if (device.characteristics == LR)
            {
                float HandAngle = transform.rotation.eulerAngles.y;
                HandAngle   =   HandAngle >= 180 ?   HandAngle - 360 : HandAngle;
                float CameraAngle = Camera.main.transform.rotation.eulerAngles.y;
                CameraAngle = CameraAngle >= 180 ? CameraAngle - 360 : CameraAngle;
                float DiffAngle = HandAngle - CameraAngle;
                int SelectingX = (int)(Mathf.Abs(DiffAngle) / Span);
                SelectingX = DiffAngle >= 0 ? SelectingX : -(SelectingX + 1);
                SelectingX += 5;
                //上下入力
                device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 Axis);
                if (0.9 < Axis.y)
                {
                    input_Y = 0;
                }
                else if (-0.9 < Axis.y)
                {
                    input_Y = 1;
                }
                else
                {
                    input_Y = 2;
                }

                //log
                if (LR.HasFlag(InputDeviceCharacteristics.Left))
                {
                    PointLogger.Point_L = new Vector2(DiffAngle, input_Y);
                }
                if (LR.HasFlag(InputDeviceCharacteristics.Right))
                {
                    PointLogger.Point_R = new Vector2(DiffAngle, input_Y);
                }

                //ui
                Cursor.rectTransform.anchoredPosition = new Vector2(SelectingX * 100 - 450, input_Y * -100 + 100);

                if(SelectingX != SelectedX)
                {
                    SelectedX = SelectingX;
                    device.SendHapticImpulse(0, 1);
                }
                //選択出来てる範囲の角度
                if (0 <= SelectingX && SelectingX <= 9)
                {
                    tmp.text = KeyBoard_Array.chKeyBoard[input_Y, SelectingX].ToString();
                    //トリガー入力
                    if (!triggerValue && device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                    {
                        //keyInput.InputKD(KeyBoard_Array.KeyBoard[input_Y, SelectingX]);
                        //keyInput.InputKU(KeyBoard_Array.KeyBoard[input_Y, SelectingX]);
                        TypingManager.CheckType(KeyBoard_Array.chKeyBoard[input_Y, SelectingX]);

                        //Debug.Log("Button : " + KeyBoard_Array.KeyBoard[input_Y, SelectingX]);
                    }
                    else
                    {
                        device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue);
                    }
                }
                else
                {
                    tmp.text = "";
                }
            }
        }
    }
}
