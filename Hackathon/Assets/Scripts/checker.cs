using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checker : MonoBehaviour
{
    public bool isRiver, isWeakbridge,isHole;
    public int river,weakbridge,hole;
    public GameObject LriverCam, WeakbridgeCam, holeCam;
    public bool isFirst = true;
    public bool onlyonce;

    // Update is called once per frame

    public void triggerDialog()
    {
        gameObject.GetComponent<DialogueTrigger>().triggerDialogue();
    }
}
