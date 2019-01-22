using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addKeyButtons : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))

            Application.Quit();

        Debug.Log("This game has quit");
    }

}
