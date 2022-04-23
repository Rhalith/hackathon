using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxMoveDistance = 1;
    public float movementSpeed = 5f;
    public int posX, posY;

    private void Awake()
    {
        UpdatePositions();
    }

    private void UpdatePositions()
    {
        posX = (int)transform.position.x;
        posY = (int)transform.position.z;
    }

    public IEnumerator MovePlayerTo(int coordX, int coordY)
    {
        float totalTime = 0f;

        Vector3 targetPos = new Vector3(coordX, transform.position.y, coordY);
        
        while (totalTime < 1f)
        {
            totalTime += movementSpeed * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime);
            
            yield return new WaitForSeconds(0.001f);
        }

        transform.position = targetPos;
        UpdatePositions();
        yield return null;
    }
}
