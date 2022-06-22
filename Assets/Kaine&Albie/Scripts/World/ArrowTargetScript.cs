using UnityEngine;

public class ArrowTargetScript : MonoBehaviour
{

    [SerializeField]
    private bool shouldRotate = false;

    [SerializeField]
    private float RotationSpeed = 5f;

    [SerializeField]
    private GameObject prefab;



    void FixedUpdate()
    {
        // Should the target rotate?
        if (!shouldRotate) return;

        // Rotate the target on it's Z axis
        transform.Rotate(Vector3.forward * (RotationSpeed * Time.deltaTime));
    }

    void RotateEnd()
    {
        GameObject playerRef = GameObject.FindGameObjectWithTag("Player");

        Vector3 Loc = playerRef.transform.position + new Vector3(Random.Range(0, 15), Random.Range(-0.5f, 10), Random.Range(0, 15));


        // // Get the vector look vector from the player and target
        Vector3 targetVector = playerRef.transform.position - Loc;

        // // Look at player
        Quaternion lookAtRot = Quaternion.LookRotation(targetVector, Vector3.up);

        // GameObject newTarget = Instantiate(prefab, Loc, lookAtRot);


        GameObject newTarget = Instantiate(prefab, Loc, lookAtRot);

        newTarget.transform.GetChild(0).GetChild(0).GetComponent<Collider>().isTrigger = false;
        newTarget.transform.GetChild(0).GetComponent<Animator>().SetBool("ShouldSpin", false);


        Destroy(gameObject);

    }




}
