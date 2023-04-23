using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
  
    // �Ѿ� �߻� �Լ�
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
             // �浹�ϰ� 0.2�� �Ŀ� ������Ʈ ����
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
