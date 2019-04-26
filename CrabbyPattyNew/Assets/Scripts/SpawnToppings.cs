using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnToppings : MonoBehaviour
{
    public static SpawnToppings instance;

    public List<GameObject> goodToppingsList;
    public GameObject top_bun;
    public GameObject tomato;
    public GameObject cheese;
    public GameObject onion;
    public GameObject patty;
    public GameObject ketchup;
    public GameObject mustard;
    public GameObject pickles;
    public GameObject lettuce;
    public GameObject bacon;

    
    public List<GameObject> badToppingsList;
    public GameObject socks;
    public GameObject fish_bones;
    public GameObject needle;
    public GameObject toilet_paper;
    public GameObject boot;
    public GameObject mouse;
    public GameObject rat_poison;
    public GameObject band_aid;


    public List<GameObject> displayEmitterList;
    public GameObject targetEmitter00;
    public GameObject targetEmitter01;
    public GameObject targetEmitter02;
    public GameObject targetEmitter03;
    public GameObject targetEmitter04;
    public GameObject targetEmitter05;
    public GameObject targetEmitter06;
    public GameObject targetEmitter07;
    public GameObject targetEmitter08;
    public GameObject targetEmitter09;


    public List<GameObject> goodToppingsSCOREList;
    public GameObject top_bunSCORE;
    public GameObject tomatoSCORE;
    public GameObject cheeseSCORE;
    public GameObject onionSCORE;
    public GameObject pattySCORE;
    public GameObject ketchupSCORE;
    public GameObject mustardSCORE;
    public GameObject picklesSCORE;
    public GameObject lettuceSCORE;
    public GameObject baconSCORE;


    public List<GameObject> displayPointsEmitterList;
    public GameObject targetPointsEmitter00;
    public GameObject targetPointsEmitter01;
    public GameObject targetPointsEmitter02;
    public GameObject targetPointsEmitter03;
    public GameObject targetPointsEmitter04;
    public GameObject targetPointsEmitter05;
    public GameObject targetPointsEmitter06;
    public GameObject targetPointsEmitter07;
    public GameObject targetPointsEmitter08;
    public GameObject targetPointsEmitter09;



    public float fallSpeed = 0.5f;

    int randomTopping;

    private void Awake()
    {
        instance = this;

        goodToppingsList = new List<GameObject>
        {
            top_bun, tomato, cheese, onion, patty, ketchup, mustard, pickles, lettuce, bacon
        };

        badToppingsList = new List<GameObject>
        {
            socks, fish_bones, needle, toilet_paper, boot, mouse, rat_poison, band_aid
        };

        goodToppingsSCOREList = new List<GameObject>
        {
            top_bunSCORE, tomatoSCORE, cheeseSCORE, onionSCORE, pattySCORE, ketchupSCORE, mustardSCORE, picklesSCORE, lettuceSCORE, baconSCORE
        };
     

        displayEmitterList = new List<GameObject>
        {
            targetEmitter00,
            targetEmitter01,
            targetEmitter02,
            targetEmitter03,
            targetEmitter04,
            targetEmitter05,
            targetEmitter06,
            targetEmitter07,
            targetEmitter08,
            targetEmitter09
        };
        for (int i = 0; i < goodToppingsList.Count; ++i)
        {
            GameObject displayTopping = Instantiate(goodToppingsList[i], displayEmitterList[i].transform.position, Quaternion.identity);
            displayTopping.transform.localScale = new Vector2(transform.localScale.x * 0.04f, transform.localScale.y * 0.4f);
            Rigidbody2D rbTopping = displayTopping.GetComponent<Rigidbody2D>();
            rbTopping.gravityScale = 0;

        }


        displayPointsEmitterList = new List<GameObject>
        {
            targetPointsEmitter00,
            targetPointsEmitter01,
            targetPointsEmitter02,
            targetPointsEmitter03,
            targetPointsEmitter04,
            targetPointsEmitter05,
            targetPointsEmitter06,
            targetPointsEmitter07,
            targetPointsEmitter08,
            targetPointsEmitter09
        };
        for (int i = 0; i < goodToppingsSCOREList.Count; ++i)
        {
            GameObject displayPoints = Instantiate(goodToppingsSCOREList[i], displayPointsEmitterList[i].transform.position, Quaternion.identity);
            displayPoints.transform.localScale = new Vector2(transform.localScale.x * 0.04f, transform.localScale.y * 0.4f);
        }
    }

    public void SpawnNextTopping()
    {
        randomTopping = Random.Range(0, 4);

        if (randomTopping == 0)
        {
            SpawnBADTopping();
        }

        if (randomTopping == 1 || randomTopping == 2 || randomTopping == 3)
        {
            SpawnGOODTopping();
        }
    }

    public void SpawnGOODTopping()
    {
        GameObject nextTopping = Instantiate(goodToppingsList[Random.Range(0, goodToppingsList.Count)], new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);
        Rigidbody2D rbToppingGood = nextTopping.GetComponent<Rigidbody2D>();
        rbToppingGood.gravityScale = fallSpeed;
    }

    public void SpawnBADTopping()
    {
        GameObject nextTopping = Instantiate(badToppingsList[Random.Range(0, badToppingsList.Count)], new Vector2(Random.Range(-7, 4), 6), Quaternion.identity);
        Rigidbody2D rbToppingBad = nextTopping.GetComponent<Rigidbody2D>();
        rbToppingBad.gravityScale = fallSpeed;
    }
}
