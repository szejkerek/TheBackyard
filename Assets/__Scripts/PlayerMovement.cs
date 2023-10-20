using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravityForce = -9.81f;
    [SerializeField] private float jumpCooldown = 0.2f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    [Tooltip("Distance for which ground layer is checked for")]
    [SerializeField] private float groundCastCheckDistance = 0.1f;

    [Tooltip("Distance for which ground (ceiling) layer is checked for")]
    [SerializeField] private float ceilingCastCheckDistance = 0.1f;

    [Space]
    [Header("Masks")]
    [SerializeField] private LayerMask groundMask;

    [Space]
    [Header("Visible internal variables (do not change)")]
    [SerializeField] private Vector3 playerVelocity;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool hitCeiling;

    private CharacterController controller;
    private Vector3 forward;
    private Vector3 right;
    private float lastJumpTimestamp;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0.0f;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(Vector3.up * 90.0f) * forward;
    }

    private void Update()
    {
        isGrounded = CheckForGroundCollision();
        hitCeiling = CheckForCeilingCollision();

        Vector3 forwardMovement = forward * Input.GetAxisRaw("Vertical");
        Vector3 rightMovement = right * Input.GetAxisRaw("Horizontal");
        Vector3 wishDir = Vector3.Normalize(rightMovement + forwardMovement) * movementSpeed;

        if (isGrounded && playerVelocity.y < 0.0f || hitCeiling && playerVelocity.y > 0.0f)
        {
            playerVelocity.y = 0.0f;
        }

        if (Input.GetKey(jumpKey) && isGrounded && Time.time - lastJumpTimestamp >= jumpCooldown)
        {
            lastJumpTimestamp = Time.time;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityForce);
        }

        playerVelocity.x = wishDir.x;
        playerVelocity.y += gravityForce * Time.deltaTime;
        playerVelocity.z = wishDir.z;

        controller.Move(playerVelocity * Time.deltaTime);
    }

    private bool CheckForGroundCollision()
    {
        return Physics.CheckSphere(transform.position + Vector3.down, groundCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.right, groundCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.left, groundCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.back, groundCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.forward, groundCastCheckDistance, groundMask);
    }

    private bool CheckForCeilingCollision()
    {
        return Physics.CheckSphere(transform.position + Vector3.up, ceilingCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.up + Vector3.right, ceilingCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.up + Vector3.left, ceilingCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.up + Vector3.back, ceilingCastCheckDistance, groundMask) ||
            Physics.CheckSphere(transform.position + Vector3.up + Vector3.forward, ceilingCastCheckDistance, groundMask);
    }
}
