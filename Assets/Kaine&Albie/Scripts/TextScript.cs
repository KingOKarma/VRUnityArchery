using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

        if (!playerRef) return;

        Vector3 targetVector = playerRef.transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(targetVector, Vector3.up);
    }
}
