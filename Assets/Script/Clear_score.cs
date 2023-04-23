using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Clear_score : MonoBehaviour
{
    private Text score;
  /*  private GameObject SceneGameObject;
    private ScoreManager scoreManager;*/
    private int otherValue;
   
    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Text>();
        //Scene sc = SceneManager.GetSceneByName("DontDestroyOnLoad");
        /*
                SceneGameObject = GameObject.Find("SceneManager");//sc.GetRootGameObjects()[0].transform.Find("ScoreManager").gameObject;//sc.GameObject.Find("ScoreManager");
                scoreManager =SceneGameObject.GetComponent<ScoreManager>();*/
        otherValue = State_score.score;
        this.score.text = "Score:" +otherValue;
       

    }

    // Update is called once per frame
}
