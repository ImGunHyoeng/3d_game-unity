using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    float spawntime;
    float max;
    public GameObject prefab_ball;
    // Start is called before the first frame update
    void Awake()
    {
        
        max = Random.RandomRange(5f, 12f);
        //Instantiate(prefab_ball, transform);
        spawntime = max;
    }

    // Update is called once per frame
    private void Update()
    {
        spawntime-= Time.deltaTime;
        if(spawntime < 0)
        {
            Instantiate(prefab_ball, transform);
            spawntime = max;
        }
    }
    
}
