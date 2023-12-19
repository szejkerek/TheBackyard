using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

/// <summary>
/// Controls the movement and interactions of the player character.
/// </summary>
public class PlayerMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float jumpHeight = 1.5f;
    [SerializeField] private float gravityForce = -9.81f;
    [SerializeField] private float jumpCooldown = 0.2f;
    [SerializeField] private KeyCode jumpKey = KeyCode.Space;

    public float JumpHeight => jumpHeight;

    [Tooltip("Distance for which ground layer is checked for")]
    [SerializeField] private float groundCastCheckDistance = 0.1f;

    [SerializeField] private float ceilingCastCheckDistance = 0.1f;

    [Tooltip("Distance for which ladder layer is checked for")]
    [SerializeField] private float ladderCastCheckDistance = 0.2f;

    [Space]
    [Header("Masks")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private LayerMask ladderMask;

    [Space]
    [Header("Visible internal variables (do not change)")]
    private Vector3 playerVelocity;
    private Vector3 playerFlatVelocity;
    private bool isGrounded;
    private bool hitCeiling;
    private bool isClimbingLadder;
    private Vector3 groundNormal;
    private Vector3 ladderNormal;

    public Vector3 Velocity => playerVelocity;
    public Vector3 FlatVelocity => playerFlatVelocity;

    private CharacterController controller;
    private Vector3 forward;
    private Vector3 right;
    private float lastJumpTimestamp;
    public Vector3 rightMovement;

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
        isGrounded = controller.isGrounded;
        hitCeiling = CheckForTopCollision(groundMask, ceilingCastCheckDistance) || CheckForTopCollision(ladderMask, ladderCastCheckDistance);
        isClimbingLadder = PlayerOnLadder();

        Vector3 forwardMovement = forward * Input.GetAxisRaw("Vertical");
        rightMovement = right * Input.GetAxisRaw("Horizontal");
        Vector3 wishDir = Vector3.Normalize(rightMovement + forwardMovement) * movementSpeed;

        if (isGrounded && playerVelocity.y < 0.0f)
        {
            playerVelocity.y = -5f;
        }

        if (!hitCeiling && Input.GetKeyDown(jumpKey) && isGrounded && Time.time - lastJumpTimestamp >= jumpCooldown)
        {
            lastJumpTimestamp = Time.time;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityForce);
        }

        playerVelocity.x = wishDir.x;
        playerVelocity.y += gravityForce * Time.deltaTime;
        playerVelocity.z = wishDir.z;

        playerFlatVelocity = new Vector3(playerVelocity.x, 0.0f, playerVelocity.z);

        if (isClimbingLadder)
        {
            CorrectLadderMovement();
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }

    /// <summary>
    /// Makes the player jump with a specified height.
    /// </summary>
    /// <param name="targetHeight">The target jump height.</param>
    public void JumpWithHeight(float targetHeight)
    {
        playerVelocity.y = Mathf.Sqrt(targetHeight * -3.0f * gravityForce);
    }

    private bool PlayerOnLadder()
    {
        bool isTouchingLadder = Physics.SphereCast(transform.position + Vector3.down, 0.5f, playerFlatVelocity, out RaycastHit rayHit, 0.5f, ladderMask);

        if (!isTouchingLadder)
        {
            return false;
        }

        return Vector3.Dot(playerFlatVelocity, rayHit.normal) < 0.0f;
    }

    private void CorrectLadderMovement()
    {
        if(Vector3.Dot(ladderNormal, Vector3.up) == 0.0f)
        {
            playerVelocity = Vector3.up * movementSpeed;

            return;
        }
    }

    private bool CheckForBottomCollision(LayerMask mask, float distance)
    {
        return Physics.CheckSphere(transform.position + Vector3.down, distance, mask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.right / 2.0f, distance, mask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.left / 2.0f, distance, mask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.back / 2.0f, distance, mask) ||
            Physics.CheckSphere(transform.position + Vector3.down + Vector3.forward / 2.0f, distance, mask);
    }

    private bool CheckForTopCollision(LayerMask mask, float distance)
    {
        return Physics.CheckSphere(transform.position + Vector3.up, distance, mask);
    }
}
