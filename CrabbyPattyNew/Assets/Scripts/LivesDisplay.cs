using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    public static LivesDisplay instance;

    public Sprite lifeGraphic;
    public Sprite emptyGraphic;

    public List<GameObject> livesEmitter;
    public GameObject lifeDisplay0;
    public GameObject lifeDisplay1;
    public GameObject lifeDisplay2;
    public GameObject lifeDisplay3;
    public GameObject lifeDisplay4;
    public GameObject lifeDisplay5;
    public GameObject lifeDisplay6;
    public GameObject lifeDisplay7;
    public GameObject lifeDisplay8;
    public GameObject lifeDisplay9;


    private void Awake()
    {
        instance = this;

        livesEmitter = new List<GameObject>
        {
            lifeDisplay0, lifeDisplay1, lifeDisplay2, lifeDisplay3, lifeDisplay4, lifeDisplay5, lifeDisplay6, lifeDisplay7, lifeDisplay8, lifeDisplay9
        };
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < PlayerControls.instance.lives; ++i)
        {
            livesEmitter[i].GetComponent<SpriteRenderer>().sprite = lifeGraphic;
        }

    }
    public void ResetLives()
    {
        for (int i = 0; i < PlayerControls.instance.lives; ++i)
        {
            livesEmitter[i].GetComponent<SpriteRenderer>().sprite = emptyGraphic;
        }
    }
}
