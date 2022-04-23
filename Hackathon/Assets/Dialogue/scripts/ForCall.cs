using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.UI;

public class ForCall : MonoBehaviour
{
    public bool isStart = false;
    // Start is called before the first frame update
    void Update()
    {
        
        if (isStart)
        {
            gameObject.GetComponent<DialogueTrigger>().triggerDialogue();
            isStart = false;
        }
        
    }

}
