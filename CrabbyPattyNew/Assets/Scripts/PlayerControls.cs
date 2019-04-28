using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls instance;
    
    const float SPEED = 20;

    Rigidbody2D rb;

    Vector2 moveDirection;

    public int score = 0;
    public int bankedScore = 0;
    public int lives = 3;
    public GameObject scorePOPUPEmitter;
    public GameObject ramsey;
    public GameObject SIDEToppingsEmitter;



    public int toppingStack = 0;
    public bool hasBun = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveDirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //BunCheck();
        Controls();
    }

    public void Controls()
    {
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7, 3), Mathf.Clamp(transform.position.y, -4.2f, -4.2f));
        rb.velocity = new Vector2(moveDirection.x * SPEED, moveDirection.y * SPEED);
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.P))
        {
            GameManager.instance.PauseGame();
        }
    }
    public void BunCheck()
    {
        if (hasBun == true)
        {
            //enabled = false;
            GameManager.instance.spawnPlayerLocation = gameObject.transform.position;
            Destroy(gameObject, 0.125f);
            GameManager.instance.SetPlayer();
        }
        hasBun = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "top_bun")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[0], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 50;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);                
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack ==1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack ==2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            else if (toppingStack >= 6)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.39f);
                sidewaysDisplay.transform.parent = gameObject.transform;
                hasBun = true;
                Destroy(sidewaysDisplay, 0.125f);
                bankedScore += score;
                score = 0;
            }
            toppingStack = 0;
            //hasBun = true;
        }
        if (collision.gameObject.tag == "tomato")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[1], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;                 
        }
        if (collision.gameObject.tag == "cheese")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[2], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 20;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "onion")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[3], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "patty")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[4], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 50;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "ketchup")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[5], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "mustard")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[6], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "pickles")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[7], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "lettuce")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[8], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }
        if (collision.gameObject.tag == "bacon")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[9], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 25;
            Destroy(collision.gameObject);
            if (toppingStack == 0)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 1)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 2)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 3)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 4)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            else if (toppingStack == 5)
            {
                GameObject sidewaysDisplay = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                sidewaysDisplay.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                sidewaysDisplay.transform.parent = gameObject.transform;
            }
            ++toppingStack;
        }

        if (collision.gameObject.tag == "BadTopping")
        {
            if (lives == 0)
            {
                GameObject ramseyPOPUP = Instantiate(ramsey, new Vector2(0, -1), Quaternion.identity);
                ramseyPOPUP.transform.localScale = new Vector2(transform.localScale.x * 5.0f, transform.localScale.y * 5.0f);
                Destroy(collision.gameObject);
                //you lose navigate to lose scene
            }
            else
            {
                GameObject ramseyPOPUP = Instantiate(ramsey, new Vector2(2, -4), Quaternion.identity);
                Destroy(ramseyPOPUP, 1.25f);
                lives -= 1;
                Destroy(collision.gameObject);
            }
        }
    }
}
