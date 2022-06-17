using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTargetScript : MonoBehaviour
{

    [SerializeField]
    private bool shouldRotate = false;

    [SerializeField]
    private float RotationSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (!shouldRotate) return;
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }
}
