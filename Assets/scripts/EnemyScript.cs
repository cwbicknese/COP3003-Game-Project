using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// EnmeyScript is a superclass to the subclasses Enemy1 and Enemy2
// Because Enemy1 and Enemy2 inherit from EnemyScript, they will
// have the same variables and functions passed down to them.

// I called them enemies, but a more accurate way to describe them would
// be boxes that can be broken to obtain stat boosters.

public class EnemyScript : MonoBehaviour
{
    public float health; // all enemies have health

    public EnemyScript() // default constructor sets health to 100
    {
        health = 100;  
    }
    public EnemyScript(float enemyHealth) // overloaded contructor takes a float as a parameter to set health
    {
        health = enemyHealth;  
    }
    // Since it uses the Monobehaviour superclass to gain access to Unity functions, objects of this class
    // will be created using the Instantiate() function instead of the "new" keyword
    
    public GameObject speedBooster; // all enemies will be able to drop these 3 stat boosters when defeated
    public GameObject turnBooster;
    public GameObject boostBooster;

    protected GameObject thePlayer;     // declare the player object and script
    protected PlayerScript playerScript;

    protected void Start()  // initialize the player object and script to access their variables
    {
        thePlayer = GameObject.Find("player");
        playerScript = thePlayer.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    protected virtual void Update() // this is protected so that the subclasses can call it after overriding
    {
            //when the enemy's health gets reduced to zero, the enemy will create stat boosters and destroy itself
            if (health <= 0)
            {
                Debug.Log("Dead");

                GameObject newStatBooster;
                float x = transform.position.x;
                float z = transform.position.z;

                //item drop
                for (int i = 0; i < 4; i++) // makes 4 items
                {
                    //randomly select one of three stat boosters to drop
                    switch (Random.Range(0, 3)) // Random.Range function using integers excludes its max value, so this produces a random number from 0 to 2
                    {
                        case 0:  //creates a speed booster pickup at the boxes position with a slight deviation of the x and z axes, y axis remains the same at .5f
                            newStatBooster = Instantiate(speedBooster, new Vector3(x - .5f + Random.Range(0f, 1f), .5f, z - .5f + Random.Range(0f, 1f)), Quaternion.identity);
                            break;
                        case 1:
                            newStatBooster = Instantiate(turnBooster, new Vector3(x - .5f + Random.Range(0f, 1f), .5f, z - .5f + Random.Range(0f, 1f)), Quaternion.identity);
                            break;
                        case 2:
                            newStatBooster = Instantiate(boostBooster, new Vector3(x - .5f + Random.Range(0f, 1f), .5f, z - .5f + Random.Range(0f, 1f)), Quaternion.identity);
                            break;
                    }
                }

                //destroy self
                Destroy(gameObject);
            }
    }
}
