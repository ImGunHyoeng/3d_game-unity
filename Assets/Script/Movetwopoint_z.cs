using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movetwopoint_z : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;
    bool ison=false;

    bool one = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ison)
        {
            if (one)
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(p1.transform.position.x, transform.position.y, transform.position.z), 3f * Time.deltaTime);
            else
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(p2.transform.position.x, transform.position.y, transform.position.z), 3f * Time.deltaTime);
        }
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        { ison = true; }
    }
}
