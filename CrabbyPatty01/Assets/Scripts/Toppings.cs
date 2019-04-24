using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toppings : MonoBehaviour
{
    Rigidbody2D rb;

    float fall = 0;
    public float fallSpeed = 1;
  
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * SPEED);
        //FallByUnit();
    }

    public void FallByUnit()
    {
        if (Time.time - fall >= fallSpeed)
        {
            transform.position += new Vector3(0, -1, 0);
            fall = Time.time;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "SpawnCollider")
        {
            Destroy(gameObject);
        }
    }


    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<SpawnToppings>().SpawnNextTopping();
    }
   
    public void OnTriggerEnter2D(Collider2D collision)
    {
        FindObjectOfType<SpawnToppings>().SpawnNextTopping();
    }
    */
}
