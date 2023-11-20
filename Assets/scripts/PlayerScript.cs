using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using UnityEngine.XR;

public class PlayerScript : MonoBehaviour
{
    public GameObject gameoverpanel;
    public float Speed;

    private Vector3 dir;
    
    public GameObject ps;

    public bool isDead;
    bool mousinput = false;

    public GameObject resetBtn;
   // public GameObject menubtn;
    private int score = 0;

    public Text scoreText;

    public Animator gameOverAnim;

    public Text lastScoreText;

    public Text bestText;

    public Text coinText;
    private int Coinscore=0;
    public Animator Runanim;
    bool rotate = true;
   /// <summary>
   /// public Text coinestext;
   /// </summary>
  //  public GameObject Player;

    RaycastHit ray;
    // Start is called before the first frame update
    void Start()
    {
        isDead = true;
        gameoverpanel.SetActive(false);
        //Time.timeScale = 0f;
        //isDead = false;
        

       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isDead == true)
        {
            isDead = false;
            Runanim.SetBool("run", true);
            Time.timeScale = 1;
            dir = Vector3.forward;
            mousinput = true;
            // score++;
            //scoreText.text = score.ToString();

            // if (dir == Vector3.forward)
            // {
            //    rotate = false;
            //    transform.Rotate(0, 90, 0);
            //}
            //else
            //{
            //    dir = Vector3.forward;
            //}*/
        
        }
       else if (Input.GetMouseButtonDown(0)&&isDead == false)
        {
            if (rotate == false)
            {
               // Debug.Log("Rotate 1");


                rotate = true;
                transform.Rotate(0, 90, 0);
            }
            else if (rotate == true)
            {
               // Debug.Log("Rotate 2");
                rotate = false;
                transform.Rotate(0, -90, 0);

            }
        }     
       /* if (Input.GetMouseButtonDown(0))
        {
           
        }
        */

       // float amoutToMove = Speed* Time.deltaTime;

        transform.Translate(dir*Speed *Time.deltaTime);
       //float amoutToMove = Speed * Time.deltaTime;
        //transform.Translate(pos * amoutToMove);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 3;
            Coinscore = Coinscore + 1;
            coinText.text = Coinscore.ToString();
           scoreText.text = score.ToString();
            

        }
        if(other.tag == "5+")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 5;
            Coinscore = Coinscore + 1;
          coinText.text = Coinscore.ToString();
            scoreText.text = score.ToString();
        }
        if(other.tag == "10+")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 10;
            Coinscore = Coinscore + 1;
            coinText.text = Coinscore.ToString();
            scoreText.text = score.ToString();
        }
        if(other.tag == "20+")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score+= 20;
            Coinscore = Coinscore + 1;
            coinText.text = Coinscore.ToString();
           scoreText.text = score.ToString();
        }
        //Ray downRay = new Ray(transform.position, Vector3.down)
    }
    private void GameOver()
    {
       // gameOverAnim.SetTrigger("GameOver");
       
        lastScoreText.text = score.ToString();
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);
        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
        }
        bestText.text = PlayerPrefs.GetInt("BestScore",0).ToString();
       gameoverpanel.SetActive(true);
        StartCoroutine(timedelay());
        
    }

    private void FixedUpdate()
    {
      //  transform.position = Player.transform.position;

        if (!Physics.Raycast(transform.position, Vector3.down, out ray, 5f))
        {
            float sub = -40f;
            Vector3 playerpos = transform.position;
            playerpos.y = transform.position.y + sub * Time.deltaTime ;
            transform.position = playerpos;
            isDead = true;
            GameOver();
          //  Vector3 transformPosition = playerpos.transform.position + Offset;
            resetBtn.SetActive(true);

            if (transform.childCount > 0)
            {
                transform.GetChild(0).transform.parent = null;
            }
        
        }
       
    }
    IEnumerator timedelay()
    {
        yield return new WaitForSeconds(1f);
       Time.timeScale = 0;
    }
   //// public void menubtn()
   // {
   //     SceneManager.LoadSceneAsync(0);
   //     menubtn.SetActive(true);
   // }
}
