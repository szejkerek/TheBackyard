using UnityEngine;

public class CameraTargetFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    private PlayerMovement playerMovement;
    private bool validTarget = true;
    private Vector3 initOffset;

    private void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();

        if(playerMovement == null)
        {
            validTarget = false;
        }
    }
    void Start()
    {
        if (!validTarget) return;

        initOffset = transform.position;
        transform.position = playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight + offset;
    }

    void LateUpdate()
    {
        if (!validTarget) return;

        transform.position = Vector3.Lerp(transform.position, playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight + offset, speed * Time.deltaTime);
    }
}
