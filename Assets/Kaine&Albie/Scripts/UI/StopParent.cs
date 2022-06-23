using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopParent : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.onStartGame += transform.GetChild(0).GetComponent<StopScript>().ShowStopButton;
        GameEvents.current.onEndGame += transform.GetChild(0).GetComponent<StopScript>().HideStopButton;
    }
}
