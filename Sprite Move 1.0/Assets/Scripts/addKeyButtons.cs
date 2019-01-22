using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addKeyButtons : MonoBehaviour
{
    private void Update()
    {
        //Forces the game to quit by pressing 'escape' key
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Application.Quit();
            //Shows message to console saying the game has quit
            Debug.Log("This game has quit");

        }
    }

}
