using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ������ ����
    public int bulletPower = 500;
    private int bulletcount;
    private int bullet_max = 3;
    BulletManager bullet_UI;
    private void Start()
    {
        bulletcount = bullet_max;
        bullet_UI=GameObject.Find("BulletUI").GetComponent<BulletManager>();
        //bullet_UI.Bullet();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletcount > 0)
        {
            bulletcount--;
            bullet_UI.Bullet();
            // Prefab�� �̿��Ͽ� ������Ʈ ����
            GameObject bulletObj = Instantiate(bulletPrefab, // ������ prefab ����
            transform.position, transform.rotation); // ������ ��ġ�� ����
                                                     // BulletController script�� ã�� shootBullet() ȣ��(�Ѿ� �߻�) 
            Vector3 vecBullet = new Vector3(0, 0, bulletPower);
            BulletController bulletControllerScr = bulletObj.GetComponent<BulletController>();
            bulletControllerScr.shootBullet(vecBullet);

            Destroy(bulletObj, 10f);
        }
    }
    public void bullet_reload()
    {
        bulletcount = bullet_max;
        bullet_UI.Bullet();
    }
    public int  bullet_count()
    {
        return bulletcount;
    }
}
