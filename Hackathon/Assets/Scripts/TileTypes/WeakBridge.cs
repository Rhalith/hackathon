using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeakBridge : Tile
{
    public GameObject breakedBridge;
    public bool bridgeBreaked = false;

    public float breakingDistance = 2.5f;
    
    private PlayerController player1Controller, player2Controller;
    
    private void Start()
    {
        player1Controller = player1.GetComponent<PlayerController>();
        player2Controller = player2.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (isClicked && isOneTimeUse && isClickable)
        {
            isClickable = false;
            bridgeBreaked = true;
            
            checker.weakbridge++;
        }


        if (bridgeBreaked && (Vector3.Distance(new Vector3(tileX, 0, tileY), player1Controller.GetPosition()) >= breakingDistance &&
                              Vector3.Distance(new Vector3(tileX, 0, tileY), player2Controller.GetPosition()) >= breakingDistance))
        {
            breakedBridge.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
