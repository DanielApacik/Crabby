using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    const float SPEED = 20;

    Rigidbody2D rb;

    Vector2 moveDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        moveDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7, 3), Mathf.Clamp(transform.position.y, -4.2f, -4.2f));
        rb.velocity = new Vector2(moveDirection.x * SPEED, moveDirection.y * SPEED);
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<GameManager>().PauseGame();
        }
        //Controls();//move by unit
    }

    void Controls()//used if move by unit
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 2), Mathf.Clamp(transform.position.y, -4.2f, -4.2f), Mathf.Clamp(transform.position.z, 0, 0));
            transform.position += new Vector3(1, 0, 0);//move by unit
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -6, 2), Mathf.Clamp(transform.position.y, -4.2f, -4.2f), Mathf.Clamp(transform.position.z, 0, 0));
            transform.position += new Vector3(-1, 0, 0);//move by unit
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            FindObjectOfType<GameManager>().PauseGame();
            //GameManager.instance.PauseGame();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "GoodTopping")
        {
            Destroy(collision.gameObject);
            //add to top and credit in legend
            //++whateverTopping;
            //if (neededTopping){--neededTopping from list of whats remaining} 
        }

        if (collision.gameObject.tag == "BadTopping")
        {
            Destroy(collision.gameObject);
        }
    }
 /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GoodTopping")
        {
            Destroy(collision.transform.parent.gameObject);
            //add to top and credit in legend
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "GoodTopping")
        {
            Destroy(collision.transform.parent.gameObject);
            //add to top and credit in legend
        }
    }
   */
}
