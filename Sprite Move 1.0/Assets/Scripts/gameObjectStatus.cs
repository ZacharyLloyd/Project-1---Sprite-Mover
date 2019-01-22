using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectStatus : MonoBehaviour
{
    public GameObject Player;

    private void Update()
    {
        if (Player.activeInHierarchy == false)
            Debug.Log("Player inactive");
    }

}
