using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTargetScript : MonoBehaviour
{

    [SerializeField]
    private bool shouldRotate = false;

    [SerializeField]
    private float RotationSpeed = 5f;

    void FixedUpdate()
    {
        // Should the target rotate?
        if (!shouldRotate) return;

        // Rotate the target on it's Z axis
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }

    void RotateEnd()
    {
       Destroy(gameObject);
    }

}
