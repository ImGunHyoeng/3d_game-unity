using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigball : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Deadzone")
        {
            Destroy(gameObject);
        }
    }
}
