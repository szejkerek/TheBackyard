using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectImagination : MonoBehaviour
{
    public GameObject ImaginaryObject;
    public GameObject RealObject;
    private bool Imagination;

    void Start()
    {
        RealObject.SetActive(true);
        ImaginaryObject.SetActive(false);
        Imagination = false;
    }

    public void ChangeState(bool imaginaryVersion)
    {
        RealObject.SetActive(!imaginaryVersion);
        ImaginaryObject.SetActive(imaginaryVersion);
        Imagination = !imaginaryVersion;
    }
}
