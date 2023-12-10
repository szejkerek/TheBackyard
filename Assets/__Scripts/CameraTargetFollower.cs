using UnityEngine;

/// <summary>
/// Follows the target (Player) with a specified speed and offset.
/// </summary>
public class CameraTargetFollower : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;

    private PlayerMovement playerMovement;
    private bool validTarget = true;
    private Vector3 initOffset;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        // Find the PlayerMovement component in the scene.
        playerMovement = FindObjectOfType<PlayerMovement>();

        // If PlayerMovement is not found, set validTarget to false.
        if (playerMovement == null)
        {
            validTarget = false;
        }
    }

    /// <summary>
    /// Called on the frame when a script is enabled.
    /// </summary>
    void Start()
    {
        // If the target is not valid, return.
        if (!validTarget) return;

        // Store the initial offset and set the camera position.
        initOffset = transform.position;
        transform.position = playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight + offset;
    }

    /// <summary>
    /// LateUpdate is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void LateUpdate()
    {
        // If the target is not valid, return.
        if (!validTarget) return;

        // Smoothly interpolate the camera position towards the target's position.
        transform.position = Vector3.Lerp(transform.position, playerMovement.transform.position + initOffset + Vector3.up * playerMovement.JumpHeight + offset, speed * Time.deltaTime);
    }
}