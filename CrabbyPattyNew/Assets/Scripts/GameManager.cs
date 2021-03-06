﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    private float toppingDropTimer;
    private float toppingDropCoolDown;
    private bool canDrop = false;

    public GameObject playerBun;

    public Vector2 spawnPlayerLocation;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        toppingDropTimer = 0.0f;
        toppingDropCoolDown = 1.0f;
        isPaused = false;
        spawnPlayerLocation = new Vector2(-2f, -4.2f);
        SetPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControls.instance.bankedScore >= 200)
        {
            toppingDropCoolDown = 0.50f;
        }
        else if (PlayerControls.instance.bankedScore >= 300)
        {
            toppingDropCoolDown = 0.25f;
        }
        else if (PlayerControls.instance.bankedScore >= 400)
        {
            toppingDropCoolDown = 0.125f;
        }
        else if (PlayerControls.instance.bankedScore >= 600)
        {
            toppingDropCoolDown = 0.025f;
        }
        else if (PlayerControls.instance.bankedScore >= 800)
        {
            toppingDropCoolDown = 0.0025f;
        }


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
            if (PlayerControls.instance.bankedScore >= 1000)
            {
                SpawnToppings.instance.SpawnNextToppingHard();
                toppingDropTimer = toppingDropCoolDown;
            }
            else if (PlayerControls.instance.bankedScore < 1000)
            {
                SpawnToppings.instance.SpawnNextTopping();
                toppingDropTimer = toppingDropCoolDown;
            }
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
            GameHUDManager.instance.PauseDisplay();
        }
        else
        {
            isPaused = false;
            Time.timeScale = 1;
            GameHUDManager.instance.PauseDisplay();
        }
    }

    public void StartScreen()
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits_Scene");
    }

    public void Controls()
    {
        SceneManager.LoadScene("Info_Scene");
    }

    public void DelayEndGame()
    {
        Invoke("EndGame", 1.0f);
    }
    public void EndGame()
    {
        SceneManager.LoadScene("Game_Over");
    }
}
