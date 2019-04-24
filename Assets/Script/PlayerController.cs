using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour {
    public Rigidbody2D rb2d;
    public BoxCollider2D bc2d;
    public BoxCollider2D floorbc2d;
    
    public GameObject player;
    public GameObject floor;
    public float speed;
    public float stop = 0;
    public float jumpH;
    public bool isJumping = false;

    public int score = 0;
    public int lives = 3;
    public Text scoretext;
    public Text liveText;
    public Text food1;
    public Text food2;
    public Text food3;
    public Image food1image;
    public Image food2image;
    public Image food3image;


    public turret turret1;
    public turret turret2;
    public turret turret3;
    
   
	// Use this for initialization
	void Start () {
        
        
        
        // this allows acsess to Rb2d 
        rb2d.GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void Update () {

        scoretext.text = "Score: " + score;
        liveText.text = "lives left: " + lives;

        if (lives == 0)
        {
            GameOver();
        }
        //simple movement and jump
        if (Input.GetKey("a"))
        {
            rb2d.AddForce(Vector3.left*speed);
        } else
        {
            rb2d.AddForce(Vector3.left * stop);
        }
        if (Input.GetKey("d"))
        {
            rb2d.AddForce(Vector3.right*speed);
        }
        else
        {
            rb2d.AddForce(Vector3.right * stop);
        }
        if (isJumping == false && Input.GetKeyDown("w"))
        {
            rb2d.AddForce(Vector3.up * jumpH);
            isJumping = true;
                       
        }


        /* if(isJumping== false)
         {
             Debug.Log(isJumping);
         }
         if (isJumping == true)
         {
             Debug.Log(isJumping);
         }
         */

        if (turret3.foodList.Count == 0)
        {
            GameWin();
        }


    }

    // colision detection and then setting bool and if
    //player hits anything tagged "Food" it will delete tagged object.
    void OnCollisionEnter2D(Collision2D col)
        {
            if(col.gameObject.name == "floor")
            {
                isJumping = false;
               
            }
            if(col.gameObject.tag == "Food")
            {
            score += 100;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "Food1")
            {
            score += 100;
            Destroy(col.gameObject);
            turret1.removefood1();
            turret2.removefood1();
            turret3.removefood1();
            food1.gameObject.SetActive(false);
            food1image.gameObject.SetActive(false);

        }

        if (col.gameObject.tag == "Food2")
        {
            score += 100;
            Destroy(col.gameObject);
            turret1.removefood2();
            turret2.removefood2();
            turret3.removefood2();
            food2.gameObject.SetActive(false);
            food2image.gameObject.SetActive(false);

        }
        if (col.gameObject.tag == "Food3")
        {
            score += 100;
            Destroy(col.gameObject);
            turret1.removefood3();
            turret2.removefood3();
            turret3.removefood3();
            food3.gameObject.SetActive(false);
            food3image.gameObject.SetActive(false);
        }

        if (col.gameObject.tag == "bad")
            {
                lives -= 1;
                Destroy(col.gameObject);
            }
        }

    public void GameOver()
    {
        SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
    }

    public void GameWin()
    {
        //replace with win screen
        SceneManager.LoadScene("gameOver", LoadSceneMode.Single);
    }


}
