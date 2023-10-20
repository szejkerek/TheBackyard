using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float jumpHeight = 1.5f;
    [SerializeField] float jumpCooldown = 0.5f; // Add a jump cooldown
    [SerializeField] float groundRaycastDistance = 0.2f; // Distance for ground raycast

    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private CharacterController controller;
    private Vector3 forward, right;
    private float gravityValue = -9.81f;
    private float lastJumpTime;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }

    void Update()
    {
        groundedPlayer = IsGrounded();

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Movement();

        if (Input.GetKeyDown(KeyCode.Space) && groundedPlayer && Time.time - lastJumpTime >= jumpCooldown)
        {
            lastJumpTime = Time.time;
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void Movement()
    {
        Vector3 rightMovement = right * Input.GetAxis("Horizontal");
        Vector3 upMovement = forward * Input.GetAxis("Vertical");

        Vector3 moveVector = rightMovement + upMovement;
        float magnitude = Mathf.Clamp01(moveVector.magnitude) * playerSpeed;
        moveVector.Normalize();

        controller.SimpleMove(moveVector * magnitude);
    }

    private bool IsGrounded()
    {      
        Ray groundRay = new Ray(transform.position, Vector3.down);  
        return Physics.Raycast(groundRay, groundRaycastDistance);
    }
}
