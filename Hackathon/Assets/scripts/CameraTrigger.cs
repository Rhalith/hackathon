using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject tablecam;
    private void OnTriggerEnter(Collider other)
    {
        
       tablecam.SetActive(true);
        
    }
}
