using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    private float toppingDropTimer = 0;
    private float toppingDropCoolDown = 2.0f;
    private bool canDrop = false;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (toppingDropTimer > 0)
        {
            toppingDropTimer -= Time.deltaTime;
            canDrop = false;
        }
        else
        {
            canDrop = true;
            toppingDropTimer = 0f;
        }

        if (canDrop == true)
        {
            //SpawnToppings.instance.SpawnNextTopping();
            FindObjectOfType<SpawnToppings>().SpawnNextTopping();
            toppingDropTimer = toppingDropCoolDown;
        }
        else
        {
            canDrop = false;
        }
    }


    public void PauseGame()
    {
        if (!isPaused)
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }
}
