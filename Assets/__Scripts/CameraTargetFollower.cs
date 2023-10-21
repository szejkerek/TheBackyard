using UnityEngine;

public class CameraTargetFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    private PlayerMovement playerMovement;

    public Vector3 initOffset;

    private bool validTarget = true;

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
        transform.position = playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight;
    }

    void LateUpdate()
    {
        if (!validTarget) return;

        transform.position = Vector3.Lerp(transform.position, playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight, speed * Time.deltaTime);
    }
}
