using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy1 is a subclass of enemyScript
//it inherits variables that all enemies should have such as health
//it inherits functions that all enemies should have such as Update()

//this is a box that changes color at set intervals.
//when it is blue, it safe for the player to collide with it and the box will take damage.
//when it is red, the box will not take damage upon collision and the player will take damage instead.
public class Enemy1 : EnemyScript  
{
    //this enemy toggles the boolean dangerous on and off, giving the player only a short window to collide with it safely
    private bool dangerous = false;
    private int counter = 0;
    
    protected override void Update()
    {
        base.Update(); //calls update from the parent class because it is overridden

        //starts a counter to toggle dangerous at a set interval
        counter++;
        if (counter >= 300)
        {
            counter = 0;
            dangerous = !dangerous;
        }

        if (dangerous == true)
        {
            GetComponent<Renderer>().material.color = new Color(health, 0, 0); //red when dangerous
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(0, 0, health); //blue when not dangerous
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //when it collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            if (dangerous == false) //if not dangerous (blue) the enemy loses 50 health
            {
                health -= 50;
                Debug.Log("Health decreased. Health = " + health);
            }
            else //if dangerous (red) the player loses 75 health
            {
                playerScript.health -= 75;
                Debug.Log("Player got hurt. Player health: " + playerScript.health);
            }

            
        }
    }

}
