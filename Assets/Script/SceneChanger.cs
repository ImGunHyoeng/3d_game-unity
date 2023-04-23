using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void ChangeSceneBtn()
    {
        switch (this.gameObject.name) 
        {
            case "Title":
                SceneManager.LoadScene("Title");
                break;

            case "Rule":
                SceneManager.LoadScene("Rule");
                break;
                
            case "GameStart":
                SceneManager.LoadScene("Main");
                break;
            case "Close":
                Application.Quit();
                break;

        }
    }
}
