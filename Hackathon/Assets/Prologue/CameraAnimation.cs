using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private GameObject tableCamera, capsuleCamera;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (tableCamera.activeInHierarchy)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void CameraChanger()
    {
        tableCamera.SetActive(true);
        capsuleCamera.SetActive(false);
    }
}
