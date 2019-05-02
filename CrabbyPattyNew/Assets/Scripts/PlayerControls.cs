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

    public int numBurgers = 0;
    //public bool burgerDONE = false;

    public GameObject scorePOPUPEmitter;
    public GameObject ramsey;
    public GameObject SIDEToppingsEmitter;
    public GameObject burgerTEXTEmitter;

    //public List<GameObject> sidewaysDisplay;
    public GameObject sidewaysDisplay0;
    public GameObject sidewaysDisplay1;
    public GameObject sidewaysDisplay2;
    public GameObject sidewaysDisplay3;
    public GameObject sidewaysDisplay4;
    public GameObject sidewaysDisplay5;
    public GameObject sidewaysDisplay6;
    public GameObject sidewaysDisplay7;
    public GameObject sidewaysDisplay8;
    public GameObject sidewaysDisplay9;

    public GameObject sidewaysBlankDisplay;

    public int toppingStack = 0;

    public bool hasBun = false;//0
    public bool hasTomato = false;//1
    public bool hasCheese = false;//2
    public bool hasOnion = false;//3
    public bool hasPatty = false;//4
    public bool hasKetchup = false;//5
    public bool hasMustard = false;//6
    public bool hasPickles = false;//7
    public bool hasLettuce = false;//8
    public bool hasBacon = false;//9

    private void Awake()
    {
        instance = this;
    }

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
        BunCheck();
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
            //GameManager.instance.spawnPlayerLocation = gameObject.transform.position;
            Destroy(sidewaysDisplay0, 1.0f);
            
            
            if (hasTomato == true)
            {
                //sidewaysDisplay1 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay1);
                sidewaysDisplay1.transform.parent = null;
                Destroy(sidewaysDisplay1);
                hasTomato = false;
            }
            if (hasCheese == true)
            {
                //sidewaysDisplay2 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay2);
                sidewaysDisplay2.transform.parent = null;
                Destroy(sidewaysDisplay2);
                hasCheese = false;
            }
            if (hasOnion == true)
            {
                //sidewaysDisplay3 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay3);
                sidewaysDisplay3.transform.parent = null;
                Destroy(sidewaysDisplay3);
                hasOnion = false;
            }
            if (hasPatty == true)
            {
                //sidewaysDisplay4 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay4);
                sidewaysDisplay4.transform.parent = null;
                Destroy(sidewaysDisplay4);
                hasPatty = false;
            }
            if (hasKetchup == true)
            {
                //sidewaysDisplay5 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay5);
                sidewaysDisplay5.transform.parent = null;
                Destroy(sidewaysDisplay5);
                hasKetchup = false;
            }
            if (hasMustard == true)
            {
                //sidewaysDisplay6 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay6);
                sidewaysDisplay6.transform.parent = null;
                Destroy(sidewaysDisplay6);
                hasMustard = false;
            }
            if (hasPickles == true)
            {
                //sidewaysDisplay7 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay7);
                sidewaysDisplay7.transform.parent = null;
                Destroy(sidewaysDisplay7);
                hasPickles = false;
            }
            if (hasLettuce == true)
            {
                //sidewaysDisplay8 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay8);
                sidewaysDisplay8.transform.parent = null;
                Destroy(sidewaysDisplay8);
                hasLettuce = false;
            }
            if (hasBacon == true)
            {
                //sidewaysDisplay9 = sidewaysBlankDisplay;
                //DestroyImmediate(sidewaysDisplay9);
                sidewaysDisplay9.transform.parent = null;
                Destroy(sidewaysDisplay9);
                hasBacon = false;
            }
            
            hasBun = false;
            //GameManager.instance.SetPlayer();
        }
        else
        {
            hasBun = false;
        }
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

            GameObject burgerTextObj = Instantiate(SpawnToppings.instance.burgerTextObject, burgerTEXTEmitter.transform.position, Quaternion.identity);
            burgerTextObj.transform.parent = gameObject.transform;
            Destroy(burgerTextObj, 1.0f);
            sidewaysDisplay0 = Instantiate(SpawnToppings.instance.sideToppingsList[0], SIDEToppingsEmitter.transform.position, Quaternion.identity);
            if (toppingStack == 1)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
            }
            else if (toppingStack == 2)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
            }
            else if (toppingStack == 3)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
            }
            else if (toppingStack == 4)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
            }
            else if (toppingStack == 5)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
            }
            else if (toppingStack >= 6)
            {
                sidewaysDisplay0.transform.position = new Vector2(transform.position.x, transform.position.y + 0.39f);
            }
            sidewaysDisplay0.transform.parent = gameObject.transform;
            hasBun = true;
            //Destroy(sidewaysDisplay0, 1f);
            ++numBurgers;
            //burgerDONE = true;
            bankedScore += score;
            score = 0;
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

            if (hasTomato != true)
            {
                sidewaysDisplay1 = Instantiate(SpawnToppings.instance.sideToppingsList[1], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack ==0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay1.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay1);
                }
                sidewaysDisplay1.transform.parent = gameObject.transform;
                hasTomato = true;
            }                        
        }

        if (collision.gameObject.tag == "cheese")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[2], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 20;
            Destroy(collision.gameObject);

            if (hasCheese != true)
            {
                sidewaysDisplay2 = Instantiate(SpawnToppings.instance.sideToppingsList[2], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay2.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay2);
                }
                sidewaysDisplay2.transform.parent = gameObject.transform;
                hasCheese = true;
            }
        }

        if (collision.gameObject.tag == "onion")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[3], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);

            if (hasOnion != true)
            {
                sidewaysDisplay3 = Instantiate(SpawnToppings.instance.sideToppingsList[3], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay3.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay3);
                }
                sidewaysDisplay3.transform.parent = gameObject.transform;
                hasOnion = true;
            }
        }

        if (collision.gameObject.tag == "patty")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[4], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 50;
            Destroy(collision.gameObject);

            if (hasPatty != true)
            {
                sidewaysDisplay4 = Instantiate(SpawnToppings.instance.sideToppingsList[4], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay4.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay4);
                }
                sidewaysDisplay4.transform.parent = gameObject.transform;
                hasPatty = true;
            }
        }

        if (collision.gameObject.tag == "ketchup")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[5], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);

            if (hasKetchup != true)
            {
                sidewaysDisplay5 = Instantiate(SpawnToppings.instance.sideToppingsList[5], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay5.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay5);
                }
                sidewaysDisplay5.transform.parent = gameObject.transform;
                hasKetchup = true;
            }
        }

        if (collision.gameObject.tag == "mustard")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[6], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 10;
            Destroy(collision.gameObject);

            if (hasMustard != true)
            {
                sidewaysDisplay6 = Instantiate(SpawnToppings.instance.sideToppingsList[6], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay6.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay6);
                }
                sidewaysDisplay6.transform.parent = gameObject.transform;
                hasMustard = true;
            }
        }

        if (collision.gameObject.tag == "pickles")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[7], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);

            if (hasPickles != true)
            {
                sidewaysDisplay7 = Instantiate(SpawnToppings.instance.sideToppingsList[7], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                { 
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay7.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay7);
                }
                sidewaysDisplay7.transform.parent = gameObject.transform;
                hasPickles = true;
            }
        }

        if (collision.gameObject.tag == "lettuce")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[8], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 15;
            Destroy(collision.gameObject);

            if (hasLettuce != true)
            {
                sidewaysDisplay8 = Instantiate(SpawnToppings.instance.sideToppingsList[8], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay8.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay8);
                }
                sidewaysDisplay8.transform.parent = gameObject.transform;
                hasLettuce = true;
            }
        }

        if (collision.gameObject.tag == "bacon")
        {
            GameObject pointsPOPUP = Instantiate(SpawnToppings.instance.goodToppingsSCOREList[9], scorePOPUPEmitter.transform.position, Quaternion.identity);
            pointsPOPUP.transform.localScale = new Vector2(transform.localScale.x * 0.5f, transform.localScale.y * 0.5f);
            pointsPOPUP.transform.parent = gameObject.transform;
            Destroy(pointsPOPUP, 0.125f);
            score += 25;
            Destroy(collision.gameObject);

            if(hasBacon != true)
            {
                sidewaysDisplay9 = Instantiate(SpawnToppings.instance.sideToppingsList[9], SIDEToppingsEmitter.transform.position, Quaternion.identity);
                if (toppingStack == 0)
                {
                    ++toppingStack;
                }
                if (toppingStack == 1)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.065f);
                    ++toppingStack;
                }
                else if (toppingStack == 2)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.130f);
                    ++toppingStack;
                }
                else if (toppingStack == 3)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.195f);
                    ++toppingStack;
                }
                else if (toppingStack == 4)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.26f);
                    ++toppingStack;
                }
                else if (toppingStack == 5)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    ++toppingStack;
                }
                else if (toppingStack >= 6)
                {
                    sidewaysDisplay9.transform.position = new Vector2(transform.position.x, transform.position.y + 0.325f);
                    //Destroy(sidewaysDisplay9);
                }
                sidewaysDisplay9.transform.parent = gameObject.transform;
                hasBacon = true;
            }
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
