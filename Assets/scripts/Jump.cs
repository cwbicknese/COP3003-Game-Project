using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    //this function makes the object go up by an amount based on the float passed as an argument
    //default parameter sets the amount to 4
    public void doJump(float jumpAmount=4)
    {
        Debug.Log("Jumped");
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpAmount, 0);
    }

}
