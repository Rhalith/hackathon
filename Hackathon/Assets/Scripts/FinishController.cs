using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    public checker checker;
    public GameManager gameManager;
    public GameObject loseScreen;
    public GameObject winScreen;
    public int totalTeamNumber = 2;
    private int arrivedTeamNumber = 0;

    private void Update()
    {
        if (totalTeamNumber == arrivedTeamNumber)
        {
            loseScreen.SetActive(true);
        }
        
        if (gameManager.rescueTime <= 0f)
        {
            loseScreen.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            arrivedTeamNumber++;
            checker.onlyonce = true;
            
            other.gameObject.SetActive(false);
        }
    }
}
