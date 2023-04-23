using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
  
    // 총알 발사 함수
    public void shootBullet(Vector3 vecBullet)
    {
        Rigidbody rigBody = GetComponent<Rigidbody>();
        rigBody.AddForce(vecBullet);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Destroy(collision.gameObject);
             // 충돌하고 0.2초 후에 오브젝트 삭제
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }
        else 
        {
            Destroy(gameObject);
        }

        
    }

}
