using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    const float SPEED = 20;

    Rigidbody2D rb;

    Vector2 moveDirection;

    public int score = 0;
    public int lives = 3;
    public GameObject scorePOPUPEmitter;
    public GameObject ramsey;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    void Controls()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7, 3), Mathf.Clamp(transform.position.y, -4.2f, -4.2f));
        rb.velocity = new Vector2(moveDirection.x * SPEED, moveDirection.y * SPEED);
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.PauseGame();
            //FindObjectOfType<GameManager>().PauseGame();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "top_bun")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[0], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "tomato")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[1], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "cheese")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[2], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 20;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "onion")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[3], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "patty")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[4], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 50;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "ketchup")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[5], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "mustard")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[6], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "pickles")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[7], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "lettuce")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[8], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "bacon")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[9], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            Destroy(pointsPOPUP, 0.125f);
            score += 25;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BadTopping")
        {
            GameObject ramseyPOPUP = Instantiate(ramsey, new Vector2(2, -4), Quaternion.identity);
            //ramseyPOPUP.transform.position = new Vector2();
            Destroy(ramseyPOPUP, 1.25f);
            lives -= 1;
            Destroy(collision.gameObject);
        }
    }
}
