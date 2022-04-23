using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    [SerializeField] private GameObject tableCamera, capsuleCamera;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void CameraChanger()
    {
        tableCamera.SetActive(true);
        capsuleCamera.SetActive(false);
    }
}
