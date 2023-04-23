using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpawncountManager : MonoBehaviour
{
    // Start is called before the first frame update
    private Text sct;

    void Start()
    {
        GameObject LifeText = GameObject.Find("Life");
        this.sct =LifeText.GetComponent<Text>(); 

        Life();
    }
    public void Life()
    {
        int i = GameObject.Find("Player").GetComponent<Player_Controller>().getrespawncount();
        this.sct.text = "Life:" + i;
    }
}
