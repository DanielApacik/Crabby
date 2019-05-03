using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerHighlight : MonoBehaviour
{
    public static burgerHighlight instance;

    public Sprite burgerCol;
    public Sprite burgerGry;

    public List<GameObject> burgerDisplay;
    public GameObject burger0;
    public GameObject burger1;
    public GameObject burger2;
    public GameObject burger3;
    public GameObject burger4;
    public GameObject burger5;
    public GameObject burger6;
    public GameObject burger7;
    public GameObject burger8;
    public GameObject burger9;


    private void Awake()
    {
        instance = this;

        burgerDisplay = new List<GameObject>
        {
            burger0, burger1, burger2, burger3, burger4, burger5, burger6, burger7, burger8, burger9
        };
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PlayerControls.instance.numBurgers; ++i)
        {
            burgerDisplay[i].GetComponent<SpriteRenderer>().sprite = burgerCol;
            if (PlayerControls.instance.numBurgers >= 10)
            {
                Invoke("ResetBurgers", 2.0f);
            }
        }
    }
    public void ResetBurgers()
    {
        for (int i = 0; i < burgerDisplay.Count; ++i)
        {
            burgerDisplay[i].GetComponent<SpriteRenderer>().sprite = burgerGry;
        }
    }
}
