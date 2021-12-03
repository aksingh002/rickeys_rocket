using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quidapplication : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
            Debug.Log("you are quiting the game");
            Application.Quit();
        }
        
    }
}
