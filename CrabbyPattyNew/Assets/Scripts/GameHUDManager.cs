using System.Collections;
using System.Collections.Generic;
//using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDManager : MonoBehaviour
{
    public static GameHUDManager instance;

    public Text txtTimer;

    int time;

    public Text txtPaused;

    public Text txtCurrentScore;
    public Text txtBankedScore;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        int startTime = time;
        for (int i = 0; i >= time; i++)
        {
            txtTimer.text = " " + (startTime + i);
            yield return new WaitForSeconds(0.25f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore();
        BankedScore();
    }

    public void CurrentScore()
    {
        txtCurrentScore.text = " " + PlayerControls.instance.score;
    }
    public void BankedScore()
    {
        txtBankedScore.text = " " + PlayerControls.instance.bankedScore;
    }

    public void PauseDisplay()
    {
        if (GameManager.instance.isPaused == true)
        {
            txtPaused.text = "PAUSE";
        }
        else
        {
            txtPaused.text = null;
        }
    }
}
