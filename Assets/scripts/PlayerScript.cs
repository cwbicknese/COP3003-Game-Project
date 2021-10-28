using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //initialize player's variables
    public float health = 500;
    public float max_spd = 3f;
    public float current_spd = 0f;
    public float turn_spd = 50f;
    public float boost_max = 5f;
    public float boost_counter = 0f;
    public float jumpForce = 6f;

    // Update is called once per frame
    void Update()
    {
        //death
        if (health <= 0)
        {
            Debug.Log("Player died.");
            enabled = false;
        }

        //jump
        if (Input.GetKeyDown("up"))
        {
            gameObject.GetComponent<Jump>().doJump(); //makes the player jump. Since it passes no argument, 
                                                        // it uses the default parameter value
        }

        //accelerate until current_spd matches max_spd
        if (current_spd < max_spd)
        {
            current_spd += .1f;
        }

        // move automatically as long as the space key isn't held down
        if (!Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * (current_spd + (boost_counter*3)) * Time.deltaTime); // move forward according to speed, adding boost_counter to speed
                                                                                           // Time.deltaTime makes it per second rather than per frame
            if (boost_counter > 0)  
            {
                boost_counter -= .1f; // gradually decrease boost_counter after the player boosts
            }

        }
        else // holding space charges the boost
        {
            if (boost_counter < boost_max)
            {
                boost_counter += .05f; // the longer the player charges up, the higher they can boost, up to their maximum boost
            }
        }

        // turn left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * -turn_spd * Time.deltaTime);
        }

        // turn right
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * turn_spd * Time.deltaTime);
        }

    } //Update() end

    //pick up stats by colliding with them, increasing the player's stats and destroying the stat booster
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Speed Booster"))
        {
            max_spd += 1f;
            Debug.Log("Speed Increased! Current Speed = " + max_spd);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Turn Booster"))
        {
            turn_spd += 10f;
            Debug.Log("Turn Increased! Current Turn = " + turn_spd);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.CompareTag("Boost Booster"))
        {
            boost_max++;
            Debug.Log("Boost Increased! Current Boost = " + boost_max);
            Destroy(other.gameObject);
        }

        //bounce off enemies
        else if (other.gameObject.CompareTag("Enemy"))
        {
            boost_counter = 0;
            current_spd = -8;
        }

        //bounce off walls
        else if (other.gameObject.CompareTag("Wall"))
        {
            boost_counter = 0;
            current_spd = -8;
        }
    }
}
