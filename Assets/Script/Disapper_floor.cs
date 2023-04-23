using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disapper_floor : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator disappear()
    {

        GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            StartCoroutine(disappear());
        }
    }
}
