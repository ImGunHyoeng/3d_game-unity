using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ontrigger_Check : MonoBehaviour
{
    public GameObject spawn;
    // Start is called before the first frame update
   

  
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow; // 외곽선 색상 설정
        Gizmos.DrawWireCube(transform.position, spawn.GetComponent<BoxCollider>().size); // 외곽선 그리기
    }


    // Update is called once per fra
}
