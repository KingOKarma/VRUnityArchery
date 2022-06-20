using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class enableTrailArrow : MonoBehaviour
{


    [SerializeField]
    private GameObject renderTrail;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<Arrow>().Flying)
        {renderTrail.SetActive(true);

        }
    }
}
