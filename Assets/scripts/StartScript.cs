using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject speedBooster;
    public GameObject turnBooster;
    public GameObject boostBooster;
    public GameObject newEnemy1;
    public GameObject newEnemy2;

    void Start()
    {
        //at the start of the game, generates stat boosters
        for (int i = 0; i < 20; i++)
        {
            GameObject newStatBooster;
            float randomX = Random.Range(-18f, 18f); //randomizes x coordinate 
            float randomZ = Random.Range(-18f, 18f); //randomizes z coordinate

            switch (Random.Range(0, 3)) // Random.Range function using integers excludes its max value, so this produces a random number from 0 to 2
            {
                case 0:
                    newStatBooster = Instantiate(speedBooster, new Vector3(randomX, .5f, randomZ), Quaternion.identity);
                    break;
                case 1:
                    newStatBooster = Instantiate(turnBooster, new Vector3(randomX, .5f, randomZ), Quaternion.identity);
                    break;
                case 2:
                    newStatBooster = Instantiate(boostBooster, new Vector3(randomX, .5f, randomZ), Quaternion.identity);
                    break;
            }
        }

        //at the start of the game, generates 2 additional enemies at random locations
        for (int i = 0; i < 2; i++)
        {
            GameObject newEnemy;
            float randomX = Random.Range(-16f, 16f); //randomizes x coordinate 
            float randomZ = Random.Range(-16f, 16f); //randomizes z coordinate

            switch (Random.Range(0, 2)) // Random.Range function using integers excludes its max value, so this produces a random number from 0 to 1
            {
                case 0:
                    newEnemy = Instantiate(newEnemy1, new Vector3(randomX, .5f, randomZ), Quaternion.identity);
                    break;
                case 1:
                    newEnemy = Instantiate(newEnemy2, new Vector3(randomX, .5f, randomZ), Quaternion.identity);
                    break;
            }
        }

    }

}
