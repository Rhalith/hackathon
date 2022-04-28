using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxMoveDistance = 1f;
    public float movementSpeed = 5f;
    public int posX, posY;

    private bool initialpositionset, currentpositionset;
    public GameObject kuzey, guney, dogu, bati;
    Vector3 currentpos;
    
    public bool isVictimWithMe = false;

    private void Awake()
    {
        UpdatePositions();
    }
    
    private void FixedUpdate()
    {
        if (!initialpositionset)
        {
            currentpos = transform.position;
            initialpositionset = true;
            currentpositionset = false;

        }
        if (!currentpositionset && initialpositionset)
        {
            if (transform.position.z - currentpos.z > 0 && !(transform.position.x == 4 && transform.position.z > 0))
            {
                kuzey.GetComponent<DialogueTrigger>().triggerDialogue();
                kuzey.GetComponent<AudioSource>().Play();
                currentpositionset = true;
                print("kuzey");
                return;
            }
            else if (transform.position.z - currentpos.z < 0)
            {
                guney.GetComponent<DialogueTrigger>().triggerDialogue();
                guney.GetComponent<AudioSource>().Play();
                currentpositionset = true;
                print("güney");
                return;
            }
            else if (transform.position.x - currentpos.x < 0 && !(transform.position.z == 2 && transform.position.x < 6))
            {
                bati.GetComponent<DialogueTrigger>().triggerDialogue();
                bati.GetComponent<AudioSource>().Play();
                currentpositionset = true;
                print("bati");
                return;
            }
            else if (transform.position.x - currentpos.x > 0 && !(transform.position.z == 2 && transform.position.x > 8))
            {
                dogu.GetComponent<DialogueTrigger>().triggerDialogue();
                dogu.GetComponent<AudioSource>().Play();
                currentpositionset = true;
                print("dogu");
                return;
            }

        }

    }

    private void UpdatePositions()
    {
        posX = Mathf.RoundToInt(transform.position.x);
        posY = Mathf.RoundToInt(transform.position.z);
    }

    public IEnumerator MovePlayerTo(int coordX, int coordY)
    {
        float totalTime = 0f;

        Vector3 targetPos = new Vector3(coordX, transform.position.y, coordY);
        
        while (totalTime < 1f)
        {
            totalTime += movementSpeed * Time.deltaTime;
            //target position ve initial position aras�ndaki farka bakarak do�u bat� g�ney kuzey diyalog/sesleri ayarlanabilir

            //mesela x y�n�nde +1 gittiyse do�u, -1 gittiyse bat� vb.
            transform.position = Vector3.Lerp(transform.position, targetPos, movementSpeed * Time.deltaTime);
            
            yield return new WaitForSeconds(0.001f);
        }

        transform.position = targetPos;
        UpdatePositions();
        yield return null;
    }

    public Vector3 GetPosition()
    {
        return new Vector3(posX, 0, posY);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("victim") && !isVictimWithMe)
        {
            other.gameObject.SetActive(false);
            isVictimWithMe = true;
        }
    }
}
