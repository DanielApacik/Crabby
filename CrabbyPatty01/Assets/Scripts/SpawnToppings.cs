using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToppings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTopping();
    }

    // Update is called once per frame
    void Update()
    {
        //if 
    }


    public void SpawnNextTopping()
    {
        GameObject nextTopping = (GameObject)Instantiate(Resources.Load(GetRandomTopping(), typeof(GameObject)), new Vector2(0.0f, 5.0f), Quaternion.identity);
    }


    string GetRandomTopping()
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
