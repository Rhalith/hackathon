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
        int maxMoveDistance = playerController.maxMoveDistance;
        
        // time coroutine
        gameManager.rescueTime -= timeCost * stormFactor;
        print(gameManager.rescueTime);
        
        if(isClickable && (Mathf.Abs(playerController.posX-tileX) <= maxMoveDistance && Mathf.Abs(playerController.posY-tileY) <= maxMoveDistance))
            StartCoroutine(playerController.MovePlayerTo(tileX, tileY));
    }

    private void OnMouseOver()
    {
     //   print("isClickable: " + isClickable);
    }
}
