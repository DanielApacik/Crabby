using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burgerHighlight : MonoBehaviour
{
    SpriteRenderer SRburg; 

    public Sprite burgerCol;
    public Sprite burgerGry;

    // Start is called before the first frame update
    void Start()
    {
        SRburg = GetComponent<SpriteRenderer>();
        SRburg.sprite = burgerGry;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControls.instance.numBurgers >= 1)
        {
            SRburg.sprite = burgerCol;
        }  
    }
}
