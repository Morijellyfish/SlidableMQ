using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointKeyboardCont : MonoBehaviour
{
    [SerializeField] GameObject keyboard;

    [SerializeField] GameObject PointerL;
    [SerializeField] GameObject PointerR;

    // Start is called before the first frame update
    void Start()
    {
        keyboard.SetActive(GameMode.mode == GameMode.InputMode.PointKeys);
    }

    private void Update()
    {
        Vector3 tmpPos;

        tmpPos = keyboard.transform.InverseTransformPoint(PointerL.transform.position);
        if (Mathf.Abs(tmpPos.z) < 0.1f)
        {
            PointLogger.Point_L = tmpPos;
        }

        tmpPos = keyboard.transform.InverseTransformPoint(PointerR.transform.position);
        if (Mathf.Abs(tmpPos.z) < 0.1f)
        {
            PointLogger.Point_R = tmpPos;
        }
    }
}
