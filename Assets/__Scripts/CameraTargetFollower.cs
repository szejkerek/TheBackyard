using UnityEngine;

public class CameraTargetFollower : MonoBehaviour
{
    [SerializeField] private Transform targetTransform;
    [SerializeField] private Vector3 viewOffset;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - targetTransform.position;
    }

    void LateUpdate()
    {
        transform.position = targetTransform.position + viewOffset + offset;
    }
}
