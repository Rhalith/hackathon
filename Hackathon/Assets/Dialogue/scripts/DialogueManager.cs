using System.Collections;
using System.Collections.Generic;
using UnityEngine; using UnityEngine.UI; using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText, dialogueText; 
    private Queue<string> sentences;

    public GameObject dialogueManager;
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        Activate();
        
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char c in sentence.ToCharArray())
        {
            dialogueText.text += c;
            yield return null;
        }
    }

    void EndDialogue()
    {
        Debug.Log("ended");
        Activate();
    }

    void Activate()
    {
        if (!dialogueManager.activeInHierarchy)
        {
            dialogueManager.SetActive(true);
        }
        else
        {
            dialogueManager.SetActive(false);
        }
        
    }
    // Update is called once per frame
}
