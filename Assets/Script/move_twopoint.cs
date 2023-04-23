using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_twopoint : MonoBehaviour
{
    GameObject p1;
    GameObject p2;
  
    bool one = false;
    // Start is called before the first frame update
    void Start()
    {
        
        p1 = GameObject.Find("D1");
        p2 = GameObject.Find("D2");
    }

    // Update is called once per frame
    void Update()
    {
        if (one)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, p1.transform.position.z), 3f* Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y, p2.transform.position.z),  3f*Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "roop")
        {
            if (one)
                one = false;
            else
                one = true;
        }
    }
}
