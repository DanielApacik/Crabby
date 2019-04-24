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
    public GameObject patty;



    // Start is called before the first frame update
    void Start()
    {
        goodToppingsList = new List<GameObject>
        {
            tomato, cheese, top_bun, onion, patty
        };
        //SpawnNextTopping();
    }

    // Update is called once per frame
    void Update()
    {
         
    }


    public void SpawnNextTopping()
    {
        //GameObject nextTopping = (GameObject)Instantiate(Resources.Load(GetRandomTopping(), typeof(GameObject)), new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);//call through Resourses folder using switch
     
        GameObject nextTopping = Instantiate(goodToppingsList[Random.Range(0, goodToppingsList.Capacity)], new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);
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
