using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletManager : MonoBehaviour
{
    // Start is called before the first frame update
   
    private Text sct;

    void Start()
    {
        GameObject bulletText = GameObject.Find("BulletUI");
        this.sct = bulletText.GetComponent<Text>(); ;

        Bullet();
    }
    public void Bullet()
    {
        int i=GameObject.Find("Bulletgen").GetComponent<BulletGenerator>().bullet_count();
        this.sct.text = "Bullet:" + i;
    }

}
