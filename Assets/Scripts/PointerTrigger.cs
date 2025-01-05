using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointerTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent TriggerEvents;
    [SerializeField] UnityEvent SelectEvents;

    public void Trigger()
    {
        Debug.Log("Fire!");
        TriggerEvents.Invoke();
    }

    public void Select()
    {
        SelectEvents.Invoke();
    }
}
