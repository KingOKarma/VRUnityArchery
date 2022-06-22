using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class EnableTrailArrow : MonoBehaviour
{


    [SerializeField]
    private GameObject renderTrail;

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<Arrow>().Flying)
        {
            renderTrail.SetActive(true);
        }
    }
}
