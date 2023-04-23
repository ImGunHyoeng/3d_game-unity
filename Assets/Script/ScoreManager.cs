using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    
    private Text sct;
    GameObject scoreText;

/*    private static bool _instance=false;

    private void Awake()
    {
        if (_instance == false)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }*/
    void Start()
    {
       // DontDestroyOnLoad(this.gameObject);
        scoreText = GameObject.Find("Score");
        this.sct = scoreText.GetComponent<Text>(); ;
        score = 0;
        Score();
    }
    public void Setscore(int value)
    {
        score += value;//음수여도 더해서 추가
        Score();
    }
    public int Getscore()
    {
        return score;
    }
    public void Score()
    {
        this.sct.text = "Score:" + score;
    }
    // Update is called once per frame
 
}
