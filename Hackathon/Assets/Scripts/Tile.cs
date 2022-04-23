using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public PlayerController playerController;
    public GameManager gameManager;

    public bool isClickable = true;
    public bool isOneTimeUse = false;
    protected bool isClicked = false;

    public float timeCost;

    public float stormFactor = 1f;

    private int tileX;
    private int tileY;

    private void Awake()
    {
        tileX = (int) transform.position.x;
        tileY = (int) transform.position.z;
    }

    void OnMouseUp()
    {
        float maxMoveDistance = playerController.maxMoveDistance;

        if (isClickable && Vector3.Distance(transform.position, new Vector3(playerController.posX, 0, playerController.posY)) <= maxMoveDistance)
        {
            // time coroutine
            if(gameManager.isStormHappened)
                gameManager.rescueTime -= timeCost * stormFactor;
            else
                gameManager.rescueTime -= timeCost;
            print(gameManager.rescueTime);
            
            StartCoroutine(playerController.MovePlayerTo(tileX, tileY));
            isClicked = true;
        }
    }

    private void OnMouseOver()
    {
        // Show properties of that tile
        //print("isClickable: " + isClickable);
    }
}
