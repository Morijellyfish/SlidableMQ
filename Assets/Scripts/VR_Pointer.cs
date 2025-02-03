using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class VR_Pointer : MonoBehaviour
{
    [SerializeField] GameObject Pointer;

    [SerializeField] InputDeviceCharacteristics LR; //自分がどのコントローラーを管理するか

    bool triggerValue = false;

    void Update()
    {
        //Ray
        Vector3 target = transform.forward;
        Ray ray = new Ray(transform.position, target);
        if (Physics.Raycast(ray, out RaycastHit hit, 50.0f))
        {
            Pointer.SetActive(true);
            Pointer.transform.position = hit.point;
            Pointer.transform.LookAt(transform.position);
            if (hit.transform && hit.transform.gameObject.TryGetComponent<PointerTrigger>(out var pointerTrigger))
            {
                pointerTrigger.Select();
            }
        }
        else
        {
            Pointer.SetActive(false);
        }
        Debug.DrawRay(transform.position, target * 50.0f, Color.red, 0.1f);

        //Input
        var inputDevices = new List<InputDevice>();
        InputDevices.GetDevices(inputDevices);
        foreach (var device in inputDevices)
        {
            if (device.characteristics == LR)
            {
                if (!triggerValue && device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
                {
                    if (hit.transform && hit.transform.gameObject.TryGetComponent<PointerTrigger>(out var pointerTrigger))
                    {
                        pointerTrigger.Trigger();
                    }
                }
                else
                {
                    device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue);
                }
            }
        }
    }
}
