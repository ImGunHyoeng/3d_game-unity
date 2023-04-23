using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    GameObject p1;
    GameObject p2;
    float random;
    bool one = false;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(4, 10);
        p1 = GameObject.Find("1");
        p2 = GameObject.Find("2");
    }

    // Update is called once per frame
    void Update()
    {
        if(one)
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(p1.transform.position.x, transform.position.y, transform.position.z), random * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(p2.transform.position.x, transform.position.y, transform.position.z), random * Time.deltaTime);

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="roop")
        {
            if (one)
                one = false;
            else 
                one=true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Unbeatable")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag=="Player")
        {
            Rigidbody col=collision.gameObject.GetComponent<Rigidbody>();
            col.AddForce(transform.forward*random * Time.deltaTime);
        }
        
    }
}
