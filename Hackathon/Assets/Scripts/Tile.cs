using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour
{
    PlayerController playerController;
    public GameManager gameManager;
    public checker checker;
    public int whereIam;
    public GameObject player1, player2;

    public bool isClickable = true;
    public bool isOneTimeUse = false;
    protected bool isClicked = false;

    public float timeCost;

    public float stormFactor = 1f;

    public int tileX;
    public int tileY;
    private void Awake()
    {
        tileX = Mathf.RoundToInt(transform.position.x);
        tileY = Mathf.RoundToInt(transform.position.z);

    }

    void OnMouseUp()
    {
        //diyalog an�nda hareket etmesini engelliyor.
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        //1. 2. ekip aras�ndaki kontrol ge�i�i.
        if (checker.isFirst)
        {
            playerController = player1.GetComponent<PlayerController>();
        }
        else
        {
            playerController = player2.GetComponent<PlayerController>();
        }
        float maxMoveDistance = playerController.maxMoveDistance;

        if (isClickable && Mathf.Round(Vector3.Distance(transform.position, new Vector3(playerController.posX, 0, playerController.posY))) <= maxMoveDistance)
        {
            
            if(gameManager.isStormHappened)
                gameManager.rescueTime -= timeCost * stormFactor;
            else
                gameManager.rescueTime -= timeCost;
            print(gameManager.rescueTime);

            
            StartCoroutine(playerController.MovePlayerTo(tileX, tileY));
            isClicked = true;
            //1. 2. ekip aras�ndaki kontrol ge�i�i
            if (!checker.onlyonce)
            {
                if (!checker.isFirst)
                {
                    checker.isFirst = true;
                }
                else if (checker.isFirst)
                {
                    checker.isFirst = false;
                }
            }
           
            
            // time coroutine
            gameManager.UpdateTimer();
        }
    }

    private void OnMouseOver()
    {
        // Show properties of that tile
        //print("isClickable: " + isClickable);
    }

}
