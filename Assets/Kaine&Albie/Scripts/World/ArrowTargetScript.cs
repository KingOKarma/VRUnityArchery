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
        
        GameManager.SpawnTarget(prefab);
        Destroy(gameObject);
    }

    public void StartRotate(bool rotating)
    {
        if (rotating)
        {
            shouldRotate = true;
        }
        else
        {
            shouldRotate = false;
        }
    }

    public void SetRotateSpeed(int speed)
    {
        RotationSpeed = speed;
    }
}

