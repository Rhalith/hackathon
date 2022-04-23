using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    public PlayerController playerController;

    public int tileX;
    public int tileY;

    private void Awake()
    {
        tileX = (int) transform.position.x;
        tileY = (int) transform.position.z;
    }

    void OnMouseUp()
    {
        int maxMoveDistance = playerController.maxMoveDistance;
        
        if(Mathf.Abs(playerController.posX-tileX) <= maxMoveDistance && Mathf.Abs(playerController.posY-tileY) <= maxMoveDistance)
            StartCoroutine(playerController.MovePlayerTo(tileX, tileY));
    }
}
