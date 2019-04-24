using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turret : MonoBehaviour {
    //all our food items
    public GameObject food1;
    public GameObject food2;
    public GameObject food3;

    // all our bad items 
    public GameObject bad1;
    public GameObject bad2;
    public GameObject bad3;


    

    // the randoms we need for selection
    int rnd;
    int rndFood;
    int rndBad;
    float rndTime;

    // lists for both food and bad items
    public List<GameObject> foodList = new List<GameObject>();
    public List<GameObject> badList = new List<GameObject>();

   

    /* this is our "Timer" and by that I mean this is the number
    we are counting down from i.e if it was 20 it would start at 20
    then 19, 18,17 */
    public float timeTillDispence;
    public float minTime;
    public float maxTime = 5.0f;

    /*Difficulty timer  */
    private float difTime = 30.0f;
    public float decraseMaxTime = 0.1f;

	// Use this for initialization
	void Start () {
        //adding the food into our food list
        foodList.Add(food1);
        foodList.Add(food2);
        foodList.Add(food3);
        //adding the bad items into our badlist
        badList.Add(bad1);
        badList.Add(bad2);
        badList.Add(bad3);

        /* 
         RandomNumberofNumbers = how many random iteams 4

    
         
         
         
         */
        

    }
	
	// Update is called once per frame
	void Update () {
        // this gets us our random food choice/
        rndFood = Random.Range(0, foodList.Count);
        rndBad = Random.Range(0, badList.Count);
        rnd = Random.Range(0, 4);
        rndTime = Random.Range(minTime, maxTime) + 1.0f;
        // below is our timers counting down. 
        timeTillDispence -= Time.deltaTime;
        difTime -= Time.deltaTime;
        /*if our timer reaches 0 we run our dispenceFood function 
        as well as reset the timer*/ 
        if (timeTillDispence == 0 || timeTillDispence < 0)
        {
            

            if (rnd == 0)
            {
                dispenceFood();
            }

            if (rnd == 1 || rnd == 2 || rnd == 3)
            {
                dispenceBad();
            }

            
            timeTillDispence = timeTillDispence + rndTime;
        }

        if (difTime == 0 || difTime < 0)
        {
            if(maxTime == 1.1 || maxTime > 1.1)
            {
                maxTime -= decraseMaxTime;
                Debug.Log(maxTime);
            }
            difTime += 30.0f;
            
        }
	}

    public void dispenceFood()
    {
        /* Think of Instantiate as a spawner. in the () we are getting
        the foodlist list and getting the random index number. if the random 
        index number is 2 for example then we are spawning food2 <-- the reason is
        when in unity a list will start at 0 unless it has items in it then it starts
        at one. --> then we are getting the postion and rotation of the spawner/turret
        once all the data is togther then it spawns a food :D */
        Instantiate(foodList[rndFood], transform.position, transform.rotation);
    }

    public void dispenceBad()
    {
        Instantiate(badList[rndBad], transform.position, transform.rotation);
    }
    public void removefood1()
    {
        foodList.Remove(food1);
        Debug.Log("removed food 1");
    }
    public void removefood2()
    {
        foodList.Remove(food2);
        Debug.Log("remove food 2");
    }
    public void removefood3()
    {
        foodList.Remove(food3);
        Debug.Log("remove food 3");
    }
}
