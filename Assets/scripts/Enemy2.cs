using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//enemy2 is a subclass of enemyScript
//it inherits variables that all enemies should have such as health
//it inherits functions that all enemies should have such as Update()

//this is a box that jumps at set intervals.
//the player can collide with it to make the box take damage.
public class Enemy2 : EnemyScript
{
    float jumpForce = 8f;
    int counter = 0;

    protected override void Update()
    {
        base.Update(); //calls update from the parent class because it is overridden

        //counter to perform a jump every so often
        counter++;
        if (counter >= 800)
        {
            Debug.Log("enemy jump");
            counter = 0;
            gameObject.GetComponent<Jump>().doJump(jumpForce); //executes the jump script
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //when it collides with the player
        if (other.gameObject.CompareTag("Player"))
        {
            health -= 50;   //this enemy loses 50 health
        }
    }


}
