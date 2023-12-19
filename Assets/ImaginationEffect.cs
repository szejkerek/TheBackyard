using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the imagination effect based on the proximity to ProjectImagination objects.
/// </summary>
public class ImaginationEffect : MonoBehaviour
{
    private ProjectImagination[] pi;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    private void Start()
    {
        // Find all ProjectImagination objects in the scene.
        pi = GameObject.FindObjectsOfType<ProjectImagination>();
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    private void Update()
    {
        // Check the distance between this object and each ProjectImagination object.
        foreach (ProjectImagination pim in pi)
        {
            if (Vector3.Distance(pim.transform.position, transform.position) < 2f)
            {
                // If the distance is less than 2 units, change the state of the ProjectImagination object to true.
                pim.ChangeState(true);
            }
            else
            {
                // If the distance is greater than or equal to 2 units, change the state of the ProjectImagination object to false.
                pim.ChangeState(false);
            }
        }
    }
}