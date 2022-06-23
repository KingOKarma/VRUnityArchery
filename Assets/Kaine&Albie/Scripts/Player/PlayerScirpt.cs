using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class PlayerScirpt : MonoBehaviour
{

    private bool doOnceRightGrip = true;
    private bool doOnceLeftGrip = true;
    private bool doOnceRightGripLetGo = true;
    private bool doOnceLeftGripLetGo = true;

    [SerializeField]
    private GameObject ToSpawnInHand;

    [SerializeField]
    private GameObject RightHandLocation;

    [SerializeField]
    private GameObject LeftHandLocation;

    [SerializeField]
    private GameObject ToolTipForGrip;

    private bool isLeftGripping;
    private bool isRightGripping;
    private GameObject SpanwedObject;

    // Update is called once per frame
    void Update()
    {
        if (!ToSpawnInHand)
        {
            Debug.Log("Forgot to set spawn item for hands!!!!!");
            return;
        }

        List<InputDevice> devices = new List<InputDevice>();

        // Check right controller input
        InputDeviceCharacteristics rightControllerCharacteristics = InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rightControllerCharacteristics, devices);

        if (devices.Count <= 0) return;

        InputDevice rightController = devices[0];

        rightController.TryGetFeatureValue(CommonUsages.gripButton, out isRightGripping);
        if (isRightGripping && doOnceRightGrip && !isLeftGripping)
        {
            doOnceRightGrip = false;
            doOnceRightGripLetGo = true;
            RightControllerGrip();
        }
        else if (!isRightGripping && doOnceRightGripLetGo)
        {
            doOnceRightGrip = true;
            doOnceRightGripLetGo = false;
            RightControllerGripLetGo();
        }

        // Clear devices list to check for left now
        devices.Clear();

        // Check left controller input
        InputDeviceCharacteristics leftControllerCharacteristics = InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(leftControllerCharacteristics, devices);

        if (devices.Count <= 0) return;

        InputDevice leftController = devices[0];

        leftController.TryGetFeatureValue(CommonUsages.gripButton, out isLeftGripping);
        if (isLeftGripping && doOnceLeftGrip && !isRightGripping)
        {
            doOnceLeftGripLetGo = true;
            doOnceLeftGrip = false;
            LeftControllerGrip();
        }
        else if (!isLeftGripping && doOnceLeftGripLetGo)
        {
            doOnceLeftGrip = true;
            doOnceLeftGripLetGo = false;
            LeftControllerGripLetGo();
            Destroy(SpanwedObject);
        }

    }

    void RightControllerGrip()
    {
        if (!RightHandLocation) return;
        SpanwedObject = Instantiate(ToSpawnInHand, RightHandLocation.transform.position, RightHandLocation.transform.rotation);

    }

    void RightControllerGripLetGo()
    {
        Destroy(SpanwedObject);
    }

    void LeftControllerGrip()
    {
        if (!LeftHandLocation) return;
        if (ToolTipForGrip)
        {
            Destroy(ToolTipForGrip);
        }
        SpanwedObject = Instantiate(ToSpawnInHand, LeftHandLocation.transform.position, LeftHandLocation.transform.rotation);

    }
    void LeftControllerGripLetGo()
    {
        Destroy(SpanwedObject);
    }
}
