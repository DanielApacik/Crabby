using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToppings : MonoBehaviour
{
    public static SpawnToppings instance;

    public List<GameObject> goodToppingsList;
    public GameObject tomato;
    public GameObject cheese;
    public GameObject top_bun;
    public GameObject onion;
    public GameObject patty;/*
    public GameObject ketchup;
    public GameObject mustard;
    public GameObject pickles;
    public GameObject lettuse;
    public GameObject bacon;

    
    public List<GameObject> badToppingList;
    public GameObject socks;
    public GameObject fish_bones;
    public GameObject needle;
    public GameObject toilet_paper;
    public GameObject boot;
    public GameObject sponge;
    public GameObject mouse;
    public GameObject rat_poison;
    public GameObject band_aid;
*/
    public List<GameObject> getToppingList;

    //public GameObject targetTopping01;
    //public GameObject targetTopping02;
    //public GameObject targetTopping03;

    public GameObject targetEmitter01;
    public GameObject targetEmitter02;
    public GameObject targetEmitter03;

    public float fallSpeed = 0.5f;


    private void Awake()
    {
        instance = this;

        goodToppingsList = new List<GameObject>
        {
            tomato, cheese, top_bun, onion, patty //, ketchup, mustard, pickles, lettuse, bacon
        };


        getToppingList = new List<GameObject>();
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);

        

    }


    // Start is called before the first frame update
    void Start()
    {

/*
        goodToppingsList = new List<GameObject>
        {
            tomato, cheese, top_bun, onion, patty //, ketchup, mustard, pickles, lettuse, bacon
        };
        
         
        badToppingList = new List<GameObject>
        {
            socks, fish_bones, needle, toilet_paper, boot, sponge, mouse, rat_poison, band_aid
        };


        getToppingList = new List<GameObject>
        {
            targetTopping01, targetTopping02, targetTopping03
        };







        getToppingList = new List<GameObject>();
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);
        getToppingList.Add(goodToppingsList[Random.Range(0, goodToppingsList.Count)]);*/
        //targetTopping01 = getToppingList[0];
        //targetTopping02 = getToppingList[1];
        //targetTopping03 = getToppingList[2];



        //targetTopping01 = Instantiate(goodToppingsList[0], new Vector2(5, 3), Quaternion.identity);
        //targetTopping02 = Instantiate(goodToppingsList[1], new Vector2(5, 2), Quaternion.identity);
        //targetTopping03 = Instantiate(goodToppingsList[2], new Vector2(5, 1), Quaternion.identity);




        //SpawnNextTopping();
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    public void SetTargetToppings()
    {
        GameObject targetTopping01 = getToppingList[0];
        GameObject targetTopping02 = getToppingList[1];
        GameObject targetTopping03 = getToppingList[2];

        targetTopping01 = Instantiate(getToppingList[0], targetEmitter01.transform.position, Quaternion.identity);
        Rigidbody2D rbTopping01 = targetTopping01.GetComponent<Rigidbody2D>();
        rbTopping01.gravityScale = 0;

        targetTopping02 = Instantiate(getToppingList[1], targetEmitter02.transform.position, Quaternion.identity);
        Rigidbody2D rbTopping02 = targetTopping02.GetComponent<Rigidbody2D>();
        rbTopping02.gravityScale = 0;

        targetTopping03 = Instantiate(getToppingList[2], targetEmitter03.transform.position, Quaternion.identity);
        Rigidbody2D rbTopping03 = targetTopping03.GetComponent<Rigidbody2D>();
        rbTopping03.gravityScale = 0;
    }


    public void SpawnNextTopping()
    {
        //GameObject nextTopping = (GameObject)Instantiate(Resources.Load(GetRandomTopping(), typeof(GameObject)), new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);//call through Resourses folder using switch
     
        GameObject nextTopping = Instantiate(goodToppingsList[Random.Range(0, goodToppingsList.Count)], new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);
        Rigidbody2D rbToppingTest = nextTopping.GetComponent<Rigidbody2D>();
        rbToppingTest.gravityScale = fallSpeed;
    }


    string GetRandomTopping()//used to call by string if navigating through file folders
    {
        int randomTopping = Random.Range(1, 6);

        string randomToppingName = "Prefabs/tomato";

        switch (randomTopping)
        {
        case 1:
            randomToppingName = "Prefabs/tomato";
            break;
        case 2:
            randomToppingName = "Prefabs/onion";
            break;
        case 3:
            randomToppingName = "Prefabs/cheese";
            break;
        case 4:
            randomToppingName = "Prefabs/patty";
            break;
        case 5:
            randomToppingName = "Prefabs/burger_top";
            break;
        }
        return randomToppingName;
    }

}
