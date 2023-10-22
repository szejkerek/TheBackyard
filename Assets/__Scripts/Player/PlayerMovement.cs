using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions;

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

    //[Tooltip("Distance for which ground (ceiling) layer is checked for")]
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
    //[SerializeField] private float playerSpeed;
    private bool isGrounded;
    [SerializeField] private bool hitCeiling;
    //[SerializeField] private bool isOnDownSlope;
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
        //isGrounded = CheckForBottomCollision(groundMask, groundCastCheckDistance) || CheckForBottomCollision(ladderMask, ladderCastCheckDistance);
        hitCeiling = CheckForTopCollision(groundMask, ceilingCastCheckDistance) || CheckForTopCollision(ladderMask, ladderCastCheckDistance);
        //isOnDownSlope = PlayerOnDownSlope();
        isClimbingLadder = PlayerOnLadder();

        Vector3 forwardMovement = forward * Input.GetAxisRaw("Vertical");
        rightMovement = right * Input.GetAxisRaw("Horizontal");
        Vector3 wishDir = Vector3.Normalize(rightMovement + forwardMovement) * movementSpeed;

        if (isGrounded && playerVelocity.y < 0.0f /*|| hitCeiling && playerVelocity.y > 0.0f*/)
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

        /*if(isOnDownSlope)
        {
            playerVelocity = Vector3.ProjectOnPlane(playerFlatVelocity, groundNormal).normalized * movementSpeed + Vector3.up * playerVelocity.y;
        }*/

        if(isClimbingLadder)
        {
            CorrectLadderMovement();
        }

        //playerSpeed = playerVelocity.magnitude; //po co to?
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void JumpWithHeight(float targetHeight)
    {
        playerVelocity.y = Mathf.Sqrt(targetHeight * -3.0f * gravityForce);
    }

    private bool PlayerOnDownSlope()
    {
        Ray ray = new(transform.position + Vector3.down, Vector3.down);
        Physics.Raycast(ray, out RaycastHit rayHit, 0.5f);

        float angle = Vector3.Angle(Vector3.up, rayHit.normal);
        groundNormal = rayHit.normal;

        return angle > 0.0f && angle < controller.slopeLimit && Vector3.Dot(groundNormal, playerFlatVelocity) > 0.0f;
    }

    private bool PlayerOnLadder()
    {
        bool isTouchingLadder = Physics.SphereCast(transform.position + Vector3.down, 0.5f, playerFlatVelocity, out RaycastHit rayHit, 0.5f, ladderMask);
        
        if(!isTouchingLadder)
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
