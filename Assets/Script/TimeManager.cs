using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    private float time;
    private Text timeT;
    public int maxtime = 180;
    void Start()
    {
        GameObject scoreText = GameObject.Find("Time");
        this.timeT = scoreText.GetComponent<Text>(); ;
        time = maxtime ;
        Timer();
    }
    private void FixedUpdate()
    {
        time-=Time.deltaTime;
        Timer();
    }
    void Setscore(int value)
    {
        time += value;//음수여도 더해서 추가
    }
    public void Timer()
    {
        this.timeT.text = "Time:" + (int)time;
    }
}
