using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkMoveIt : MonoBehaviour
{
    private moveit moveScript;

    private void Awake()
    {
        moveScript = GetComponent<moveit>();
    }

    private void Update()
    {
        if (moveScript.enabled == false) 
            Debug.Log("moveit script is disabled. Press P to enable");

        if (Input.GetKeyDown(KeyCode.P))
            moveScript.enabled = true;

        if (Input.GetKeyDown(KeyCode.Q))
            gameObject.SetActive(false);

    }

}
