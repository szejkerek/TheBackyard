using UnityEngine;

public class CameraTargetFollower : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private float speed;

    public Vector3 initOffset;

    void Start()
    {
        initOffset = transform.position;
        transform.position = playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight;
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight, speed * Time.deltaTime);
    }
}
