using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImaginationEffect : MonoBehaviour
{
    private ProjectImagination[] pi;
    private void Start()
    {
        pi = GameObject.FindObjectsOfType<ProjectImagination>();
    }

    private void Update()
    {
     foreach(ProjectImagination pim in pi)
        {
            if(Vector3.Distance(pim.transform.position, transform.position) < 2f)
            {
                pim.ChangeState(true);
            }
            else
            {
                pim.ChangeState(false);
            }
        }
    }
}
