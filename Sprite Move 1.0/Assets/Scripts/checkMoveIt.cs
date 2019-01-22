using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkMoveIt : MonoBehaviour
{
    private moveit moveScript;

    private void Awake()
    {
        //Grabs the move it script
        moveScript = GetComponent<moveit>();
    }

    private void Update()
    {
        //Checks the moveit script allowing disable or reenable
        if (moveScript.enabled == false) 

            //Shows message to console that moveit script is disabled
            Debug.Log("moveit script is disabled. Press P to enable");

        //Disables the moveit script, can reenable by pressing 'p' again
        if (Input.GetKeyDown(KeyCode.P))
            moveScript.enabled = true;

        //Disables the game object (breaking game forcing reset)
        if (Input.GetKeyDown(KeyCode.Q))
            gameObject.SetActive(false);

    }

}
