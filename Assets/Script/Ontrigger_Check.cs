using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger_Check : MonoBehaviour
{
    public GameObject spawn;
    // Start is called before the first frame update
   

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // �ܰ��� ���� ����
        Gizmos.DrawWireCube(transform.position, spawn.GetComponent<BoxCollider>().size); // �ܰ��� �׸���
    }


    // Update is called once per fra
}
