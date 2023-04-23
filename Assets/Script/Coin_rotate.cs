using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin_rotate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        transform.Rotate(0, 90 * Time.deltaTime, 0);
    }
}
