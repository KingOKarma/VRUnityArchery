using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyParent : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in transform)
        {
            DifficultyDecider childRef = child.GetComponent<DifficultyDecider>();

            GameEvents.current.onStartButton += childRef.BeginSelection;
        }
    }

}
