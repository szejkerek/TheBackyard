using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Represents an object with both real and imaginary versions, allowing for state changes.
/// </summary>
public class ProjectImagination : MonoBehaviour
{
    /// <summary>
    /// The GameObject representing the imaginary version of the object.
    /// </summary>
    public GameObject ImaginaryObject;

    /// <summary>
    /// The GameObject representing the real version of the object.
    /// </summary>
    public GameObject RealObject;

    /// <summary>
    /// Indicates whether the object is currently in the imaginary state.
    /// </summary>
    private bool Imagination;

    /// <summary>
    /// Initializes the object, setting the real version to active and the imaginary version to inactive.
    /// </summary>
    void Start()
    {
        RealObject.SetActive(true);
        ImaginaryObject.SetActive(false);
        Imagination = false;
    }

    /// <summary>
    /// Changes the state of the object based on the provided imaginary version flag.
    /// </summary>
    /// <param name="imaginaryVersion">Flag indicating whether to switch to the imaginary version.</param>
    public void ChangeState(bool imaginaryVersion)
    {
        RealObject.SetActive(!imaginaryVersion);
        ImaginaryObject.SetActive(imaginaryVersion);
        Imagination = !imaginaryVersion;
    }
}