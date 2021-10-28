
using UnityEngine;
using UnityEngine.UI;

//this script writes the player's stats in the top left corner

/* 2 ways to reference the fields of another class:
 *      1. Declare the object and script first. Then in the start event, initialize them. Then they can be referenced.
 *      2. single line: GameObject.Find("objectToReference").GetComponent<scriptToReference>().variableToReference
 */

public class WriteText : MonoBehaviour
{
    public Text m_MyText;
    private GameObject thePlayer;
    private PlayerScript playerScript;
    private string healthString;
    private string spdString;
    private string turnString;
    private string boostString;

    private void Start()
    {
        thePlayer = GameObject.Find("player");
        playerScript = thePlayer.GetComponent<PlayerScript>();
    }

    void Update()
    {
        //writes stats in the top left corner of the screen
        healthString = "Health: " + playerScript.health.ToString(); //uses option 1 to reference the variable
        spdString = "Speed: " + playerScript.max_spd.ToString();    
        turnString = "Turn: " + GameObject.Find("player").GetComponent<PlayerScript>().turn_spd.ToString(); //uses option 2 to reference the variable
        boostString = "Boost: " + GameObject.Find("player").GetComponent<PlayerScript>().boost_max.ToString();
        m_MyText.text = healthString + "\n\n"
            + spdString + "\n"
            + turnString + "\n"
            + boostString + "\n\n"
            ;
    }
}
