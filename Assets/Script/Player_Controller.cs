using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
  
    Camera cam;
    Vector3 respawn;
    Rigidbody rb;
    
    public string m_Scene = "Game_Clear";

    public GameObject star;
    bool ishigh = false;
    public float slopeLimit = 45.0f;
    int isback = 1;
    private int respawncount=5;
    float startime = 8f;
    public float speed = 4f;
    public float jumpforce = 30f;
    int max_jumpcount = 2;
    int count;
    // Start is called before the first frame update
   
    void Start()
    {
        cam=GameObject.Find("Main Camera").GetComponent<Camera>();
        respawn= transform.position;//플레이어의 시작위치
        count = max_jumpcount;
        rb=GetComponent<Rigidbody>();
    }
    public int getrespawncount()
    { return respawncount; }
    // Update is called once per frame
    private void FixedUpdate()
    {
       
        
        if (ishigh)
        {
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            Vector3 moveDirection = new Vector3(h, 0.0f, v).normalized;
            rb.AddForce(moveDirection * speed);
            
        }
    }
    void Update()
    {
        //Debug.Log(speed);
        if(Input.GetKeyDown(KeyCode.P))
        {
            isback *= -1;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, cam.transform.localPosition.y, cam.transform.localPosition.z*isback);

            if (isback == -1)
            {
                Quaternion currentRotation = cam.transform.rotation;

                // y 축 회전값만 변경합니다.
                Quaternion newRotation = Quaternion.Euler(0, -180, 0);

                // y 축 회전값만 변경된 새로운 회전값을 적용합니다.
                cam.transform.rotation = newRotation * currentRotation;
                //cam.transform.rotation = Quaternion.Euler(new Vector3(cam.transform.rotation.x, -180, cam.transform.rotation.z));
            }
            //)Quaternion.Euler(cam.transform.rotation.x, -180, cam.transform.rotation.z );
            else
            {
                Quaternion currentRotation = cam.transform.rotation;

                // y 축 회전값만 변경합니다.
                Quaternion newRotation = Quaternion.Euler(0, 0, 0);

                // y 축 회전값만 변경된 새로운 회전값을 적용합니다.
                cam.transform.rotation = newRotation * currentRotation;
            }
               // cam.transform.rotation = Quaternion.Euler(cam.transform.rotation.x, 0, cam.transform.rotation.z);

        }
        if (Input.GetKey(KeyCode.R))
        { // R키로 우회전.
            this.transform.Rotate(0.0f, 90.0f * Time.deltaTime, 0.0f);
        }
        if (Input.GetKey(KeyCode.L))
        { // L키로 좌회전.
            this.transform.Rotate(0.0f, -90.0f * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime*speed);//.AddForce();
        }
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) 
        {
            transform.Translate(Vector3.left * Time.deltaTime*speed);
            //rb.AddForce(Vector3.left*10f);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) 
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
            //rb.AddForce(Vector3.back*10f);
        }
        if(Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            //rb.AddForce(Vector3.right * 10f);
        }

        if(Input.GetKeyDown(KeyCode.Space)) 
        {
           // Debug.Log(count);
            if (count > 0)//jump
            {           //transform.Translate(Vector3.up * Time.deltaTime * speed * 2);
                rb.AddForce(Vector3.up * jumpforce);//.Translate();
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
            count--;
    }

    IEnumerator Star()
    {
        WaitForSeconds wait = new WaitForSeconds(startime);
        GetComponent<Renderer>().material.color= Color.yellow;
        gameObject.tag = "Unbeatable";
        speed *= 6f;
        jumpforce *= 1.5f;
        yield return wait;
        GetComponent<Renderer>().material.color = Color.white;
        speed /= 6f;
        jumpforce /= 1.5f;
        gameObject.tag = "Player";
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ignore Raycast"))
        {
            Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
        }

        if (collision.gameObject.tag == "Bottom"||collision.gameObject.tag=="Addbounce")
        {
            
            count = max_jumpcount;//땅에 닿으면 점프회복
        }
        if(collision.gameObject.tag=="Bigball")
        {
            if (gameObject.tag != "Unbeatable")
            {
                Destroy(collision.gameObject);
                respawncount--;
                if(respawncount == 0)
                {
                    SceneManager.LoadScene("Game_Fail");
                }
                GameObject.Find("SpawncountManager").GetComponent<SpawncountManager>().Life();
                transform.SetPositionAndRotation(respawn, Quaternion.Euler(Vector3.zero));
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Addbounce")
        {
            ishigh = true;
            
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Addbounce")
        {
            ishigh = false;

        }
    }
   IEnumerator Speedup()
    {
        speed += 0.5f;
        yield return new WaitForSeconds(5f);
        speed -= 0.5f;
    }

    IEnumerator Speeddown()
    {
        speed -= 0.5f;
        yield return new WaitForSeconds(5f);
        speed += 0.5f;
    }
   /* IEnumerator LoadAsyncScene()
    {
        Scene currentScene=SceneManager.GetActiveScene();
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(m_Scene, LoadSceneMode.Additive);
        while(!asyncLoad.isDone) 
        {
            yield return null;
        }
        if (m_clear_score != null)
        {
            SceneManager.MoveGameObjectToScene(m_clear_score, SceneManager.GetSceneByName(m_Scene));
        }
        SceneManager.UnloadSceneAsync(currentScene);
    }*/
    void go_score()
    {
        GameObject scoreM = GameObject.Find("ScoreManager") as GameObject;
        State_score.score=scoreM.GetComponent<ScoreManager>().Getscore();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Goal")
        {
            go_score();
            SceneManager.LoadScene(m_Scene);
           // StartCoroutine(LoadAsyncScene());           

        }
        if(other.tag=="Savepoint")
        {
          //  GameObject.Find("Save").SetActive(true);
            
            respawn = other.GetComponent<Transform>().position;
            Destroy(other.gameObject);
           
        }
        if (other.tag == "Deadzone")
        {
            respawncount--;
          /*  if (respawncount == 2)
            {
                StartCoroutine(Star());
            }*/
            if(respawncount==0)
            {
                SceneManager.LoadScene("Game_Fail");
            }
            GameObject.Find("SpawncountManager").GetComponent<SpawncountManager>().Life();
            transform.SetPositionAndRotation(respawn, Quaternion.Euler(Vector3.zero));
        }

        if(other.tag=="Speedup" && tag != "Unbeatable")
        {
            //Debug.Log("item yese
            if (speed <= 8f)
            {
                StartCoroutine(Speedup());
                //speed += 0.5f;
            }
            Destroy(other.gameObject);
        }
        if (other.tag == "Star")
        {
            //Debug.Log("item yese");
            StartCoroutine(Star());
            Destroy(other.gameObject);
        }

        if (other.tag == "SpeedDown"&&tag!="Unbeatable")
        {
            if (speed >= 1f)
            {
               StartCoroutine (Speeddown());
            }
            Destroy(other.gameObject);
        }
        if(other.tag =="Coin")
        {
            GameObject scoreM = GameObject.Find("ScoreManager") as GameObject;
            scoreM.GetComponent<ScoreManager>().Setscore(100);
            Destroy(other.gameObject);
        
        }
        if (other.tag == "Gunitem")
        {
            //Debug.Log("item yese");
            GameObject.Find("Bulletgen").GetComponent<BulletGenerator>().bullet_reload();

            //bulletgen의 bullet_reload불러오기
            Destroy(other.gameObject);
        }

    }

}
