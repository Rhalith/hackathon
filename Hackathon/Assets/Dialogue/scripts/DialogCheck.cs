using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCheck : MonoBehaviour
{
    public GameObject diyalog321,diyalog322, diyalog621, diyalog622, diyalog821, diyalog822;
    //Tam bir amele iþiyle çözdüm, uykulu kafayla sýkýntý çýkarmadan nasýl yaparým derken en temizinin böyle olduðunu düþündüm

    //scene'de gördüðün gibi tüm diyaloglar ses dosyalarý(audio source) ile birlikte hazýr. Biz bu script ile içine girdiðimiz bloktaki bulunan(bizim koyduðumuz) trigger'a giriyor ve ismine bakarak hangisi olduðunu anlýyor.

    //Bu sonrasýnda hangi ekibin gittiðine göre ekip adý ve yine bizim önceden koyduðumuz ekip seslerine göre telsiz mesajýný çalýyor.
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.name == "diyalog32")
        {
            if (other.gameObject.name == "Player")
            {
                diyalog321.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog321.GetComponent<AudioSource>().Play();
            }
            else
            {
                diyalog322.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog322.GetComponent<AudioSource>().Play();

            }
        }
        else if (gameObject.name == "diyalog62")
        {
            if (other.gameObject.name == "Player")
            {
                diyalog621.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog621.GetComponent<AudioSource>().Play();
            }
            else
            {
                diyalog622.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog622.GetComponent<AudioSource>().Play();
            }
        }
        else if (gameObject.name == "diyalog82")
        {
            if (other.gameObject.name == "Player")
            {
                diyalog821.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog821.GetComponent<AudioSource>().Play();
            }          
            else       
            {          
                diyalog822.GetComponent<DialogueTrigger>().triggerDialogue();
                diyalog822.GetComponent<AudioSource>().Play();
            }
        }
    }
}
