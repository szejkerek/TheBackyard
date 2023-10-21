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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("i") && Imagination==true)
        {
            Debug.Log("imag");
            RealObject.SetActive(true);
            ImaginaryObject.SetActive(false);
            Imagination = false;
        }
        else if (Input.GetKeyDown("i") && Imagination==false)
        {
            Debug.Log("imag2");
            RealObject.SetActive(false);
            ImaginaryObject.SetActive(true);
            Imagination = true;
        }


    }
}
