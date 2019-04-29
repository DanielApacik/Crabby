using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    private float toppingDropTimer = 0;
    private float toppingDropCoolDown = 0.25f;
    private bool canDrop = false;

    public GameObject playerBun;

    public Vector2 spawnPlayerLocation;

    private void Awake()
    {
        instance = this;
        //SetPlayer();
    }

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        spawnPlayerLocation = new Vector2(-2f, -4.2f);
        SetPlayer();
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
            SpawnToppings.instance.SpawnNextTopping();
            //FindObjectOfType<SpawnToppings>().SpawnNextTopping();
            toppingDropTimer = toppingDropCoolDown;
        }
        else
        {
            canDrop = false;
        }
    }

    public void SetPlayer()
    {
        playerBun = Instantiate(playerBun, spawnPlayerLocation, Quaternion.identity);
        //PlayerControls.instance.Controls
        //enabled = true;
        //PlayerControls.instance.hasBun = false;
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
